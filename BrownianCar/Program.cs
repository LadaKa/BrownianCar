namespace BrownianCar
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid(2, 3);
            BrownianRide.GoForward(grid, 1, 0, 0); 
        }
    }
}
