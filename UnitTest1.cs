using Lab3;
using NUnit.Framework;

namespace NUnitTestProject3
{
    public class Tests
    {
        [SetUp]
 

        [Test]
        public void UpdaTetest()
        {
            using (ApplicationContext testdb = new ApplicationContext())
            {
                tester testtester = new tester { Id_tester = 2};
                Assert.Pass(Program.UpdateTesterById(testdb, testtester), "Complete");
            }
        }
    }
}