namespace ProblemSet03.Task02
{
    public class HashFromGenericFunction<T> : IHashFunction<T>
    {
        public int GetHash(T value)
        {
            return value.GetHashCode();
        }
    }
}
