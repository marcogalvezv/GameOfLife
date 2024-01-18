using GameOfLife.Models;

namespace GameOfLife.Orchestrators
{
    public class BoardOrchestrator: IBoardOrchestrator
    {
        public Board CurrentBoard { get; set; }
        public List<Board> States { get; set; }
        public int numberOfRows { get; set; }
        public int numberOfColumns { get; set; }
        public BoardOrchestrator(int numberOfRows, int numberOfColumns)
        {
            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;           
            CurrentBoard = new Board(numberOfRows,numberOfColumns);
            States = new List<Board>();
            
           
            InitRandomBoard();

            States.Add(CurrentBoard);
        }
        public Board Evaluate()
        {
           
            var nextState = new Board(CurrentBoard.numberOfRows, numberOfColumns);
            for (int i = 1; i <= numberOfRows; i++)
            {
                for (int j = 1; j <= numberOfColumns; j++)
                {
                    var liveNeighbors = CountLiveNeighbors(i, j);
                    if (CurrentBoard.Cells[i, j] == 1 && liveNeighbors < 2)
                    {
                        nextState.Cells[i, j] = 0;
                    }
                    else if (CurrentBoard.Cells[i, j] == 1 && (liveNeighbors == 2 || liveNeighbors == 3))
                    {
                        nextState.Cells[i, j] = 1;
                    }
                    else if (CurrentBoard.Cells[i, j] == 1 && liveNeighbors > 3)
                    {
                        nextState.Cells[i, j] = 0;
                    }
                    else if (CurrentBoard.Cells[i, j] == 0 && liveNeighbors == 3)
                    {
                        nextState.Cells[i, j] = 1;
                    }

                }

            }
            States.Add(nextState);
            CurrentBoard = nextState;
            return nextState;
        }

        public int CountLiveNeighbors(int row, int column)
        {

            var liveNeighbors = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    liveNeighbors += CurrentBoard.Cells[row + i, column + j];
                }
            }
            liveNeighbors--;
            return liveNeighbors;
        }

        public Board GetState(int index)
        {
            return States[index];
        }

        public void InitRandomBoard()
        {
            for (int i = 1; i <= numberOfRows; i++)
            {
                for (int j = 1; j <= numberOfColumns; j++)
                {
                    Random gen = new Random();
                    int prob = gen.Next(100);
                    CurrentBoard.Cells[i, j] = (prob < 80) ? 1 : 0;
                    //CurrentBoard.Cells[i, j] = 1;
                }
            }
        }
    }
}
