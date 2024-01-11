using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioBusCrud.Models
{
    public partial class Linia
    {
        public Linia(string nom, string descripcio)
        {
            this.nom = nom;
            this.descripcio = descripcio;
        }
        public override string ToString()
        {
            return nom + ": " + descripcio;
        }
    }
}
