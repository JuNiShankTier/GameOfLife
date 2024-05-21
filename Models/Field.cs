using GameOfLife.Enums;
using GameOfLife.Helpers;

namespace GameOfLife.Models
{
    public class Field
    {
        public List<Cell> Cells { get; private set; } = [];
        public Size Size { get; private set; } = new();

        public void InitField(int? width, int? height)
        {
            Size.Width = width ?? 5;
            Size.Height = height ?? 5;
            Cells = Enumerable.Range(0, Size.GetSize()).Select(index =>
                        new Cell(
                            FieldHelper.GetXCoordinateFromIndex(index, Size.Width),
                            FieldHelper.GetYCoordinateFromIndex(index, Size.Width),
                            EnumHelper.GetRandomEnumValue<GameState>()))
                    .ToList();
        }

        public int CountLivingNeighbouringCells(Cell cell) => GetNeighbouringCells(cell).Where(c => c?.State == GameState.Alive).Count();

        public List<Cell?> GetNeighbouringCells(Cell cell)
        {
            return new()
            {
                GetTopLeftNeighbourCell(cell),
                GetTopCenterNeighbourCell(cell),
                GetTopRightNeighbourCell(cell),
                GetMiddleLeftNeighbourCell(cell),
                GetMiddleRightNeighbourCell(cell),
                GetBottomLeftNeighbourCell(cell),
                GetBottomCenterNeighbourCell(cell),
                GetBottomRightNeighbourCell(cell),
            };
        }

        public Cell? GetTopLeftNeighbourCell(Cell cell) => GetCell(cell.PosX - 1, cell.PosY - 1);
        public Cell? GetTopCenterNeighbourCell(Cell cell) => GetCell(cell.PosX, cell.PosY - 1);
        public Cell? GetTopRightNeighbourCell(Cell cell) => GetCell(cell.PosX + 1, cell.PosY - 1);
        public Cell? GetMiddleLeftNeighbourCell(Cell cell) => GetCell(cell.PosX - 1, cell.PosY);
        public Cell? GetMiddleRightNeighbourCell(Cell cell) => GetCell(cell.PosX + 1, cell.PosY);
        public Cell? GetBottomLeftNeighbourCell(Cell cell) => GetCell(cell.PosX - 1, cell.PosY + 1);
        public Cell? GetBottomCenterNeighbourCell(Cell cell) => GetCell(cell.PosX, cell.PosY + 1);
        public Cell? GetBottomRightNeighbourCell(Cell cell) => GetCell(cell.PosX + 1, cell.PosY + 1);

        public Cell? GetCell(int posX, int posY) => CheckValidCoordinates(posX, posY) ? Cells[FieldHelper.GetIndexValueFromCoordinates(posX, posY, Size.Width)] : null;

        private bool CheckValidCoordinates(int x, int y) => FieldHelper.IsCoordinateValid(x, Size.Width) && FieldHelper.IsCoordinateValid(y, Size.Height);
    }
}
