using GestioBusCrud.Models;
using GestioBusCrud.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Controlador del CRUD de GestioBus 
*/
namespace GestioBusCrud.Controllers
{
    class Controller
    {
        private Form1 f;
        private readonly Repository r;

        private static readonly Font fontDejavuSans8 = new Font("Dejavu sans", 8);
        private static readonly Font fontHelveticaNow9 = new Font("Helvetica Now", 9);
        private static readonly Font fontHoraris = new Font("Helvetica Now", 12);

        private Font _defaultDgvFont = fontHelveticaNow9;
        private DataGridView _dgvLinies;
        private DataGridView _dgvParades;
        private DataGridView _dgvHoraris;

        public Controller()
        {
            r = new Repository();
            f = new Form1() { StartPosition = FormStartPosition.CenterScreen };

            Init();
            InitListeners();
            LoadData();

            Application.Run(f);
        }
        public void Init()
        {
            MessageBoxManager.Yes = "Sí";
            MessageBoxManager.Register();
            //MessageBoxManager.Unregister();
            _dgvLinies = InitDgv(f.dgvLinies, _defaultDgvFont);
            _dgvParades = InitDgv(f.dgvParades, _defaultDgvFont);
            _dgvHoraris = InitDgv(f.dgvHoraris, fontHoraris);
        }
        public void InitListeners()
        {
            //botons
            f.btClearLinia.Click += Buttons_Click;
            f.btInsLinia.Click += Buttons_Click;
            f.btUpdLinia.Click += Buttons_Click;
            f.btDelLinia.Click += Buttons_Click;
            f.btClearParada.Click += Buttons_Click;
            f.btInsParada.Click += Buttons_Click;
            f.btUpdParada.Click += Buttons_Click;
            f.btDelParada.Click += Buttons_Click;
            f.btInsHora.Click += Buttons_Click;
            f.btUpdHora.Click += Buttons_Click;
            f.btDelHora.Click += Buttons_Click;
            f.btLlocs.Click += Buttons_Click;

            //dgvs
            f.dgvLinies.SelectionChanged += Dgv_SelectionChanged;
            f.dgvLinies.Click += Dgv_SelectionChanged;
            f.dgvParades.SelectionChanged += Dgv_SelectionChanged;
            f.dgvParades.Click += Dgv_Click;
            f.dgvHoraris.SelectionChanged += Dgv_SelectionChanged;
            f.dgvHoraris.Click += Dgv_SelectionChanged;

            //TextBoxes
            f.tbPosParada.LostFocus += Tb_LostFocus;

        }

