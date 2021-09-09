﻿using System;

namespace PII_Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            LeerArchivo archivo = new LeerArchivo(@"../../assets/board.txt");
            LogicaJuego juego = new LogicaJuego(archivo);
            Tablero board = new Tablero(juego);
            board.Jugar(juego);
        }
    }
}
