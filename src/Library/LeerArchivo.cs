using System.IO;
/// <summary>
/// La clase LeerArchivo tiene la responsabilidad de crear la matriz a partir del archivo  de texto.
/// </summary>
namespace PII_Game_Of_Life
{
    public class LeerArchivo
        {
        public  string Url {get; set;}
        public  string Content {get; set;}
        public  string[] ContentLines {get;set;}
        public  bool[,] Board {get; set;} 
        // public LeerArchivo(string archivo) 
        // {
        //     this.Url = @archivo;
        //     this.Content = File.ReadAllText(this.Url);
        //     this.ContentLines = this.Content.Split('\n');
        //     this.Board = new bool[this.ContentLines.Length, this.ContentLines[0].Length];
        // }
        
        public LeerArchivo(string archivo)
        {
            this.Url = @archivo;
            this.Content = File.ReadAllText(this.Url);
            this.ContentLines = this.Content.Split('\n');
            this.Board = new bool[this.ContentLines.Length, this.ContentLines[0].Length];
            for (int  y=0; y<this.ContentLines.Length;y++)
            {
                for (int x=0; x<this.ContentLines[y].Length; x++)
                {
                    if(this.ContentLines[y][x]=='1')
                    {
                        this.Board[x,y]=true;
                    }
                }
            }
            //return this.Board;
        }

        
    }
}