using A2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCommon
{
    public class TestTools 
    {
        private static readonly char[] IgnoreChars = new char[] { '\n', '\r', ' ' };

        public static void RunLocalTest(string A2, Func<string,string> Process, string A2_TestData=null)

        {
            string testDataPath = $"A2_TestData";
            if (!string.IsNullOrEmpty("A2_TestData"))
                testDataPath = Path.Combine(testDataPath, "A2_TestData");

            Assert.IsTrue(Directory.Exists(testDataPath));
            string[] inFiles = Directory.GetFiles(testDataPath, "*In_*.txt");

            Assert.IsTrue(inFiles.Length > 0 &&
                Directory.GetFiles(testDataPath).Length % 2 == 0);

            List<string> failedTests = new List<string>();
            foreach (var inFile in inFiles)
            {
                string outFile = inFile.Replace("In_", "Out_");
                Assert.IsTrue(File.Exists(outFile));
                try
                {
                    string result = Program.Process(File.ReadAllText(inFile));
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
