using GameOfLife.Models;

namespace GameOfLife.DTOs
{
    public class FieldGetDto
    {
        public required List<Cell> Cells { get; set; }
        public required Size Size { get; set; }
    }
}
