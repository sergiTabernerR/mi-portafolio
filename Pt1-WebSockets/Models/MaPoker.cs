/* 
 * Classe MaPoker que calcula la puntuació d'una mà de Poker
 * 
 * Info sobre jugades (Viquipèdia): https://ca.wikipedia.org/wiki/M%C3%A0_de_p%C3%B2quer
 * 
 * versió 1.0
 * 
 * Autors: Jesús Zafra i Sergi Taberner 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pt1_WebSockets.Models
{
    public class MaPoker
    {
        private readonly List<Carta> _ma;
        public double Valor { get; set; }
        private int _codiJugada;
        public string Usuari { get; set; }
        
        public static string[] nomJugada =
        {
            "carta més alta", "parella", "doble parella", "trio", "escala", "color",
            "full", "pòquer", "escala de color", "escala reial"
        };
        public abstract class Jugada
        {
            public const byte ESCALA_REIAL = 9; //"Royal flush"
            public const byte ESCALA_COLOR = 8; //"Straight flush"
            public const byte POKER = 7; //"Four of a kind"
            public const byte FULL = 6; //"Full house"
            public const byte COLOR = 5; //"Flush"
            public const byte ESCALA = 4; //"Straight"
            public const byte TRIO = 3; //"Three of a kind"
            public const byte DOBLE_PARELLA = 2; //"Two pairs"
            public const byte PARELLA = 1; //"Pair"
            public const byte CARTA_MES_ALTA = 0; //"Bust / Highest card"
        }
        public MaPoker()
        {                        
            _ma = new List<Carta>();
        }
        public MaPoker(string usuari) : this()
        {
            Usuari = usuari;
        }
        public MaPoker(List<Carta> paquet)
        {
            if (paquet != null)
            {
                if (paquet.Count > 0)
                    Usuari = paquet[0].Usuari;
                _ma = paquet;
                Avalua();
            }
        }
        public void AfegirCarta(Carta carta)
        {
            _ma.Add(carta);            
        }
        public int TotalCartes()
        {
            if (_ma == null)
                return 0;
            return _ma.Count;
        }
        //Retorna el nombre d'interconnexions consecutives d'una Cara entrada        
        private int ConsecutiusDe(int numero)
        {
            int con = 0; // connexions
            foreach (Carta carta in _ma)
            {
                if ((carta.Cara == numero + 1) || (carta.Cara == numero - 1))
                    con++;
            }
            return con;
        }
        //Informa si la mà té o no Cares duplicades
        public bool TeDuplicats()
        {
            var histFreq = _ma.GroupBy(a => a.Cara);
            foreach (var freq in histFreq)
            {
                if (freq.Count() > 1) return true;
            }
            return false;
        }
        //Mètode que determina si la mà conté una escala;
        //És a dir, cinc cartes amb les seves cares en progressió consecutiva
        //TO DO: Fer el mètode recursiu per tractar els cassos AS=1, AS=14
        public bool EsEscala()
        {
            List<Carta> ma = _ma.OrderBy(a => a.Cara).ToList();
            int cons = 0; // connexions (consecutivitat)
            //comprovacions per una escala menor
            for (int i = 0; i < _ma.Count; i++)
            {
                cons += ConsecutiusDe(_ma[i].Cara);
            }
            if (cons >= 8 && !TeDuplicats())
            {
                return true;
            }
            else // ...i si l'As valgués 14?
            {   //comprovacions per una escala major [10, J, K, Q, A]
                if (ma[0].Cara == 1)
                {
                    ma[0].Cara = 14;
                    cons = 0;
                    for (int i = 0; i < ma.Count; i++)
                    {
                        cons += ConsecutiusDe(ma[i].Cara);
                    }
                    if (cons >= 8 && !TeDuplicats())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool EsEscalaReial()
        {
            List<Carta> ma = _ma.OrderBy(a => a.Cara).ToList();
            return ma[0].Cara == 1 && ma[ma.Count - 1].Cara == 13 && !TeDuplicats() && EsColor();
        }
        public bool EsEscalaColor()
        {
            return EsEscala() && EsColor();
        }
        public bool EsColor()
        {
            var grp = _ma.GroupBy(c => c.Pal);
            return grp.Count() == 1;
        }

        public void Avalua()
        {
            var grp = _ma.GroupBy(c => c.Cara);
            var histograma = new Dictionary<int, int>();
            List<double> valors = new List<double>();

            foreach (var fCares in grp)
            {
                //Console.WriteLine("{0}:{1}", fCares.Key, fCares.Count());
                histograma[fCares.Key] = fCares.Count();
            }

            var hist = histograma.OrderByDescending(a => a.Value);
            //foreach (KeyValuePair<int, int> valor in hist)
            //{
            //    Console.WriteLine(valor);
            //}
            var maxVal = histograma.Values.Max();
            if (hist.Count() == 5 && maxVal == 1)
            {
                if (EsEscalaReial())
                {
                    _codiJugada = Jugada.ESCALA_REIAL;
                }
                else if (EsEscalaColor())
                {
                    _codiJugada = Jugada.ESCALA_COLOR;
                }
                else if (EsColor())
                {
                    _codiJugada = Jugada.COLOR;
                }
                else if (EsEscala())
                {
                    _codiJugada = Jugada.ESCALA;
                }
                else
                {
                    _codiJugada = Jugada.CARTA_MES_ALTA;
                }
            }
            if (hist.Count() == 2 && maxVal == 4)
            {
                _codiJugada = Jugada.POKER;
            }
            if (hist.Count() == 2 && maxVal == 3)
            {
                _codiJugada = Jugada.FULL;
            }
            if (hist.Count() == 3 && maxVal == 3)
            {
                _codiJugada = Jugada.TRIO;
            }
            if (hist.Count() == 3 && maxVal == 2)
            {
                _codiJugada = Jugada.DOBLE_PARELLA;
            }
            if (hist.Count() == 4 && maxVal == 2)
            {
                _codiJugada = Jugada.PARELLA;
            }

            valors.Add(_codiJugada);

            foreach (KeyValuePair<int, int> valor in hist)
            {
                valors.Add(valor.Key == 1 ? 14 : valor.Key);
            }

            ProcHistograma(valors);
            //Console.WriteLine("La mà té \"{0}\" amb una puntuació de {1} punts.", GetNomJugada(), _valor);
        }
        private void ProcHistograma(List<double> valors)
        {
            if (valors != null && valors.Count > 0)
            {
                int exp = 4;
                int i = 0;
                Valor = 0;
                while (i < valors.Count)
                {
                    Valor += Math.Pow(10, exp) * valors[i];
                    exp -= 2;
                    i++;
                }
            }
        }
        public string GetNomJugada()
        {
            return nomJugada[_codiJugada];
        }
        public int GetCodiJugada()
        {
            return _codiJugada;
        }
        //mostra llista de cartes amb els seus noms
        public override string ToString()
        {
            string cartes = "[";
            int i = 0;
            foreach (Carta c in _ma.OrderBy(a => a.Cara))
            {
                cartes += c.ToString() + (i == _ma.Count - 1 ? "]" : "");
                i++;
            }
            return cartes;
        }
        public string GetResultat(bool ambPunts = false)
        {
            string detall = ambPunts == true ? "; " + Valor + " punts." : "";
            return GetNomJugada() + detall;
        }

    }
}