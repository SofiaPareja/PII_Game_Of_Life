using System;
using System.Text;
using System.Threading;

/// <summary>
/// Esta clase Tablero tiene la responsabilidad de imprimir en la consola el juego.
/// Tiene como colaborador a LogicaJuego.
/// </summary>
namespace PII_Game_Of_Life
{
    public class Tablero
    {
        public  bool[,] b {get; set;}
        public  int Width {get; set;}
        public  int Height {get; set;}
        
        public Tablero(LogicaJuego juego)
        {
            this.b = juego.GameBoard;
            this.Width = juego.BoardWidth;
            this.Height = juego.BoardHeight;
        }
        public void Jugar(LogicaJuego juego)
        {

            while (true)
            {
                Console.Clear();
                StringBuilder s = new StringBuilder();
                for (int y = 0; y<this.Height;y++)
                {
                    for (int x = 0; x<this.Width; x++)
                    {
                        if(this.b[x,y])
                        {
                            s.Append("|X|");
                        }
                        else
                        {
                            s.Append("___");
                        }
                    }
                    s.Append("\n");
                }
                Console.WriteLine(s.ToString());
                juego.Juego();
                Thread.Sleep(300);
            }
        }    
    }

}