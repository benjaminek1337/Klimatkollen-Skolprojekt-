using Klimatkollen.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Klimatkollen.UnitTests1
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void GetObservationCategories_GetCategories_ReturnsThreeObservationCategories()
        {
            var repository = new Repository(new ApplicationDbContext(null));

            var result = repository.GetObservationCategories();

            Assert.AreEqual(new List<String>() { "Animal", "Environment", "Other" }, result);
        }
    }
}
