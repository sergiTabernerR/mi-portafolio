/* 
 * Classe Carta que simula una carta de Poker
 * 
 * versió 1.0
 * 
 * Autors: Jesús Zafra i Sergi Taberner
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Pt1_WebSockets.Models
{
    public class Carta
    {
        private readonly string[] CARA_SIMPLIFICAT =
            { "A", "2", "3", "4", "5",
            "6", "7", "8", "9", "10",
        "J", "Q", "K" };
        private readonly string[] PAL_SIMPLIFICAT =
            { "♦", "♣", "♠", "♥" };
        private readonly string[] PAL =
            { "Diamants", "Trèvols", "Piques", "Cors" };
        private readonly string[] CARA =
            { "As", "Dos", "Tres", "Quatre", "Cinc",
            "Sis", "Set", "Vuit", "Nou", "Deu",
        "Jack", "Quina", "Rei" };
        public string Dibuix { get; set; }
        public int Cara { get; set; }
        public int Pal { get; set; }
        public string Usuari { get; set; }
        public Carta() { }

        //Avís: Cara i Pal començen des de 1
        public Carta(int cara, int pal)
        {
            Cara = cara >= 14 ? 1 : cara;
            Pal = pal;
            Usuari = null;
            pal += 7;

            byte[] bytesDib = new byte[4];
            bytesDib[0] = 0xf0;
            bytesDib[1] = 0x9f;
            bytesDib[2] = pal > 9 ? (byte)0x82 : (byte)0x83;


            bytesDib[3] = (byte)(16 * pal + (cara > 11 ? cara + 1 : cara));

            Dibuix = Encoding.UTF8.GetString(bytesDib);
        }

        public string GetValues()
        {
            return "Cara=" + Cara + ", Pal=" + Pal;
        }

        // obté el valor de codi intern que representa una carta
        /*
                Console.WriteLine(162 & 0x0f); // cara
                Console.WriteLine(162 >> 4); // pal
        */
        public string GetValueString()
        {
            return "" + (16 * Pal + Cara);
        }

        public int GetValueInt()
        {
            return (16 * Pal + Cara);
        }
        public static Carta GetCarta(int codiInternCarta)
        {
            return new Carta(codiInternCarta & 0x0f, codiInternCarta >> 4);
        }
        public static int GetPal(string unicodeCarta)
        {
            if (unicodeCarta == null || Encoding.UTF8.GetBytes(unicodeCarta).Length < 3) return -1;
            return (Encoding.UTF8.GetBytes(unicodeCarta)[3] >> 4) - 7;
        }
        public string GetNom()
        {
            return CARA[Cara == 14 ? 1 - 1 : Cara - 1] + " de " + PAL[Pal - 1];
        }
        public override string ToString()
        {
            return CARA_SIMPLIFICAT[Cara == 14 ? 1 - 1 : Cara - 1] + PAL_SIMPLIFICAT[Pal - 1];
        }

    }
}