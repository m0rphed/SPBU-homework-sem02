namespace ProblemSet03.Task02
{
    /// <summary>
    /// Hash function interface
    /// </summary>
    /// <typeparam name="T">specified type of value</typeparam>
    public interface IHashFunction<in T>
    {
        /// <summary>
        /// Gets hash of specified value
        /// </summary>
        /// <param name="value">value to calculate hash of</param>
        /// <returns>hash of the given value</returns>
        int GetHash(T value);
    }
}
