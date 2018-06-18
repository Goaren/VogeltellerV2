using System;
using Datalayer.Repositories;
using Models.Models;
using VogelTellerTests.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VogelTellerTests
{
    [TestClass]
        public class CUDGebied
        {
        GebiedRepository gr = new GebiedRepository(new CUDGebiedContext());
        private Gebied gebied;
        private Gebied testgebied;

        [TestInitialize]
        public void Initialize()
        {
            gebied = new Gebied(6, "Barcelona", 41.390205, 2.154007, 18);
        }

        [TestMethod]
        public void TestGebiedConcstructor()
        {
            Assert.AreEqual(6, gebied.Id);
            Assert.AreEqual("Barcelona", gebied.Naam);
            Assert.AreEqual(41.390205, gebied.X);
            Assert.AreEqual(2.154007, gebied.Y);
            Assert.AreEqual(18, gebied.Zoom);
        }
        [TestMethod]
        public void IntegrationTestGebied()
        {
            // Maak gebied aan test
            gr.CreateGebied(gebied);
            testgebied = gr.GetGebiedById(gebied.Id);
            Assert.AreEqual(gebied, testgebied);

            //Update gebied test
            gebied = new Gebied(6, "LOLTEST", 41.390210, 2.154010, 16);
            gr.UpdateGebied(gebied);
            testgebied = gr.GetGebiedById(gebied.Id);
            Assert.AreEqual(gebied, testgebied);

            gebied = new Gebied(6, "LOLTEST2", 40, 2.1, 14);
            gr.UpdateGebied(gebied);
            testgebied = gr.GetGebiedById(gebied.Id);
            Assert.AreEqual(gebied, testgebied);

            gebied = new Gebied(6, "LOLTEST3", 5, 2, 20);
            gr.UpdateGebied(gebied);
            testgebied = gr.GetGebiedById(gebied.Id);
            Assert.AreEqual(gebied, testgebied);

            //Delete gebied test
            gr.DeleteGebied(gebied.Id);
            testgebied = gr.GetGebiedById(gebied.Id);
            Assert.IsNull(testgebied);

        }
    }
}
