using DevTeams_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DevTeams_Tests
{

    [TestClass]
    public class DevTeamsRepo_Tests
    {
        private Developer _dev;
        private DevTeamsRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new DevTeamsRepo();
            _dev = new Developer( 007, "James", "Bond", TeamAssignment.FrontEnd);
            _repo.AddDevToDirtectory(_dev);
        }

        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //AAA
            //Arrange

            //Act
            bool addResult = _repo.AddDevToDirtectory(_dev);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMembers_ShouldReturnCorrectCollection()
        {
            // Arrange
            // Done

            // Act
            List<Developer> directory = _repo.GetMembers();

            // Assert
            bool directoryHasContent = directory.Contains(_dev);
            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetByFirstName_ShouldReturnCorrectContent()
        {
            //Arrange
            //Done in Arrange() method

            //Act
            Developer searchResult = _repo.GetDeveloperByFirstName("Max");

            //Assert
            Assert.AreEqual(_dev, searchResult);
        }

        [TestMethod]
        public void UpdateExistingDeveloper_ShouldUpdateValue()
        {
            //Arrange
            //Already done in Arrange() method

            //Act
            _repo.UpdateExistingDeveloper("Max", new Developer(007, "James", "Bond", TeamAssignment.FrontEnd));

            //Assert
            Assert.AreEqual(_dev.FirstName, "James");
        }

        [TestMethod]
        public void DeleteExistingDeveloper_ShouldReturnTrue()
        {
            bool wasDeleted = _repo.DeleteExistingDeveloper("Max");

            Assert.IsTrue(wasDeleted);
        }
    }
}
