using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PrintFleetTests
    {
        [TestMethod, TestCategory("Integration-PrintFleet")]
        public void CanGetDeviceFromPrintFleet()
        {
            const string apiBaseUrl = "";
            const string apiVersion = "3.3.2";
            const string userName = "apiuser";
            const string password = "secret";

            var client = new PrintFleetClient.PrintFleetClient(apiBaseUrl, apiVersion, userName, password);

            Guid deviceId = Guid.Parse("ee3ef5b3-64fd-688f-cf31-6827be8e1677");

            var response = client.GetDevice(deviceId);

            Assert.AreEqual(response.Id.ToString(), "ee3ef5b3-64fd-688f-cf31-6827be8e1677");
        }
    }
}
