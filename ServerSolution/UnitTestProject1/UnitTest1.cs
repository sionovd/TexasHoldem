using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersistenceLayer;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void deleteDB()
        {
            DBHelper db = new DBHelper();
            db.DeleteAllData();
        }
    }
}
