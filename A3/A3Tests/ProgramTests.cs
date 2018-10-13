using Microsoft.VisualStudio.TestTools.UnitTesting;
using A3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void FibonacciTest()
        {
            Assert.AreEqual(Program.Fibonacci(10),55);
        }

        [DeploymentItem("TestData", "A3_TestData")]
        [TestMethod()]
        public void Graded_FibonacciTest()
        {
            TestCommon.TestTools.RunLocalTest("A3",Program.ProcessFibonacci,"TD1");
        }


        [DeploymentItem("TestData", "A3_TestData")]
        [TestMethod()]
        public void Graded_FibonacciLastDigitTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_LastDigit, "TD2");
        }

        [TestMethod()]
        public void Fibonacci_LastDigitTest()
        {
            Assert.AreEqual(Program.Fibonacci_LastDigit(3),2);
        }

        [TestMethod()]
        public void GCDTest()
        {
            Assert.AreEqual(Program.GCD(81,6), 3);
        }

        [DeploymentItem("TestData", "A3_TestData")]
        [TestMethod()]
        public void Graded_GCDTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessGCD, "TD3");
        }


        [DeploymentItem("TestData", "A3_TestData")]
        [TestMethod()]
        public void Graded_LCMTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessLCM, "TD4");
        }

        [TestMethod()]
        public void LCMTest()
        {
            Assert.AreEqual(Program.LCM(8, 6), 24);
        }

        [TestMethod()]
        public void FibonacciModTest()
        {
            Assert.AreEqual(Program.Fibonacci_Mod(2015,3),1);
        }

        [DeploymentItem("TestData", "A3_TestData")]
        [TestMethod()]
        public void Graded_FibonacciModTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Mod, "TD5");
        }
        

        [TestMethod()]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_FibonacciSumTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Sum, "TD6");
        }

        [DeploymentItem("TestData", "A3_TestData")]
        [TestMethod()]
        public void Graded_FibonacciPartialSumTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Partial_Sum, "TD7");
        }

        [TestMethod()]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_FibonacciSumSquare()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Sum_Squares, "TD8");
        }
    }
}