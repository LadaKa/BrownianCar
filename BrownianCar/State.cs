namespace BrownianCar
{
    class State
    {
        internal int step;
        internal Cell cell;
        internal RationalNumber probability;

        internal State(int step, Cell cell, RationalNumber probability)
        {
            this.step = step;
            this.cell = cell;
            this.probability = probability;
        }
    }
}
