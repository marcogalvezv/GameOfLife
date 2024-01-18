using System.Data;

namespace GameOfLife.Models
{
    public class Board
    {
        public int[,] Cells { get; set; }
        //public int[,] NextCells { get; set; }
        public int numberOfRows { get; set; }
        public int numberOfColumns { get; set; }
        public Board(int numberOfRows, int numberOfColumns) 
        {
            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;
            //adding an extra column with 0, as dead values
            Cells = new int[numberOfRows + 2, numberOfColumns + 2];
            //NextCells = new int[numberOfRows + 2, numberOfColumns + 2];
            for (int i = 0; i <= numberOfRows; i++)
            {
                for (int j = 0; j <= numberOfColumns; j++)
                {
                    Cells[i, j] = 0;
                    //NextCells[i, j] = 0;
                }
            }
         }
       

       
        

    }
}
