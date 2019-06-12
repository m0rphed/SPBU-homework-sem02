namespace ProblemSet03.Task02
{
    public class HashFromIntFunction : IHashFunction<int>
    {
        public int GetHash(int value)
        {
            return value;
        }
    }
}
