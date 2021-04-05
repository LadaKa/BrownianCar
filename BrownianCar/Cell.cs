using System.Collections.Generic;

namespace BrownianCar
{
    class Cell
    {
        private float neighboursProbability;
        private List<Cell> neighbours = new List<Cell>();
        internal int x;
        internal int y;

        internal Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal void AddNeighbour(Cell neighbour)
        {
            neighbours.Add(neighbour);
        }

        internal void SetNeighboursProbability()
        {
            neighboursProbability = 1f / neighbours.Count;
        }

        internal float GetNeighbourBackwardProbability(Cell neighbour)
        {
            return neighbour.neighboursProbability;
        }
    }
}
