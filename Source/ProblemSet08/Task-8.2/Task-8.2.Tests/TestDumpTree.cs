namespace ProblemSet08.Task02.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class TestDumpTree
    {
        [Test]
        public void GenerateTree()
        {
            const string expected = @"
            digraph sample {
            L_1 [ label = '44' ];
            L_2[label = '43'];
            L_3[label = '40'];
            L_4[label = '38'];
            L_5[label = '36'];
            L_6[label = '34'];
            L_7[label = '32'];
            L_8[label = '30'];
            L_9[label = '28'];
            L_10[label = '25'];
            L_11[label = '21'];
            L_12[label = '19'];
            L_13[label = '14'];
            L_14[label = '13'];
            L_15[label = '12'];
            L_16[label = '9'];
            L_17[label = '1'];
            L_2->L_1[label = 'left'];
            L_3->L_2[label = 'left'];
            L_3->L_4[label = 'right'];
            L_5->L_3[label = 'left'];
            L_5->L_6[label = 'right'];
            L_7->L_5[label = 'left'];
            L_7->L_10[label = 'right'];
            L_9->L_8[label = 'left'];
            L_10->L_9[label = 'left'];
            L_10->L_16[label = 'right'];
            L_12->L_11[label = 'left'];
            L_12->L_15[label = 'right'];
            L_14->L_13[label = 'left'];
            L_15->L_14[label = 'left'];
            L_16->L_12[label = 'left'];
            L_16->L_17[label = 'right'];
            }
            ";

            string ReduceVariations(string s)
            {
                return s
                    .Replace("\"", "'")
                    .Replace(" ", string.Empty)
                    .Replace("\r", string.Empty)
                    .Replace("\t", string.Empty)
                    .Replace("\n", string.Empty);
            }

            var r = new Random(0);
            var sut = new CustomSet<int>();

            for (var i = 0; i < 20; i++)
            {
                ((ISet<int>)sut).Add(r.Next(0, 45));
            }

            var res = sut.DumpTree();
            Assert.AreEqual(ReduceVariations(expected), ReduceVariations(res));
        }
    }
}
