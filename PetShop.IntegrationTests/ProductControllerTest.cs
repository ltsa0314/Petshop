using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using PetShop.Api;
using PetShop.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PetShop.IntegrationTests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Insert()
        {
            // Arrange
            TestServer server;
            HttpClient client;

            server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>().UseEnvironment("Integration"));
            client = server.CreateClient();

            var model = new ProductDto
            {
                Code = "Aminomix",
                Name = "Aminomix Forte Equinos",
                Description = "Test description",
                Price = 120000,
                Image = "https://www.gabrica.co/wp-content/uploads/2019/04/Aminomix-Forte-Equinos-1.png"
            };

            // Act
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = client.PostAsync($"api/products", content).Result;

            ProductDto Product = null;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                Product = JsonConvert.DeserializeObject<ProductDto>(result.Content.ReadAsStringAsync().Result);
            }

            // Assert
            Assert.True(result.StatusCode == HttpStatusCode.OK,result.Content.ReadAsStringAsync().Result);
            Assert.True(Product != null);
            Assert.True(Product?.Id > 0);
            Assert.True(Product?.Code == "Aminomix");
            Assert.True(Product?.Name == "Aminomix Forte Equinos");
            Assert.True(Product?.Price == 120000);
            Assert.True(Product?.Image == "n/a");
        }
    }
}
