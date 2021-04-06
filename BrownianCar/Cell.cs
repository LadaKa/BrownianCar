using System.Collections.Generic;

namespace BrownianCar
{
    class Cell
    {
        private RationalNumber neighboursProbability;
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
            neighboursProbability = new RationalNumber(1, neighbours.Count);
        }

        internal RationalNumber GetNeighboursProbability()
        {
            return neighboursProbability;
        }

        internal List<Cell> GetNeighbours() 
        {
            return neighbours; 
        }
    }
}