        private void Tb_LostFocus(object sender, EventArgs e)
        {
            var tb = sender as TextBox;

            //posParada ha de ser un nombre enter > 0 i <= totalParades+1
            if (tb.Name.Equals("tbPosParada"))
            {
                var linia = (LiniaDTO)_dgvLinies.SelectedRows[0].DataBoundItem;
                bool esEnter = int.TryParse(tb.Text, out int valorNumeric);
                if (!(esEnter && valorNumeric > 0 && valorNumeric <= r.GetParades(linia.Id).Count+1))
                {
                    //MessageBox.Show("La posició de la parada ha de ser un enter positiu > 0", "Error");
                    tb.Text = "";
                    //tb.Focus();
                }

            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.Name.Equals("dgvLinies") && dgv.SelectedRows.Count > 0)
            {
                var linia = dgv.SelectedRows[0].DataBoundItem as LiniaDTO;

                f.tbIdLinia.Text = linia.Id.ToString();
                f.tbNomLinia.Text = linia.Nom;
                f.tbDescLinia.Text = linia.Descripcio;
                f.tbNomLinia.Focus();
                f.tbNomLinia.SelectionLength = 0;
                f.tbNomLinia.SelectionStart = f.tbNomLinia.Text.Length;

                LoadParadesData(linia.Id);
            }

            if (dgv.Name.Equals("dgvParades"))
            {
                ClrParada();
                if (dgv.SelectedRows.Count > 0)
                    LoadParadaInfo();
            }

            if (dgv.Name.Equals("dgvHoraris") && dgv.SelectedRows.Count > 0)
            {
            }
        }
        private void Dgv_Click(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;

            if (dgv.Name.Equals("dgvParades") && dgv.SelectedRows.Count > 0)
            {                
                LoadParadaInfo();
                f.tbNomParada.Focus();
                f.tbNomParada.SelectionLength = 0;
                f.tbNomParada.SelectionStart = f.tbNomParada.Text.Length;
            }
        }
        private void LoadParadaInfo()
        {
            var parDTO = _dgvParades.SelectedRows[0].DataBoundItem as LiniaParadaHoraDTO;
            var parada = r.GetParada(parDTO.Id);
            if (parada != null)
            {
                f.tbIdParada.Text = parada.id.ToString();
                f.tbNomParada.Text = parada.nom;
                f.tbPosParada.Text = parDTO.Pos.ToString();

                var coord = parada.coord;
                if (coord != null && coord.Latitude != null && coord.Longitude != null)
                {
                    f.tbLatitud.Text = coord.Latitude.ToString();
                    f.tbLongitud.Text = coord.Longitude.ToString();
                }
            }
        }
        //Funcionalitats dels butons
        private void Buttons_Click(object sender, EventArgs e)
        {
            var bt = sender as Button;

            var idLinia = f.tbIdLinia.Text;
            var idParada = f.tbIdParada.Text;
            var nomParada = f.tbNomParada.Text;
            var nomLinia = f.tbNomLinia.Text;
            var descLinia = f.tbDescLinia.Text;
            LiniaDTO linia = null;
            LiniaParadaHoraDTO selParadaDTO = null;
            //Parada selParada = null;

            if (_dgvLinies.SelectedRows.Count > 0)
                linia = _dgvLinies.SelectedRows[0].DataBoundItem as LiniaDTO;
            if (_dgvParades.SelectedRows.Count > 0)
            {
                selParadaDTO = _dgvParades.SelectedRows[0].DataBoundItem as LiniaParadaHoraDTO;
                //selParada = r.GetParada(selParadaDTO.Id);
            }
            var oIdLinia = linia.Id;            

            if (bt.Name.Equals("btClearLinia"))
            {
                ClrLinia();
                f.tbNomLinia.Focus();
            }
            else if (bt.Name.Equals("btClearParada"))
            {
                ClrParada();
                f.tbPosParada.Focus();
            }

            //Inserció de nova Linia:
            else if (bt.Name.Equals("btInsLinia"))
            {
                if (idLinia != "")
                {
                    MessageBox.Show("No es pot inserir una linia especificant la Id: Crea un nou registre.", "Error!");
                    return;
                }
                else if (nomLinia == "" || descLinia == "")
                {
                    MessageBox.Show("No es pot inserir la nova linia, has d'omplir tots els camps!", "Error!");
                    return;
                }
                //inserta Linia                
                if (r.AddLinia(new Linia(nomLinia, descLinia)) == null)
                {
                    MessageBox.Show("No s'ha pogut inserir la linia", "Error intern");
                    return;
                }
                RefrescaDades();
            }
            //Inserta una nova Parada
            else if (bt.Name.Equals("btInsParada"))
            {
                if (idParada != "")
                {
                    MessageBox.Show("No es pot inserir una parada especificant la Id: Crea un nou registre.", "Error!");
                    return;
                }
                double.TryParse(f.tbLatitud.Text, out double lat);
                double.TryParse(f.tbLongitud.Text, out double lon);
                Parada p = new Parada
                {
                    nom = f.tbNomParada.Text,
                    coord = CreatePoint(lat, lon)
                };

                if (r.AddParada(p) == null)
                {
                    MessageBox.Show("No s'ha pogut inserir la parada", "Error intern");
                    return;
                }
                int.TryParse(f.tbPosParada.Text, out int posParada);

                LiniaParadaHora lph = new LiniaParadaHora();
                lph.idParada = p.id;
                lph.idLinia = linia.Id;
                lph.numeroParada = posParada;

                if (r.AddLiniaParadaHora(lph) == null)
                {
                    MessageBox.Show("No s'ha pogut inserir la parada", "Error intern");
                    return;
                }
                LoadParadesData(lph.idLinia);

            }
            //Actualització d'una Linia (nom i descripció):
            else if (bt.Name.Equals("btUpdLinia"))
            {
                //actualitza Linia
                if (r.UpdateLiniaNomDesc(oIdLinia, nomLinia, descLinia) == null)
                {
                    MessageBox.Show("No s'ha pogut modificar la linia", "Error intern");
                    return;
                }
                RefrescaDades();
            }
            //Actualitza una Parada           
            else if (bt.Name.Equals("btUpdParada"))
            {

            }
            //Esborrat de Linia (en cascada, amb confirmació):
            else if (bt.Name.Equals("btDelLinia"))
            {
                if (_dgvLinies.SelectedRows.Count > 0)
                {

                    var confirm = MessageBox.Show($"Segur que vols esborrar la línia '{nomLinia}' i totes les dades relacionades?",
                                         "Confirmació", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        //esborra Linia
                        if (!r.DelLinia(oIdLinia))
                        {
                            MessageBox.Show("No s'ha pogut esborrar la linia", "Error intern");
                            return;
                        }
                        RefrescaDades(false);
                    }
                }
            }
            // Esborrat de Parada (en cascada, amb confirmació):
            else if (bt.Name.Equals("btDelParada"))
            {
                if (_dgvParades.SelectedRows.Count > 0)
                {
                    var confirm = MessageBox.Show($"Segur que vols esborrar la parada '{nomParada}' i totes les dades relacionades?",
                                         "Confirmació", MessageBoxButtons.YesNo);                    
                    if (confirm == DialogResult.Yes)
                    {
                        //esborra parada
                        if (!r.DelParada(selParadaDTO.Id))
                        {
                            MessageBox.Show("No s'ha pogut esborrar la parada", "Error intern");
                            return;
                        }
                        RefrescaDades();
                    }
                }
            }
        }
        private void ClrLinia()
        {
            f.tbIdLinia.Text   = "";
            f.tbNomLinia.Text  = "";
            f.tbDescLinia.Text = "";
        }
        private void ClrParada()
        {
            f.tbIdParada.Text   = "";
            f.tbPosParada.Text  = "";
            f.tbNomParada.Text  = "";
            f.tbLatitud.Text    = "";
            f.tbLongitud.Text   = "";
        }

