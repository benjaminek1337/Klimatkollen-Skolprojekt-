using Klimatkollen.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klimatkollen.UnitTests1
{
    [TestClass]
    public class ObservationOperationsTests
    {
        [TestMethod]
        public void CanEditObservations_AdminCanEditObservations_ReturnsTrue()
        {
            // Arrange
            var observationOperations = new ObservationOperations();

            // Act
            var result = observationOperations.CanEditRoles("Admin");

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
