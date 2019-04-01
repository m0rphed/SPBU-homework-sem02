namespace ProblemSet01.Task_05
{
    using System;

    /// <summary>
    /// Class provides math sorting method
    /// </summary>
    public class ColumnsSorting
    {
        /// <param name="matrix">A matrix to sort</param>
        /// <summary>
        /// Sorting matrix columns by their first elements
        /// </summary>
        public static void MatrixSort(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; ++i)
            {
                for (int j = 0; j < matrix.GetLength(1) - i - 1; ++j)
                {
                    if (matrix[0, j] > matrix[0, j + 1])
                    {
                        SwapColumns(matrix, j, j + 1);
                    }
                }
            }
        }

        /// <param name="matrix">A matrix to print</param>
        /// <summary>
        /// Printing the matrix
        /// </summary>
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        /// <param name="matrix">A matrix</param>
        /// <param name="first">First column</param>
        /// <param name="second">Second column</param>
        /// <summary>
        /// Swaping two columns of matrix
        /// </summary>
        private static void SwapColumns(int[,] matrix, int first, int second)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int swap = matrix[i, first];
                matrix[i, first] = matrix[i, second];
                matrix[i, second] = swap;
            }
        }
    }
}
