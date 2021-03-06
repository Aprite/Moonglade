using System.Diagnostics.CodeAnalysis;
using Moonglade.Configuration;
using Moonglade.Configuration.Abstraction;
using Moonglade.Web.Pages.Settings;
using Moq;
using NUnit.Framework;

namespace Moonglade.Web.Tests.Pages.Settings
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GeneralModelTests
    {
        private MockRepository _mockRepository;

        private Mock<IBlogConfig> _mockBlogConfig;
        private Mock<ITZoneResolver> _mockTZoneResolver;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new(MockBehavior.Default);

            _mockBlogConfig = _mockRepository.Create<IBlogConfig>();
            _mockTZoneResolver = _mockRepository.Create<ITZoneResolver>();
        }

        private GeneralModel CreateGeneralModel()
        {
            return new(
                _mockBlogConfig.Object,
                _mockTZoneResolver.Object);
        }

        [Test]
        public void OnGet_StateUnderTest_ExpectedBehavior()
        {
            _mockBlogConfig.Setup(p => p.GeneralSettings).Returns(new GeneralSettings());
            var generalModel = CreateGeneralModel();

            generalModel.OnGet();
            Assert.IsNotNull(generalModel.ViewModel);
        }
    }
}
