using Microsoft.Extensions.Localization;
using Moq;
using NSubstitute;
using NUnit.Framework;
using System.Globalization;
using WebApplicationForTesting.Resources;
using WebApplicationForTesting.Services;

namespace Tests
{
    public class MessageServiceTest
    {

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test LocService Substitute
        /// </summary>
        [Test]
        public void Test_LocService_Substitute()
        {
            string key = "Type1Message";

            string result = "Type1Message_Fr";

            CultureInfo cultureInfo = new CultureInfo("fr-FR");

            var substituteStringLocalizer = Substitute.For<IStringLocalizerFactory>();

            var substituteLocservice = new LocService(substituteStringLocalizer);

            var SubstituteValue = substituteLocservice.GetLocalized(key, cultureInfo) ?? string.Empty;

            Assert.AreEqual(result, SubstituteValue);
        }

        /// <summary>
        /// Test LocService Mock
        /// </summary>
        [Test]
        public void Test_LocService_Mock()
        {
            string key = "Type1Message";

            string result = "Type1Message_Fr";

            CultureInfo cultureInfo = new CultureInfo("fr-FR");

            var mockStringLocalizerFactory = Mock.Of<IStringLocalizerFactory>();

            var mockLocService = new LocService(mockStringLocalizerFactory);

            var mockValue = mockLocService.GetLocalized(key, cultureInfo) ?? string.Empty;

            Assert.AreEqual(result, mockValue);
        }

        /// <summary>
        /// Test GetMessage Substitute
        /// </summary>
        [Test]
        public void Test_GetMessageSubstitute()
        {
            var messageService = Substitute.For<IMessageService>();

            var result = messageService.GetMessage(WebApplicationForTesting.Models.MessageTypeEnum.Type1, new CultureInfo("fr-FR"));

            Assert.AreEqual("Message Type 1 : Type1Message_Fr", result);
        }

        /// <summary>
        /// Test GetMessage Mock
        /// </summary>
        [Test]
        public void Test_GetMessageMock()
        {
            var messageService = Mock.Of<IMessageService>();

            var result = messageService.GetMessage(WebApplicationForTesting.Models.MessageTypeEnum.Type1, new CultureInfo("fr-FR"));

            Assert.AreEqual("Message Type 1 : Type1Message_Fr", result);
        }

        /// <summary>
        /// Test du service sans l'interface
        /// </summary>
        [Test]
        public void Test_Direct_Service()
        {

            CultureInfo cultureInfo = new CultureInfo("fr-FR");

            var mockStringLocalizerFactory = Mock.Of<IStringLocalizerFactory>();

            var mockLocService = new LocService(mockStringLocalizerFactory);

            MessageService messageService = new MessageService(mockLocService);

            var result = messageService.GetMessage(WebApplicationForTesting.Models.MessageTypeEnum.Type1, cultureInfo);

            Assert.AreEqual("Message Type 1 : Type1Message_Fr", result);
        }

        [Test]
        public void Test_With_Mock_Setup()
        {
            var localizedString = new LocalizedString("Type1Message", "Type1Message_Fr");

            var stringLocalizer = new Mock<IStringLocalizer>();

            stringLocalizer.Setup(s => s["Type1Message", "test"]).Returns(localizedString);

            var result = stringLocalizer.Object["Type1Message"];

            Assert.AreEqual("Type1Message_Fr", result);


        }




    }
}