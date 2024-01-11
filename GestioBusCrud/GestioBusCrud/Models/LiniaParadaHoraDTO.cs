using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioBusCrud.Models
{
    public class LiniaParadaHoraDTO
    {
        public int Pos { get; set; }
        public int Id { get; set; }
        public string Nom { get; set; }       
                
        public LiniaParadaHoraDTO(LiniaParadaHora lph)
        {
            var parada = lph.Parada;
            Id = parada.id;
            Nom = parada.nom;
            Pos = lph.numeroParada;
        }
    }
}
