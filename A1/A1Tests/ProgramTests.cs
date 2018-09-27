using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(8 , Program.Add(3,5));
        }
        private static readonly char[] IgnoreChars = new char[] { '\n', '\r', ' ' };

        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "TestData")]
        public void GradedTest()
        {
            Assert.IsTrue(Directory.Exists("TestData"));
            string[] inFiles = Directory.GetFiles("TestData", "*In_*.txt");

            Assert.IsTrue(inFiles.Length > 0 &&
                Directory.GetFiles("TestData").Length % 2 == 0);

            List<string> failedTests = new List<string>();
            foreach (var inFile in inFiles)
            {
                string outFile = inFile.Replace("In_", "Out_");
                Assert.IsTrue(File.Exists(outFile));
                try
                {
                    string result =Program.Process(File.ReadAllText(inFile));
                    Assert.AreEqual(
                        result.Trim(IgnoreChars),
                        File.ReadAllText(outFile).Trim(IgnoreChars));
                    Console.WriteLine($"Test Passed: {inFile}");
                }
                catch (Exception e)
                {
                    failedTests.Add($"Test failed for input {inFile}: {e.Message}");
                    Console.WriteLine($"Test Failed: {inFile}");
                }
            }

            Assert.IsTrue(failedTests.Count == 0,
                $"{failedTests.Count} out of {inFiles.Length} tests failed: {string.Join("\n", failedTests)}");

            Console.WriteLine($"All {inFiles.Length} tests passed.");
        }
    }
}