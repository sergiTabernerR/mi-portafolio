/* 
 * Projecte M15-Dual Poker Multijugador amb WebSockets
 * 
 * Classe ControllerClient que conté el controlador de la vista principal.
 * ( Client )
 * 
 * versió 1.0
 * 
 * Autors: Jesús Zafra i Sergi Taberner
 */
#region usings
using Pt1_WebSockets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion
namespace Pt1b_WebSockets_Client.Controller
{
    class ControllerClient
    {
        private ClientWebSocket socket;
        private CancellationTokenSource cts;
        private readonly Form1 f;
        private string wsUri;
        private string nomConnectat = "";
        private readonly Label[] lbCartes;
        private MaPoker _ma;                         //mà amb les cartes del client
        private int posCarta;                        //apunta a la següent posició lliure de cartes a la taula
        private int jugadors;                        //jugadors connectats actualment
        private Carta cartaMig;                      //carta actual que envia el servidor
        private readonly SolidBrush color_lb_selin;  //guarda color linia seleccionada lbMissatges
        private bool roomFull;
        private bool isGameRunning;

        private const string BACK_CARD = "\ud83c\udca0";

        public ControllerClient()
        {
            f = new Form1();
            socket = new ClientWebSocket();
            cts = new CancellationTokenSource();
            LoadData();
            InitListeners();
            f.lbMissatges.SelectionMode = SelectionMode.One;
            f.lbMissatges.DrawMode = DrawMode.OwnerDrawFixed;
            f.lbMissatges.DrawItem += new DrawItemEventHandler(LbMissatges_DrawItem);
            color_lb_selin = new SolidBrush(f.lbMissatges.BackColor);

            //Crea array dels labels per dibuixar les cartes a la taula de joc
            lbCartes = new Label[5];
            lbCartes[0] = f.lbCarta1;
            lbCartes[1] = f.lbCarta2;
            lbCartes[2] = f.lbCarta3;
            lbCartes[3] = f.lbCarta4;
            lbCartes[4] = f.lbCarta5;
            //Les inicialitza a res perquè provoquin un event TextChanged i es pintin adequadament
            foreach (Label lb in lbCartes)
            {
                lb.Text = "";
            }
            f.lbCartaEntra.Text = "";

            Init();
            Application.Run(f);
        }

        private void Init()
        {
            _ma = new MaPoker();
            roomFull = false;
            isGameRunning = false;
            //f.btConnectar.ForeColor = Color.FromName("Green");
            f.lbConnectar.Text = "Connectar";
            f.btEnviar.Enabled = false;
            f.btAdquirir.Enabled = false;
            f.lbCartaEntra.Cursor = Cursors.Arrow;
            f.tbNom.ReadOnly = false;
            f.tbLocalHost.ReadOnly = false;
            f.tbMessage.Enabled = false;
            f.lbCartaEntra.Text = BACK_CARD;
            foreach (Label lb in lbCartes)
            {
                lb.Text = BACK_CARD;
            }
            f.ActiveControl = f.tbNom; //posa el focus al tb            
            posCarta = 0;
            f.chkInici.Enabled = false;
            f.chkInici.Checked = false;
        }
        private void InitListeners()
        {
            f.chkConnectar.Click += ChkConnectar_Click;
            f.btEnviar.Click += BtEnviar_Click;
            f.chkInici.Click += ChkInici_Click;
            f.btAdquirir.Click += BtAdquirir_Click;
            f.lbCartaEntra.Click += BtAdquirir_Click;
            f.tbMessage.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
            f.tbLocalHost.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
            f.tbNom.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);

            f.lbCartaEntra.TextChanged += LbCarta_TextChanged;
            f.lbCarta1.TextChanged += LbCarta_TextChanged;
            f.lbCarta2.TextChanged += LbCarta_TextChanged;
            f.lbCarta3.TextChanged += LbCarta_TextChanged;
            f.lbCarta4.TextChanged += LbCarta_TextChanged;
            f.lbCarta5.TextChanged += LbCarta_TextChanged;

        }
        //Afegeix un text al listbox de missatges
        private void EscriuMsg(string missatge)
        {
            f.lbMissatges.Items.Add(missatge);
            if (f.chkAutoscroll.Checked)
                f.lbMissatges.SelectedIndex = f.lbMissatges.Items.Count - 1;

        }

