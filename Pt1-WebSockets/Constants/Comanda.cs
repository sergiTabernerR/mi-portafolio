/*
 * Classe Comanda
 * 
 * Defineix els codis per facilitar la comunicació entre els clients i el servidor. 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Pt1_WebSockets.Models
{    
    public abstract class Comanda
    {
        public const byte SENDCARD       = 1; //s'envia una carta al client.
        public const byte REQINI         = 2; //peticio d'inici de la partida.
        public const byte ROOMFULL       = 3; //no poden entrar més jugadors.
        public const byte INCARD         = 4; //server envia la carta al mig.
        public const byte TAKECARD       = 5; //el client vol la INCARD.
        public const byte PLAYER_READY   = 6; //per controlar total jugadors connectats.        
        public const byte DELCARD        = 7; //server ordena que s'esborri la carta del mig.
        public const byte HANDFULL       = 8; //client informa que la seva mà es plena.
        public const byte ENDGAME        = 11; //fi de la partida, informa del campio o empat.
        public const byte PLAYER_UNREADY = 12; //jugador informa que no esta preparat encara
        public const byte GAMERUNNING    = 14; //server informa que el joc està jugant-se

        public static bool EsInvalida(string message)
        {
            return (byte)message[0] > 31
                || (byte)message[0] == 0x0d
                || (byte)message[0] == 0x0a;
        }
    }
}