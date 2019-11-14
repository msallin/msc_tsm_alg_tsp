namespace tests.Infrastructure
{
    public class TestsBase
    {
        public TestsBase()
        {
            Container = new Container();
        }

        protected Container Container { get; }
    }
}