
namespace BrownianCar
{
    class Grid
    {

        private Cell[][] cells;
        internal int rows;
        internal int columns;

        public Grid(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            CreateCells();
            AddAllNeighbours();
            SetNeighboursProbabilities();
        }

        private void CreateCells()
        {
            cells = new Cell[rows][];
            for (var i = 0; i < rows; i++)
            {
                cells[i] = new Cell[columns];
                for (var j = 0; j < columns; j++)
                    cells[i][j] = new Cell(i,j);
            }
        }

        private void AddAllNeighbours()
        {
            // loop 
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < columns; j++)
                {
                    AddNeighbours(cells[i][j], cells[i][j]);
                }

            // vertical edge
            for (var i = 0; i < rows - 1; i++)
                for (var j = 0; j < columns; j++)
                {
                    AddNeighbours(cells[i][j], cells[i+1][j]);
                }

            // horizontal edge
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < columns - 1; j++)
                {
                    AddNeighbours(cells[i][j], cells[i][j+1]);
                }

        }

        private void AddNeighbours(Cell neighbour_1, Cell neighbour_2)
        {
            neighbour_1.AddNeighbour(neighbour_2);
            neighbour_2.AddNeighbour(neighbour_1);
        }

        private void SetNeighboursProbabilities()
        {
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < columns; j++)
                    cells[i][j].SetNeighboursProbability();
        }

        internal Cell GetCell(int rows, int columns)
        {
            return cells[rows][columns];
        }
    }
}
