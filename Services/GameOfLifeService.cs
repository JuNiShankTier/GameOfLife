using GameOfLife.Contracts;
using GameOfLife.Extensions;
using GameOfLife.Models;

namespace GameOfLife.Services
{
    public class GameOfLifeService : IGameOfLife
    {
        public Field Field { get; private set; } = new();

        public Field GetField() => Field;

        public void InitField(int? width, int? height)
        {
            Field.InitField(width, height);
        }

        public void NextGen()
        {
            foreach (Cell cell in Field.Cells)
            {
                var livingNeighbours = Field.CountLivingNeighbouringCells(cell);
                cell.RuleOfSolitude(livingNeighbours)
                    .RuleOfOverpopulation(livingNeighbours)
                    .RuleOfSurvivor(livingNeighbours)
                    .RuleOfCreation(livingNeighbours);
            }
        }
    }
}
