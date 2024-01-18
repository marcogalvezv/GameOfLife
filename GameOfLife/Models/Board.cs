using System.Data;

namespace GameOfLife.Models
{
    public class Board
    {
        public int[,] Cells { get; set; }
        public int[,] NextCells { get; set; }
        public int numberOfRows { get; set; }
        public int numberOfColumns { get; set; }
        public Board(int numberOfRows, int numberOfColumns) 
        {
            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;
            //adding an extra column with 0, as dead values
            Cells = new int[numberOfRows + 2, numberOfColumns + 2];
            NextCells = new int[numberOfRows + 2, numberOfColumns + 2];
            for (int i = 0; i <= numberOfRows; i++)
            {
                for (int j = 0; j <= numberOfColumns; j++)
                {
                    Cells[i, j] = 0;
                    NextCells[i, j] = 0;
                }
            }
         }
        public void InitRandomBoard()
        {
            for (int i= 1;i <= numberOfRows; i++)
            {
                for (int j = 1; j <= numberOfColumns; j++)
                {
                    //Random gen = new Random();
                    //int prob = gen.Next(100);                     
                    //Cells[i,j]= (prob < 80)?1:0;
                    Cells[i, j] = 1;
                }
            }
        }

        public int CountLiveNeighbors(int row, int column)
        {

            var liveNeighbors = 0;
            for (int i = -1; i < 2; i++) 
            {
                for (int j = -1; j < 2; j++)
                {
                    liveNeighbors += Cells[row+i, column+j];
                }
            }
            liveNeighbors--;
            return liveNeighbors;
        }

        public void EvaluateBoard()
        {
            for (int i = 1; i <= numberOfRows; i++)
            {
                for (int j = 1; j <= numberOfColumns; j++)
                {
                    var liveNeighbors = CountLiveNeighbors(i, j);
                    if (Cells[i, j] == 1 && liveNeighbors < 2)
                    {
                        NextCells[i, j] = 0;
                    }
                    else if (Cells[i, j] == 1 && (liveNeighbors == 2 || liveNeighbors == 3))
                    {
                        NextCells[i, j] = 1;
                    }
                    else if (Cells[i, j] == 1 && liveNeighbors > 3)
                    {
                        NextCells[i, j] = 0;
                    }
                    else if (Cells[i, j] == 0 && liveNeighbors == 3)
                    {
                        NextCells[i, j] = 1;
                    }


                    //NextCells[i, j] = CountLiveNeighbors(i, j) > 2 ? 1 : 0;

                }

            }
        }

    }
}
