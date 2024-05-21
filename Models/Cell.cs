using GameOfLife.Enums;

namespace GameOfLife.Models
{
    public class Cell(int initPosX = 0, int initPosY = 0, GameState initialState = GameState.Dead)
    {
        public int PosX { get; init; } = initPosX;
        public int PosY { get; init; } = initPosY;
        public GameState State { get; private set; } = initialState;

        public void Die() => State = GameState.Dead;
        public void Birth() => State = GameState.Alive;
        public bool IsAlive() => State == GameState.Alive;
    }
}
