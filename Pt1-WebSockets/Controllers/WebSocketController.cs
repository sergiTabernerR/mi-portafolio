/* 
 * Projecte M15-Dual Poker Multijugador amb WebSockets
 * ( Servidor )
 * versió 1.0
 * Autors: Jesús Zafra i Sergi Taberner
 */
#region Usings
using Microsoft.Web.WebSockets;
using Pt1_WebSockets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Timers;
using System.Web;
using System.Web.Http;
#endregion

namespace Pt1_WebSockets.Controllers
{
    public class WebSocketController : ApiController
    {
        public const byte MIN_JUGADORS = 2;
        public const byte MAX_JUGADORS = 6;
        public const int CARD_TIMEOUT = 2000;
        public const byte TRUE = 1;
        public const byte FALSE = 0;

        private static readonly WebSocketCollection Sockets = new WebSocketCollection();
        private static int totalPreparats;
        private static int handsFull;
        private static Baralla baralla;
        private static Baralla barallaSignada;
        private static System.Threading.Timer timer = null;
        private static Timer timeoutTimer = null;
        private static Carta cartaMig;
        private static List<Carta> munt;
        public WebSocketController()
        {
            Init();
        }
        private static void Init()
        {
            handsFull = 0;
            totalPreparats = 0;

            //per no generar un objecte repetit a cada client ens assegurem 
            // comprovant els null ...            
            if (baralla == null)
            {
                baralla = new Baralla();
            }
            if (barallaSignada == null)
            {
                barallaSignada = new Baralla();
                barallaSignada.Clear();
            }
            if (munt == null)
            {
                munt = new List<Carta>();
            }
            InitTimer();
            StopTimeOutTimer();
        }
        private static void InitTimer()
        {
            // Crea / Inicialitza temporitzador principal
            if (timer != null)
            {
                timer.Dispose();
            }
            timer = new System.Threading.Timer(callback: TimerCallback, null, 0, 250);

        }
        private static void StartTimeOutTimer()
        {
            // Crea / Inicialitza temporitzador dels timeout
            if (timeoutTimer == null)
            {
                timeoutTimer = new Timer { Interval = CARD_TIMEOUT };
                timeoutTimer.Elapsed += TimeoutTimer_Elapsed;
                timeoutTimer.Start();
            }
        }
        private static void StopTimeOutTimer()
        {
            if (timeoutTimer != null)
            {
                timeoutTimer.Stop();
                timeoutTimer = null;
            }
        }
        //mètode que s'invoca quan es produeix l'event del TimeOutTime
        private static void TimeoutTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //reparteix la carta del mig
            if (!baralla.EsBuida())
            {
                byte[] cadena = new byte[2];
                string sended;
                cadena[0] = Comanda.INCARD;

                cartaMig = baralla.Repartir();

                if (cartaMig != null)
                {
                    cadena[1] = Convert.ToByte(cartaMig.GetValueString());
                    sended = Encoding.UTF8.GetString(cadena);
                    Sockets.Broadcast(sended);
                }
            }
            else //la baralla està buida
            {
                //Quan no quedin cartes a la baralla la intenta omplir amb el munt (si conté cartes).
                munt = new List<Carta>();
                //crea el munt
                foreach (Carta carta in baralla.GetPaquet())
                {
                    if (carta.Usuari == null)
                    {
                        munt.Add(carta);
                    }
                }
                if (munt.Count > 0)
                {

                    baralla.SetPaquet(munt);

                    baralla.Remenar();

                    Sockets.Broadcast("Baralla sense cartes, el munt retorna a la baralla.");
                }
                else //en cas contrari s'ha de finalitzar la partida en curs
                {
                    Sockets.Broadcast("S'han repartit totes les cartes.");
                }
            }
        }
        private static void RestartGame()
        {
            SocketHandler.PartidaIniciada = false;
            baralla = null;
            barallaSignada = null;
            munt = null;
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
            if (timeoutTimer != null)
            {
                timeoutTimer.Stop();
                timeoutTimer.Close();
                timeoutTimer = null;
            }
            Init();
        }
        //Mètode que s'invoca continuament
        private static void TimerCallback(Object o)
        {
            //Informa del total de jugadors connectats                
            byte[] msgOut = new byte[2];
            msgOut[0] = Comanda.REQINI;
            msgOut[1] = (byte)Sockets.Count;
            foreach (WebSocketHandler sh in Sockets)
            {
                sh.Send(msgOut);
            }

            if (PartidaIniciable())
            {
                SocketHandler.PartidaIniciada = true;                
                Sockets.Broadcast(new byte[] { Comanda.GAMERUNNING });
                StartTimeOutTimer();
            }

            if (SocketHandler.PartidaIniciada && Sockets.Count == 0)
            {
                RestartGame();
            }

            //Fi de la partida, informa del guanyador.
            if (SocketHandler.PartidaIniciada && handsFull == Sockets.Count)
            {
                //Assegura que barallasignada conté només cartes amb signatura
                //(problemes amb partides de jugadors desconnectats)
                foreach (Carta c in barallaSignada.GetPaquet().ToList())
                {
                    if (c.Usuari == null)
                    {
                        barallaSignada.EsborraCarta(c);
                    }
                }

                List<string> usuaris = new List<string>();
                //Crea la llista de mans per a cada usuari actiu:
                List<MaPoker> mans = new List<MaPoker>();
                IEnumerable<IGrouping<string, Carta>> grp = barallaSignada.GetPaquet().GroupBy(a => a.Usuari).ToList();
                foreach (IGrouping<string, Carta> usuarisMa in grp)
                {
                    if (usuarisMa != null)
                    {
                        MaPoker ma = new MaPoker(usuarisMa.Key);
                        foreach (Carta c in barallaSignada.GetPaquet().Where(a => a.Usuari.Equals(usuarisMa.Key)).ToList())
                            ma.AfegirCarta(c);

                        ma.Avalua();
                        mans.Add(ma);
                    }
                }
                mans = mans.OrderByDescending(a => a.Valor).ToList();

                byte[] cadena = new byte[2];
                cadena[0] = Comanda.ENDGAME;
                string guanyador;

                //empat
                if (mans[0].Valor == mans[1].Valor)
                {
                    cadena[1] = Resultat.EMPAT;
                    guanyador = Encoding.UTF8.GetString(cadena);
                }

                else //guanyador
                {
                    cadena[1] = Resultat.VICTORIA;
                    guanyador = Encoding.UTF8.GetString(cadena) + mans[0].Usuari;
                }

                Sockets.Broadcast(guanyador);

                Sockets.Broadcast("Rànquing de mans: ");
                int pos = 0;
                foreach (MaPoker ma in mans)
                {
                    Sockets.Broadcast(++pos + ") " + ma.Usuari + ": " + ma.ToString() + " -> " + ma.GetResultat(true));
                }
                RestartGame();
            }
        }
        private static bool PartidaIniciable()
        {
            return (!baralla.EsBuida() && Sockets.Count >= MIN_JUGADORS && Sockets.Count <= MAX_JUGADORS
                && totalPreparats == Sockets.Count && !SocketHandler.PartidaIniciada);
            //&& totalPreparats == Sockets.Count && timeoutTimer == null && !SocketHandler.PartidaIniciada);
        }
        public HttpResponseMessage Get(string nom)
        {
            // La crida al websocket serà del tipus   ws://host:port/api/websocket?nom=Pere
            HttpContext.Current.AcceptWebSocketRequest(new SocketHandler(nom));
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }
        internal class SocketHandler : WebSocketHandler
        {
            private string _nom;
            public static bool PartidaIniciada { get; set; }
            public SocketHandler(string nom)
            {
                _nom = nom;
            }

