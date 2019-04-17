namespace ProblemSet03.Task02
{
    public class HashFromStringFunction : IHashFunction<string>
    {
        public int GetHash(string value)
        {
            return value?.GetHashCode() + 13 ?? 0;
        }
    }
}
