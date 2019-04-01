namespace ProblemSet01.Task_04
{
    using System.Collections.Generic;

    /// <summary>
    /// Class priveds method for spiral matrix traversal
    /// </summary>
    public class SpiralWalk
    {
        /// <summary>
        /// Spiral traversal of a matrix.
        /// At first goes from center to RIGHT, then each time turns clockwise.
        /// </summary>
        /// <param name="matrix">Matrix of type int</param>
        /// <returns>Sriral-traversed elements of the matrix</returns>
        public static int[] WalkThroughMatrix(int[,] matrix)
        {
            // stores items we walked through
            var result = new List<int>();
            int length = matrix.GetLength(1);
            int incrementRow = 1;
            int incrementColumn = incrementRow;
            int row = length / 2;
            int column = row;

            // adds first element explicitly
            result.Add(matrix[row, column]);

            // exit condition is to reach right top corner
            while (column != length - 1 || row != 0)
            {
                if (row == 0)
                {
                    for (int i = 0; i < length - 1; i++)
                    {
                        ++column;
                        result.Add(matrix[row, column]);
                    }

                    break;
                }

                for (int i = 0; i < incrementColumn; i++)
                {
                    ++column;
                    result.Add(matrix[row, column]);
                }

                for (int i = 0; i < incrementRow; i++)
                {
                    ++row;
                    result.Add(matrix[row, column]);
                }

                ++incrementColumn;
                ++incrementRow;

                for (int i = 0; i < incrementColumn; i++)
                {
                    --column;
                    result.Add(matrix[row, column]);
                }

                for (int i = 0; i < incrementRow; ++i)
                {
                    --row;
                    result.Add(matrix[row, column]);
                }

                ++incrementColumn;
                ++incrementRow;
            }

            return result.ToArray();
        }
    }
}