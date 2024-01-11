using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioBusCrud.Views
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {          
            tbNomLinia.Focus();
            tbNomLinia.SelectionLength = 0;
            tbNomLinia.SelectionStart = tbNomLinia.Text.Length;
            base.OnShown(e);
        }
    }
}
