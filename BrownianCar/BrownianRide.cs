using System;
using System.Collections.Generic;

namespace BrownianCar
{
    class BrownianRide
    {

        public static void GoForward(Grid grid, int stepCount, int start_x, int start_y)
        {
            var cell = grid.GetCell(start_x, start_y);
            var history = Go(grid, stepCount, cell, GetForwardProbability);
            PrintHistory(history);
        }

        public static void GoBackward(Grid grid, int stepCount, int end_x, int end_y)
        {
            var cell = grid.GetCell(end_x, end_y);
            var history = Go(grid, stepCount, cell, GetBackwardProbability);
            PrintHistory(history);
        }

        private static RationalNumber[][] Go(Grid grid, int stepCount, Cell firstCell, Func<Cell, Cell, RationalNumber> getProbability)
        {

            var history = CreateHistory(grid.rows, grid.columns);
            var stack = new List<State>()
                    { new State(0, firstCell, new RationalNumber(1, 1)) };
            while (stack.Count > 0)
            {
                var state = stack[stack.Count-1];
                stack.RemoveAt(stack.Count - 1);
                if (state.step < stepCount)
                {
                    stack = MoveAlongTheEdges(stack, state, getProbability);
                }
                else
                {
                    history = UpdateHistory(history, state);
                }
            }
            return history;
        }

        private static List<State> MoveAlongTheEdges(List<State> stack, State state, Func<Cell, Cell, RationalNumber> getProbability)
        {
            var cell = state.cell;
            var nextStep = state.step + 1;
            foreach (var neighbour in state.cell.GetNeighbours())
            {
                var probability = RationalNumber.Multiply(state.probability, getProbability(cell, neighbour)); Console.WriteLine(probability);
                var nextState = new State(nextStep, neighbour, probability);
                stack.Add(nextState);
            }
            return stack;
        }

        private static RationalNumber[][] CreateHistory(int rows, int columns)
        {
            var history = new RationalNumber[rows][];
            for (var i = 0; i < rows; i++)
            {
                history[i] = new RationalNumber[columns];
                for (var j = 0; j < columns; j++)
                    history[i][j] = new RationalNumber(0, 1);
            }
            return history;
        }

        private static RationalNumber GetForwardProbability(Cell cell_1, Cell cell_2)
        {
            return cell_1.GetNeighboursProbability();
        }

        private static RationalNumber GetBackwardProbability(Cell cell_1, Cell cell_2)
        {
            // TODO: 
            return null;
        }

        private static RationalNumber[][] UpdateHistory(RationalNumber[][] history, State state)
        {
            var cellHistory = history[state.cell.x][state.cell.y];
            history[state.cell.x][state.cell.y] = RationalNumber.Add(cellHistory, state.probability);
            return history;
        }

        private static void PrintHistory(RationalNumber[][] history)
        {
            var sum = new RationalNumber(0,1);
            for (var i = 0; i < history.Length; i++)
            {
                var row = history[i];
                for (var j = 0; j < row.Length; j++)
                {
                    Console.Write(row[j] + "  ");
                    sum = RationalNumber.Add(sum, row[j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
