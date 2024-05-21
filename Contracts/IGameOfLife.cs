using GameOfLife.Models;

namespace GameOfLife.Contracts
{
    public interface IGameOfLife
    {
        public Field GetField();

        public void InitField(int? width = null, int? height = null);

        public void NextGen();
    }
}