            //Entrada de jugadors
            public override void OnOpen()
            {
                if (PartidaIniciada)
                {
                    byte[] msgOut = new byte[] { Comanda.ROOMFULL };
                    Send(msgOut);
                    Send("La partida ja ha començat. Si us plau, esperi que s'acabi la partida.");
                    StartTimeOutTimer();
                    _nom = null;
                }
                else
                {
                    if (Sockets.Count < MAX_JUGADORS && !PartidaIniciada)
                    {
                        //Notificar a tothom la incorporació i donar-li la benvinguda
                        Sockets.Add(this);
                        Send("Benvingut a la partida " + _nom);
                        Sockets.Broadcast(_nom + " s'ha afegit a la partida.");
                        SendObertureCards();
                    }
                    else
                    {
                        byte[] msgOut = new byte[] { Comanda.ROOMFULL };
                        Send(msgOut);
                        Send("La partida està plena.");
                    }
                }
            }

            //Serveix 2 cartes a cada jugador 
            private void SendObertureCards()
            {
                if (baralla != null && !baralla.EsBuida())
                {
                    byte[] cadena = new byte[2];
                    for (int i = 0; i < 2; i++)
                    {
                        Carta cartaEnviada = baralla.Repartir();
                        cartaEnviada.Usuari = _nom;

                        cadena[0] = Comanda.SENDCARD;
                        cadena[1] = Convert.ToByte(cartaEnviada.GetValueString());
                        string sended = Encoding.UTF8.GetString(cadena);
                        Send(sended);

                        barallaSignada.AddCarta(cartaEnviada);
                    }
                }
            }

