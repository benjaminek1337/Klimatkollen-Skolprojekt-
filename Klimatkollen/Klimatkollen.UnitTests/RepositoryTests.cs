using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Klimatkollen.UnitTests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void GetObservationCategories_GetCategories_CategoriesAreReturned()
        {
            // Arrange
            var repository = new Repository();



            var observationCategories = new List<String>() { "Animal", "Environment", "Other" };
        }
    }
}
