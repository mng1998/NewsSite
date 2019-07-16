using Microsoft.VisualStudio.TestTools.UnitTesting;
using News.Core.Context;
using News.DataLayer.SharedKernel;

namespace News.Test
{
    [TestClass]
    public abstract class TestBase
    {
        protected static IDbFactory dbFactory = new DbFactory();
        public TestBase()
        {
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <remarks>
        /// This will be call first
        /// Equal SetUp of Nunit.
        /// </remarks>
        [TestInitialize]
        public void Initialize()
        {
            GlobalContext.Instance.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=News;Trusted_Connection=True; MultipleActiveResultSets=true";
        }
    }
}
