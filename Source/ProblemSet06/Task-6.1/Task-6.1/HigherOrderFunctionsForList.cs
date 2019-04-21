namespace ProblemSet06.Task01
{
    using System;
    using System.Collections.Generic;

    public static class HigherOrderFunctionsForList<T>
    {
        /// <summary>
        /// Map (higher-order function)
        /// </summary>
        /// <param name="list">linked list</param>
        /// <param name="function">mapping function</param>
        /// <returns>
        /// linked list obtained by applying the passed function to each element
        /// </returns>
        public static List<T> Map(List<T> list, Func<T, T> function)
        {
            var mapped = new List<T>();

            foreach (var elem in list)
            {
                mapped.Add(function(elem));
            }

            return mapped;
        }

        /// <summary>
        /// Filter (higher-order function)
        /// </summary>
        /// <param name="list">linked list</param>
        /// <param name="function">filtering function</param>
        /// <returns>
        /// linked list made up of elements of a passed list,
        /// for which the passed function returns true
        /// </returns>
        public static List<T> Filter(List<T> list, Func<T, bool> function)
        {
            var filtered = new List<T>();

            foreach (var elem in list)
            {
                if (function(elem))
                {
                    filtered.Add(elem);
                }
            }

            return filtered;
        }

        /// <summary>
        /// Fold (higher-order function)
        /// </summary>
        /// <param name="list">linked list</param>
        /// <param name="acc">accumulated value</param>
        /// <param name="function">passed function</param>
        /// <returns>Accumulated value as a result of passing through the entire list</returns>
        public static T Fold(List<T> list, T acc, Func<T, T, T> function)
        {
            var temp = acc;
            foreach (var elem in list)
            {
                temp = function(temp, elem);
            }

            return temp;
        }
    }
}
