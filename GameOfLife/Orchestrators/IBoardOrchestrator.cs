using GameOfLife.Models;

namespace GameOfLife.Orchestrators
{
    public interface IBoardOrchestrator
    {
        public Board Evaluate();
        public Board GetState(int index);
    }
}
