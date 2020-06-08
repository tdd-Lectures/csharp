using System;

namespace ConsoleApp1
{
    // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
    // Any live cell with two or three live neighbours lives on to the next generation.
    // Any live cell with more than three live neighbours dies, as if by overcrowding.
    // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
    public static class Conways
    {
        public static Cell Execute(Cell cell, int neighbours)
        {
            if ((cell == Cell.Alive && neighbours == 2) || neighbours == 3) return Cell.Alive;

            return Cell.Dead;
        }
    }

    public enum Cell
    {
        Alive,
        Dead,
    }
}
