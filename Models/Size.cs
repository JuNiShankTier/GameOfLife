namespace GameOfLife.Models
{
    public class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int GetSize() => (Width * Height);
    }
}
