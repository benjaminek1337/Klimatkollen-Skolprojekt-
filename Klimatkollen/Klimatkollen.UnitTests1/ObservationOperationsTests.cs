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
            var observationOperations = new ObservationOperations();

            var result = observationOperations.CanEditRoles("Admin");

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CanEditObservations_UserCanEditObservations_ReturnsTrue()
        {
            var observationOperations = new ObservationOperations();

            var result = observationOperations.CanEditRoles("User");

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CanEditObservations_VisitorCannotEditObservations_ReturnsFalse()
        {
            var observationOperations = new ObservationOperations();

            var result = observationOperations.CanEditRoles("Visitor");

            Assert.AreEqual(false, result);
        }
    }
}
