using System;
/// <summary>
/// La clase LogicaJuego tiene la responsabilidad de establecer el funcionamiento del juego y de crear el nuevo tablero.
/// Tiene como colaborador a LeerArchivo  y colabora con la clase Tablero.
/// </summary>
namespace PII_Game_Of_Life
{
    public class LogicaJuego
    {
        public  bool[,] GameBoard {get; set;}
        public  int BoardWidth {get; set; }
        public int BoardHeight {get; set;}
        public  bool[,] Cloneboard {get; set;}

        public  LogicaJuego(LeerArchivo board)
        {
            this.GameBoard = board.Board;
            this.BoardWidth = this.GameBoard.GetLength(0);
            this.BoardHeight = this.GameBoard.GetLength(1);
            this.Cloneboard = new bool[this.BoardWidth, this.BoardHeight];
        }    


        public bool[,] Juego()
        {
            for (int x = 0; x < this.BoardWidth; x++)
            {
                for (int y = 0; y < this.BoardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {
                            if(i>=0 && i<this.BoardWidth && j>=0 && j < this.BoardHeight && this.GameBoard[i,j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if(this.GameBoard[x,y])
                    {
                        aliveNeighbors--;
                    }
                    if (this.GameBoard[x,y] && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        this.Cloneboard[x,y] = false;
                    }
                    else if (this.GameBoard[x,y] && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        this.Cloneboard[x,y] = false;
                    }
                    else if (!this.GameBoard[x,y] && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        this.Cloneboard[x,y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        this.Cloneboard[x,y] = this.GameBoard[x,y];
                    }
                }
            }
            this.GameBoard = this.Cloneboard;
            this.Cloneboard = new bool[this.BoardWidth, this.BoardHeight];
            return this.GameBoard;
        }
    }
}
