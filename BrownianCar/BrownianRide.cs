using System;
using System.Collections.Generic;

namespace BrownianCar
{
    class BrownianRide
    {

        public static void GoForward(Grid grid, int stepCount, int start_x, int start_y)
        {
            // Go

        }

        public static void GoBackward(Grid grid, int stepCount, int end_x, int end_y)
        {
            // Go
        }

        private static void Go(Grid grid, int stepCount, int x, int y, Func<Cell, float> getProbability)
        {

            var history = CreateHistory(grid.rows, grid.columns);
            var stack = new List<State>()
                    { new State(0, grid.GetCell(x, y), 1f) };
            while (stack.Count > 0)
            {
                var state = stack[stack.Count-1];
                stack.RemoveAt(stack.Count - 1);
                if (state.step < stepCount)
                {
                    stack = MoveAlongTheEdges(stack, state);
                }
                else
                {
                    history = UpdateHistory(history, state);
                }
            }

        }

        private static List<State> MoveAlongTheEdges(List<State> stack, State state)
        {
            // TODO:
            return stack;
        }

        private static float[][] CreateHistory(int rows, int columns)
        {
            var history = new float[rows][];
            for (var i = 0; i < rows; i++)
                history[i] = new float[columns];
            return history;
        }

        private static float[][] UpdateHistory(float[][] history, State state)
        {
            var cellHistory = history[state.cell.x][state.cell.y];
            history[state.cell.x][state.cell.y] = cellHistory + state.probability;
            return history;
        }
    }
}
