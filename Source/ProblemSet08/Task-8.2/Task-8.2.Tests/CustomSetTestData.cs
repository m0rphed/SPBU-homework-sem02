namespace ProblemSet08.Task02.Tests
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides tests for two different implementations of <see cref="ISet{T}"/>.
    /// </summary>
    public static class CustomSetTestData
    {
        private static readonly Func<ISet<string>> BuildFromHashSet = () => new HashSet<string>();
        private static readonly Func<ISet<string>> BuildFromCustomSet = () => new CustomSet<string>();

        public static object[] FixtureParams => new object[]
        {
            new object[] { BuildFromHashSet, "HashSet" },
            new object[] { BuildFromCustomSet, "CustomSet" }
        };
    }
}
