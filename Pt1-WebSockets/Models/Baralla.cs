using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pt1_WebSockets.Models
{
    public class Baralla
    {
        private List<Carta> _paquet;
        public int Posicio { get; set; }

        public Baralla()
        {
            _paquet = new List<Carta>();

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    _paquet.Add(new Carta(j, i));
                }
            }
            Remenar();
        }
        public Baralla(List<Carta> paquet)
        {
            _paquet = paquet.ToList();
        }

        public void Remenar()
        {
            var rnd = new Random();
            _paquet = _paquet.OrderBy(c => rnd.Next()).ToList();
        }

        public Carta Repartir()
        {
            Carta carta = null;
            if (Posicio < _paquet.Count)
            {
                carta = _paquet[Posicio++];
            }
            return carta;
        }

        public void SetPaquet(List<Carta> munt)
        {
            if (munt != null)
            {
                _paquet = munt.ToList(); // .ToList() perquè volem una còpia element a element i no el mateix objecte
                Posicio = 0;
            }
        }
        public void AddPaquet(List<Carta> munt)
        {
            if (munt != null)
            {
                if (_paquet == null)
                {
                    _paquet = new List<Carta>();
                }                                
                _paquet.AddRange(munt.ToList());              
            }
        }
        public List<Carta> GetPaquet()
        {
            return _paquet;
        }
        public void AddCarta(Carta carta)
        {
            _paquet.Add(carta);
        }
        public void EsborraCarta(Carta carta)
        {
            _paquet.Remove(carta);
        }
        public bool EsBuida()
        {
            return Posicio == _paquet.Count;
        }
        public int Size()
        {
            return _paquet.Count;
        }
        public void Clear()
        {
            _paquet.Clear();
        }
    }
}