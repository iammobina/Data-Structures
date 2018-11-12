namespace TestCommon
{
    public abstract class Processor
    {
        public abstract string Process(string inStr);
        public string TestDataName { get; private set; }

        public Processor(string testDataName) =>
            this.TestDataName = testDataName;
    }
}
