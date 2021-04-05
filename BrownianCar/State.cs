namespace BrownianCar
{
    class State
    {
        internal int step;
        internal Cell cell;
        internal float probability;

        internal State(int step, Cell cell, float probability)
        {
            this.step = step;
            this.cell = cell;
            this.probability = probability;
        }
    }
}
