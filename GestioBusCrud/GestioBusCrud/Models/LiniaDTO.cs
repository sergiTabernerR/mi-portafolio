using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioBusCrud.Models
{
    public class LiniaDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public LiniaDTO(Linia l)
        {
            if (l != null)
            {
                Id = l.id;
                Nom = l.nom;
                Descripcio = l.descripcio;
            }
        }
        public override string ToString()
        {
            return Nom;
        }
    }
}