        //inicialitza un dgv amb una font i amb un estils de columnas definit
        private DataGridView InitDgv(DataGridView dgvSrc, Font dgvFont)
        {
            dgvSrc.DefaultCellStyle.Font              = dgvFont;
            dgvSrc.ColumnHeadersDefaultCellStyle.Font = dgvFont;
            dgvSrc.AutoSizeColumnsMode                = DataGridViewAutoSizeColumnsMode.Fill;

            return dgvSrc;
        }
        private void LoadData()
        {            
            //Carrega de les dades de Linies
            _dgvLinies.DataSource = r.GetLinias().Select(l => new LiniaDTO(l)).ToList();

            //amplada columnes:
            var dgvLiniesColId           = _dgvLinies.Columns["Id"];
            var dgvLiniesColNom          = _dgvLinies.Columns["Nom"];
            dgvLiniesColId.AutoSizeMode  = DataGridViewAutoSizeColumnMode.None;
            dgvLiniesColNom.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvLiniesColId.Width  = 40;
            dgvLiniesColNom.Width = 60;                                  
        }
        private void LoadParadesData(int idLinia)
        {
            _dgvParades.DataSource = r.GetParades(idLinia).Select(p => new LiniaParadaHoraDTO(p)).ToList();

            //amplada columnes:
            var dgvParadesColId = _dgvParades.Columns["Id"];
            var dgvParadesColPosicio = _dgvParades.Columns["Pos"];
            dgvParadesColId.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvParadesColPosicio.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvParadesColId.Width = 40;
            dgvParadesColPosicio.ToolTipText = "Posició relativa dins de la línia";
            dgvParadesColPosicio.HeaderText = "#";
            dgvParadesColPosicio.Width = 40;
        }

        //Actualitza dades dels dgv (substitueix posició punter de selecció a pos. anterior)
        //lastPos serveix perquè si s'esborra una linia la última línia no es pot recordar i tornar a ella.
        public void RefrescaDades(bool lastPos = true)
        {
            if (_dgvLinies.SelectedRows.Count > 0)
            {
                var dgvLiniesRow = _dgvLinies.SelectedRows[0].Index;

                if (_dgvLinies.SelectedRows.Count > 0)
                {
                    dgvLiniesRow = _dgvLinies.SelectedRows[0].Index;
                }

                LoadData();
                if (lastPos)
                {
                    _dgvLinies.CurrentCell = _dgvLinies.Rows[dgvLiniesRow].Cells[0]; // pos. header cell triangle
                    _dgvLinies.Rows[dgvLiniesRow].Selected = true; // reselecciona
                }
            }            
        }
        public static DbGeography CreatePoint(double lat, double lon, int srid = 4326)
        {
            string wkt = $"POINT({lon} {lat})";

            return DbGeography.PointFromText(wkt, srid);
        }
    }
}
