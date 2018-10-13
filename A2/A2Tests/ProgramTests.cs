using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Diagnostics;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void NaiveMaxPairWiseProductTest()
        {
            int TestAlgorithm = Program.NaiveMaxPairWiseProduct(new List<int>() { 1, 2, 9, 3, 8, 9, 4 });
            Assert.AreEqual(TestAlgorithm, 81);
        }
        
        [TestMethod()]
        public void FastMaxPairWiseProductTest()
        {
            int TestAlgorithm = Program.FastMaxPairWiseProduct(new List<int>() { 1, 2,6 });
            Assert.AreEqual(TestAlgorithm,12);
        }
        
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A2_TestData")]
        public void GradedTest_Performance()
        {
            TestCommon.TestTools.RunLocalTest("A2", Program.Process);
        }

        [TestMethod()]
        [DeploymentItem("TestData", "A2_TestData")]
        public void GradedTest_Correctness()
        {
            TestCommon.TestTools.RunLocalTest("A2", Program.Process);
        }

        [TestMethod()]
        public void GradedTest_Stress()
        {
            Stopwatch stopwatch = new Stopwatch();
            List<int> A = new List<int>();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds <100)
            {
                Random rnd = new Random();
                int number = rnd.Next(2, 10);
                for (int i = 0; i < number; i++)
                {
                    Random R = new Random();
                    A.Add(R.Next(0, 10));
                }
            }
            var result1 = Program.NaiveMaxPairWiseProduct(A);
            var result2 = Program.FastMaxPairWiseProduct(A);

            Assert.AreEqual(result1, result2);
        }
        
    }
}