            // OnMessage: rep missatges dels clients
            public override void OnMessage(string missatge)
            {
                if ((byte)missatge[0] == Comanda.PLAYER_READY)
                {
                    totalPreparats++;
                }
                if ((byte)missatge[0] == Comanda.PLAYER_UNREADY)
                {
                    totalPreparats--;
                }
                if ((byte)missatge[0] == Comanda.HANDFULL)
                {
                    handsFull++;
                    Sockets.Broadcast(_nom + " ha completat la mà. (Mans:" + handsFull + '/' + Sockets.Count + ')');
                }

                // Quan un usuari envia un missatge, cal que tothom el rebi                
                foreach (SocketHandler sh in Sockets)
                {
                    // gestio de comands dels usuaris
                    if (sh != this)
                    {
                        byte[] cadena = new byte[2];
                        string sended;

                        if (!missatge.StartsWith("/") && Comanda.EsInvalida(missatge))
                        {
                            sh.Send(_nom + ": " + missatge);
                        }
                        //Rep la peticio del client dient que no té carta del mig
                        //i el servidor la envia amb el mateix codi CMD_INCARD seguit de la carta
                        //mentre quedin cartes a la baralla...
                        if ((byte)missatge[0] == Comanda.INCARD && !baralla.EsBuida())
                        {
                            cartaMig = baralla.Repartir();
                            cadena[0] = Comanda.INCARD;
                            cadena[1] = Convert.ToByte(cartaMig.GetValueString());
                            sended = Encoding.UTF8.GetString(cadena);
                            Send(sended);
                        }

                        //Rep petició d'un client de que vol agafar la carta del mig
                        //if (cartaMig != null && Encoding.UTF8.GetBytes(missatge)[0] == Comanda.TAKECARD)
                        if (cartaMig != null && (byte)missatge[0] == Comanda.TAKECARD)
                        {
                            cadena[0] = Comanda.TAKECARD;
                            cadena[1] = FALSE;

                            if (cartaMig.Usuari == null)
                            { //petició acceptada
                                cartaMig.Usuari = _nom; //signa la carta amb l'usuari actual
                                cadena[1] = TRUE;
                                barallaSignada.AddCarta(cartaMig);
                                Sockets.Broadcast(_nom + " ha agafat la carta " + cartaMig);
                                //torna a posar a 0 el timer de cartes
                                StopTimeOutTimer();
                                StartTimeOutTimer();
                            }

                            //envia el missatge de petició acceptada o denegada:
                            Send(Encoding.UTF8.GetString(cadena));
                            if (cadena[1] == TRUE)
                            {
                                Sockets.Broadcast(Encoding.UTF8.GetString(new byte[] { Comanda.DELCARD }));
                            }
                        }
                    }
                    else //gestió de comandes que poden posar els clients amb prefix '/'
                    {
                        string plural = (Sockets.Count > 1) ? "s" : "";
                        string connectats = Sockets.Count + " usuari" + plural + " connectat" + plural + ": ";

                        if (missatge.Trim() == "/list")
                        {
                            List<string> usuaris = GetUsers();
                            Send(connectats);

                            foreach (string user in usuaris)
                            {
                                Send(user);
                            }
                        }
                        if (missatge.Trim() == "/clist")
                        {
                            List<string> usuaris = GetUsers();
                            int i = usuaris.Count;
                            foreach (string usuari in usuaris)
                            {
                                connectats += usuari;
                                i--;
                                if (i != 0)
                                {
                                    connectats += ", ";
                                }
                                else
                                {
                                    connectats += '.';
                                }
                            }

                            Send(connectats);
                        }
                        //if (missatge.Trim() == "/turbo on")
                        //{
                        //    timeoutTimer.Interval = 60;
                        //    Send("Velocitat del timeout accelerada.");
                        //}
                        //if (missatge.Trim() == "/turbo off")
                        //{
                        //    timeoutTimer.Interval = CARD_TIMEOUT;
                        //    Send("Velocitat del timeout normal.");
                        //}
                    }
                }
            }

            public List<string> GetUsers()
            {
                List<string> usuaris = new List<string>();
                if (Sockets != null)
                {
                    foreach (SocketHandler lCon in Sockets)
                    {
                        usuaris.Add(lCon._nom);
                    }
                    usuaris = usuaris.OrderBy(a => a).ToList();
                }
                return usuaris;
            }

            public override void OnClose()
            {
                foreach (SocketHandler sh in Sockets)
                {
                    if (_nom != null && sh != this)
                    {
                        sh.Send(_nom + " ha abandonat el grup.");
                    }
                }
                if (barallaSignada != null)
                {   //les cartes que tenia el jugador passen al munt
                    foreach (Carta c in barallaSignada.GetPaquet())
                    {
                        if (c.Usuari != null && c.Usuari.Equals(_nom))
                            c.Usuari = null;
                    }
                }

                Sockets.Remove(this); ;
            }
        }
    }
}
