using InGreed_API_IntegrationTest_.Utility;
using InGreed_API.Models;
using InGreed_API.Services.Ingredients;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace InGreed_API_IntegrationTest_.UserTest
{
    public class IngredientServiceTest : TestBase
    {
        private readonly IIngredientService ingredientService;
        private Mock<IConfiguration> configurationMock = new();
        public IngredientServiceTest(IntegrationTestWebAppFactory factory) : base(factory) 
        {
            this.configurationMock.Setup(x => x[It.IsAny<string>()]).Returns("");
            ingredientService = new IngredientService(DbContext, configurationMock.Object);
            this.DbContext.Ingredients.ExecuteDelete();
        }

        [Fact]
        public async Task GetAllIngrediets_ShouldReturn_AddedIngredients()
        {
            byte[] sample_array = { 0x01, 0x02, 0x03, 0x04, 0x05 };
            //arrange
            Ingredient ingredient = new Ingredient()
            {
                Name = "sample_ingredient",
                Icon = sample_array,

            };

            this.DbContext.Ingredients.Add(ingredient);
            this.DbContext.SaveChanges();

            //act
            var ingredientList = await ingredientService.GetAllIngredients();

            //assert
            ingredientList.Count.Should().Be(1);
            ingredientList[0].Name.Should().Be("sample_ingredient");
        }

    }
}
