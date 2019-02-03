using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;
using A6;

namespace A6.Tests
{
    [TestClass()]//Grade:A6:0
    public class GradedTests
    {
<<<<<<< HEAD
        [TestMethod(), Timeout(1000)]//Timeout???
=======
        [TestMethod()]//Timeout???
>>>>>>> master
        [DeploymentItem("TestData","A6_TestData")]
        public void SolveTest()
        {
            Processor[] problems = new Processor[] {
                new MoneyChange("TD1"),
                new PrimitiveCalculator("TD2"),
                new EditDistance("TD3"),
                new LCSOfTwo("TD4"),
                new LCSOfThree("TD5")
            };

            foreach(var p in problems)
            {
                TestTools.RunLocalTest("A6", p.Process, p.TestDataName);
            }
        }
    }
}