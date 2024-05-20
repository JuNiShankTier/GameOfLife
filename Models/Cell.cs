using GameOfLife.Enums;

namespace GameOfLife.Models
{
    public class Cell(int initPosX = 0, int initPosY = 0, GameState initialState = GameState.Dead)
    {
        public int posX { get; init; } = initPosX; 
        public int posY { get; init; } = initPosY;
        public GameState state { get; private set; } = initialState;

        public void Die() { state = GameState.Dead; }
        public void Birth() { state = GameState.Alive; }
    }
}