        //Posa el color del pal adequat als labels que pinten cartes
        private void LbCarta_TextChanged(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            if (lb.Text == BACK_CARD)
            {
                lb.ForeColor = Color.FromName("AliceBlue");
                lb.Image = Poker.Properties.Resources.cardsBack;
                if (lb.Name.Equals("lbCartaEntra"))
                {
                    lb.Cursor = Cursors.Arrow;
                    f.btAdquirir.Enabled = false;
                }
            }
            else
            {
                if (lb.Name.Equals("lbCartaEntra"))
                {
                    lb.Cursor = Cursors.Hand;
                    f.btAdquirir.Enabled = true;
                }
                var pal = Carta.GetPal(lb.Text);
                lb.Image = Poker.Properties.Resources.cardsFace;
                if (pal == 1 || pal == 4)
                {
                    lb.ForeColor = Color.FromArgb(175, 0, 0);
                }
                else
                {
                    lb.ForeColor = Color.FromArgb(4, 16, 4);
                }
            }
        }

        private void BtAdquirir_Click(object sender, EventArgs e)
        {
            if (socket.State == WebSocketState.Open && posCarta < 5 && f.lbCartaEntra.Text != BACK_CARD)
            {
                Send(Comanda.TAKECARD);
            }
        }

        //Event produït quant el listbox és modificat (obliga a que es torni a dibuixar)
        private void LbMissatges_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            f.lbMissatges.Invalidate();
        }

        //Dibuixa els items del listbox
        private void LbMissatges_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            int index = e.Index;
            Graphics g = e.Graphics;
            foreach (int selectedIndex in f.lbMissatges.SelectedIndices)
            {
                if (index == selectedIndex)
                {
                    // Dibuixa el nou color de fons per marcar darrera línia del listbox                    
                    e.DrawBackground();
                    g.FillRectangle(color_lb_selin, e.Bounds);
                }
            }

            //Obté els detalls de les propietats del component
            Font font;
            Color colour;
            string text;
            try
            {
                font = f.lbMissatges.Font;
                colour = f.lbMissatges.ForeColor;
                text = f.lbMissatges.Items[index].ToString();
                //Imprimeix el text
                g.DrawString(text, font, new SolidBrush(Color.FromName("Info")), (float)e.Bounds.X, (float)e.Bounds.Y);
                e.DrawFocusRectangle();
            }
            catch { } // perquè no peti al fer doble click al listbox            

        }

        //Mètode que s'usa quan es prem <Enter> per enviar missatges a tbMessage
        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            // si no s'ha premut Enter, surt...
            if (e.KeyChar != (char)Keys.Enter) { return; }

            TextBox tb = (TextBox)sender;
            switch (tb.Name)
            {
                case "tbMessage":
                    f.btEnviar.PerformClick();
                    break;
                case "tbLocalHost":
                    if (f.tbNom.TextLength > 0 && f.tbLocalHost.TextLength > 0)
                    {
                        f.ActiveControl = f.chkConnectar;
                    }
                    else
                    {
                        f.ActiveControl = f.tbNom;
                    }
                    break;
                case "tbNom":
                    if (f.tbLocalHost.TextLength > 0 && f.tbNom.TextLength > 0)
                    {
                        f.ActiveControl = f.chkConnectar;
                    }
                    else
                    {
                        f.ActiveControl = f.tbLocalHost;
                    }
                    break;
            }
            e.Handled = true; //Perquè no soni el "ding" quan es prem Enter
        }

        private void ChkInici_Click(object sender, EventArgs e)
        {
            //si el joc no ha començat i s'han rebut les 2 cartes d'obertura:
            if (!isGameRunning && posCarta == 2)
            {
                if (!f.chkInici.Checked)
                {
                    f.chkInici.Checked = true;
                    f.ActiveControl = f.btAdquirir;
                    Send(Comanda.PLAYER_READY);
                }
                else
                {
                    f.chkInici.Checked = false;
                    Send(Comanda.PLAYER_UNREADY);
                }
            }
        }

        private void BtEnviar_Click(object sender, EventArgs e)
        {
            if (f.tbMessage.Text.Length > 0)
            {
                EscriuMsg(nomConnectat + ": " + f.tbMessage.Text);
                Send(f.tbMessage.Text);
                f.tbMessage.Text = "";
            }
        }

        private async void ChkConnectar_Click(object sender, EventArgs e)
        {
            if (f.tbNom.Text.Length > 0)
            {
                if (socket.State == WebSocketState.None)
                {
                    try
                    {
                        f.chkConnectar.Checked = true;
                        await Start();
                    }
                    catch (WebSocketException ex)
                    {
                        EscriuMsg("Impossible establir la connexió amb el servidor.");
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                        Desconnecta();
                    }
                    catch (OperationCanceledException)
                    {
                        // MessageBox.Show("Connexió tancada");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Desconnecta();
                    }
                }
                else
                {
                    if (!roomFull) // si marxa perquè la partida està plena no l'acomiada perquè no va entrar.
                    {
                        EscriuMsg("Adéu " + nomConnectat + " torna aviat!");
                        Desconnecta();
                    }
                }
            }
        }

        private void Desconnecta()
        {
            if (socket.State == WebSocketState.Open)
            {
                cts.Cancel();

                socket = new ClientWebSocket();
                cts = new CancellationTokenSource();
                EscriuMsg(DateTime.Now.ToString(new CultureInfo("es-ES")) + "\tDesconnectat.");
                f.chkConnectar.Checked = false;
                Init(); //Reseteja la partida en curs
            }
        }

        private void LoadData()
        {
            //f.tbLocalHost.Text = "localhost:44377";
            f.tbLocalHost.Text = "pt1-websockets.conveyor.cloud/";
        }

        //Enviar missatges al servidor
        private async void Send(byte[] sendBytes)
        {
            var sendBuffer = new ArraySegment<byte>(sendBytes);
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
        }
        private void Send(string missatge)
        {
            Send(Encoding.UTF8.GetBytes(missatge));

        }
        private void Send(byte sendByte)
        {
            Send(new byte[] { sendByte });
        }

        // ******* Inici de la connexió ********   
        public async Task Start()
        {
            if (socket.State == WebSocketState.None)
            {
                EscriuMsg("Connectant ...");
                EscriuMsg("");
                wsUri = "wss://" + f.tbLocalHost.Text + "/api/websocket?nom=" + f.tbNom.Text;

                try
                {
                    await socket.ConnectAsync(new Uri(wsUri), cts.Token);
                }
                catch /*WebSocketException*/
                {
                    MessageBox.Show("No es pot establir la connexió amb el servidor!");
                    socket.Abort();
                }
                //S'ha connectat:
                if (socket.State == WebSocketState.Open)
                {
                    EscriuMsg(DateTime.Now.ToString(new CultureInfo("es-ES")) + "\tConnectat.");
                    nomConnectat = f.tbNom.Text;
                    f.lbConnectar.Text = "Desconnectar";
                    f.btEnviar.Enabled = true;
                    EscriuMsg("Escriu /list o /clist per obtenir la llista d'usuaris connectats.");
                    f.tbNom.ReadOnly = true;
                    f.tbLocalHost.ReadOnly = true;
                    f.tbMessage.Enabled = true;

                    Send("/clist");
                    f.ActiveControl = f.tbMessage;
                    await ReceiveData(socket, cts);
                }
            }
        }
        //Recepció continua de missatges
        public async Task ReceiveData(ClientWebSocket socket, CancellationTokenSource cts)
        {
            byte[] rcvBytes = new byte[128];
            ArraySegment<byte> rcvBuffer = new ArraySegment<byte>(rcvBytes);
            while (true)
            {
                WebSocketReceiveResult rcvResult = await socket.ReceiveAsync(rcvBuffer, cts.Token);
                byte[] msgBytes = rcvBuffer.Skip(rcvBuffer.Offset).Take(rcvResult.Count).ToArray();
                string rcvMsg = Encoding.UTF8.GetString(msgBytes);
                Carta carta;

                switch (msgBytes[0])
                {
                    case Comanda.GAMERUNNING:
                        isGameRunning = true;
                        f.chkInici.Enabled = false;
                        break;
                    case Comanda.REQINI:
                        //La partida no pot començar amb menys de 2 jugadors
                        jugadors = msgBytes[1];
                        if (jugadors > 1 && !isGameRunning)
                        {
                            f.chkInici.Enabled = true;
                        }
                        f.chkConnectar.Enabled = true;
                        break;

                    case Comanda.SENDCARD:
                        carta = Carta.GetCarta(msgBytes[1]);
                        lbCartes[posCarta].Text = carta.Dibuix;
                        _ma.AfegirCarta(carta);
                        posCarta++;
                        break;

                    case Comanda.ROOMFULL:
                        f.lbConnectar.Text = "Connectar";
                        f.chkConnectar.Checked = false;
                        f.tbNom.ReadOnly = true;
                        f.tbLocalHost.ReadOnly = true;
                        roomFull = true;
                        break;

                    case Comanda.INCARD:
                        cartaMig = Carta.GetCarta(msgBytes[1]);
                        f.lbCartaEntra.Text = cartaMig.Dibuix;
                        //f.btAdquirir.Enabled = true;
                        //f.lbCartaEntra.Cursor = Cursors.Hand;
                        break;

                    case Comanda.TAKECARD:
                        if (msgBytes[1] == 1)
                        {
                            if (posCarta < 5)
                            {
                                //Agafa la carta del mig
                                if (cartaMig != null)
                                {
                                    _ma.AfegirCarta(cartaMig);
                                    lbCartes[posCarta++].Text = cartaMig.Dibuix;
                                    f.lbCartaEntra.Text = BACK_CARD;
                                    cartaMig = null;
                                    if (posCarta == 5)
                                    {
                                        //f.btAdquirir.Enabled = false;
                                        //f.lbCartaEntra.Cursor = Cursors.Arrow;
                                        f.lbCartaEntra.Text = BACK_CARD;
                                        InformeFinalPartida();
                                        Send(Comanda.HANDFULL);
                                    }
                                }
                            }
                        }
                        else
                        {
                            f.lbCartaEntra.Text = BACK_CARD;
                            cartaMig = null;
                            f.btAdquirir.Enabled = false;
                            f.lbCartaEntra.Cursor = Cursors.Arrow;
                        }
                        break;

                    case Comanda.DELCARD:
                        f.lbCartaEntra.Text = BACK_CARD;
                        cartaMig = null;
                        break;
                    case Comanda.ENDGAME:
                        isGameRunning = false;
                        f.chkInici.Checked = false;
                        f.chkInici.Enabled = false;
                        if (msgBytes[1] == Resultat.EMPAT)
                        {
                            EscriuMsg("");
                            EscriuMsg("La partida ha acabat en empat.");
                            EscriuMsg("");
                        }
                        else
                        {
                            string guanyador = "";
                            for (int i = 2; i < msgBytes.Length; i++)
                            {
                                guanyador += (char)msgBytes[i];
                            }

                            if (guanyador.Equals(nomConnectat))
                            {
                                EscriuMsg("");
                                EscriuMsg("Has guanyat la partida!");
                                EscriuMsg("");
                            }
                            else
                            {
                                EscriuMsg("");
                                EscriuMsg(guanyador + " ha guanyat la partida!");
                                EscriuMsg("");
                            }
                        }                        
                        EscriuMsg("Fi de la partida, desconnecta't i torna't a conectar per jugar una partida nova.");
                        break;

                    default:
                        EscriuMsg(rcvMsg);
                        break;
                } // fi del switch..case
            } // fi del while
        } // fi del mètode ReceiveData

        //Informa de la puntuació de la mà del client quant té cinc cartes        
        private void InformeFinalPartida()
        {
            if (_ma.TotalCartes() == 5)
            {
                _ma.Avalua();
                EscriuMsg("Tens " + _ma.GetResultat(true));
            }
        }
    }
}


