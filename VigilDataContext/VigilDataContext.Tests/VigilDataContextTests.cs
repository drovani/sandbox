using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vigil;

namespace VigilDataContext.Tests
{
    [TestClass]
    public class VigilDataContextTests
    {
        [TestMethod]
        public void Can_Create_Database_And_Add_User()
        {
            var context = new Vigil.VigilDataContext("Vigil_Test_Db");
            context.Database.Initialize(true);

            context.Database.CreateIfNotExists();
            Guid newguid = Guid.NewGuid();
            context.Set<VigilUser>().Add(new VigilUser { UserName = "TestUser", Email = "test@example.com", Id = newguid });
            context.SaveChanges();

            Assert.IsNotNull(context.Set<VigilUser>().Find(newguid));
        }
    }
}
