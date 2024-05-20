using GameOfLife.Models;

namespace GameOfLife.Contracts
{
    public interface IGameOfLife
    {
        public List<Cell> GetField();

        public Size GetFieldSize();

        public void InitField(int? width = null, int? height = null);

        public void NextGen();
    }
}
