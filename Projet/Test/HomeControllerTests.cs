using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Projet.Tests
{
    public class Program
    {

        // Assurez-vous d'ajuster l'accessibilité du constructeur
        public class HomeControllerTests : IClassFixture<WebApplicationFactory<Program>>
        {
            private readonly WebApplicationFactory<Program> _factory;

            public HomeControllerTests(WebApplicationFactory<Program> factory)
            {
                _factory = factory;
            }

            [Fact]
            public async Task Index_ReturnsViewResult()
            {
                // Arrange
                var client = _factory.CreateClient();

                // Act
                var response = await client.GetAsync("/Home/Index");

                // Assert
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                Assert.Contains("ViewResult", content);
            }

            [Fact]
            public async Task UpdateParent_ReturnsViewResultOnGet()
            {
                // Arrange
                var client = _factory.CreateClient();

                // Act
                var response = await client.GetAsync("/Home/UpdateParent/1"); // Remplacez '1' par l'ID d'un parent existant dans votre base de données

                // Assert
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                Assert.Contains("ViewResult", content);
            }

            [Fact]
            public async Task UpdateParent_RedirectsOnPostWithValidModel()
            {
                // Arrange
                var client = _factory.CreateClient();

                // Act
                var response = await client.PostAsync("/Home/UpdateParent/1", new StringContent("Some valid data")); // Remplacez '1' par l'ID d'un parent existant dans votre base de données

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal("/Home/Index", response.RequestMessage.RequestUri.AbsolutePath);
            }

            [Fact]
            public async Task UpdateParent_ReturnsViewResultOnPostWithInvalidModel()
            {
                // Arrange
                var client = _factory.CreateClient();

                // Act
                var response = await client.PostAsync("/Home/UpdateParent/1", new StringContent("Some invalid data")); // Remplacez '1' par l'ID d'un parent existant dans votre base de données

                // Assert
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                Assert.Contains("ViewResult", content);
            }

        }
    }
}