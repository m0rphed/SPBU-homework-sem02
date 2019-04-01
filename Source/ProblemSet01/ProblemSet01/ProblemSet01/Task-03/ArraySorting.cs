namespace ProblemSet01.Task_03
{
    using System;

    /// <summary>
    /// Class provides method for fancy array sorting
    /// </summary>
    public class ArraySorting
    {
        /// <summary>
        /// Generic method for "Bubble sorting" an array of numbers
        /// </summary>
        /// <typeparam name="ElementType">Any numerical type, for example, int, double, etc.</typeparam>
        /// <param name="array">An array of numbers</param>
        public static void BubbleSort<ElementType>(ElementType[] array)
            where ElementType : IComparable
        {
            for (int outer = array.Length; outer >= 1; outer--)
            {
                for (int inner = 0; inner < outer - 1; inner++)
                {
                    if (array[inner].CompareTo(array[inner + 1]) > 0)
                    {
                        ElementType swap = array[inner];
                        array[inner] = array[inner + 1];
                        array[inner + 1] = swap;
                    }
                }
            }
        }

        /// <summary>
        /// Generic method for printing an array of numbers
        /// </summary>
        /// <typeparam name="ElementType">Any numerical type, for example, int, double, etc.</typeparam>
        /// <param name="array">An array of numbers</param>
        public static void PrintArray<ElementType>(ElementType[] array)
        {
            foreach (ElementType element in array)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }
    }
}
