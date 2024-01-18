namespace GameOfLife.Models
{
    public class Cell
    {
        public bool IsLive { get; set; } = false;
        public List<Cell> Neighborhoods { get; set; }
    }
}
