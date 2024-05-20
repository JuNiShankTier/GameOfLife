using GameOfLife.Contracts;
using GameOfLife.Enums;
using GameOfLife.Helpers;
using GameOfLife.Models;

namespace GameOfLife.Services
{
    public class GameOfLifeService : IGameOfLife
    {
        public List<Cell>? Field { get; private set; }
        public Size FieldSize { get; private set; } = new();

        public List<Cell> GetField() => Field ??= [];

        public Size GetFieldSize() => FieldSize;

        public void InitField(int? width, int? height)
        {
            FieldSize.Width = width ?? 5;
            FieldSize.Height = height ?? 5;
            Field = Enumerable.Range(0, FieldSize.Width * FieldSize.Height).Select(index =>
                    new Cell((index % FieldSize.Width), ((index - (index % FieldSize.Width)) / FieldSize.Width), EnumHelper.GetRandomEnumValue<GameState>())
                ).ToList();
        }

        public void NextGen()
        {
            // Todo
        }
    }
}
