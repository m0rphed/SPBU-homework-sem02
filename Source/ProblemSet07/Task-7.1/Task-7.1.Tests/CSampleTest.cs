using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_7._1;

namespace Task_3._2.Tests
{
    [TestFixture]
    public class SampleTest
    {
        [Test]
        public void Test()
        {
            var c = new Calculator();
            string res = string.Empty;
            c.OnTextChange += (d) => { res = d; };
            c.HandleDigit(1);
            Assert.AreEqual("1", res);
            c.HandleSymbol(OperationSymbol.Dot);
            Assert.AreEqual("1.", res);
            c.HandleDigit(1);
            Assert.AreEqual("1.1", res);
            c.HandleOperation(OperationType.Add);
            Assert.AreEqual("+", res);
            c.HandleDigit(1);
            Assert.AreEqual("1", res);
            c.HandleOperation(OperationType.Equal);
            Assert.AreEqual("2.1", res);

        }
    }
}
