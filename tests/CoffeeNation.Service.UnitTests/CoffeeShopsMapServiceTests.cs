using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Core.Interfaces;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Service.UnitTests
{
    public class CoffeeShopsMapServiceTests
    {
        [Fact]
        public async Task TestThat_GetClosestCoffeeShops_When_DistanceCalculatorThrowsArgumentNullException_Throws_ArgumentNullException()
        {
            // Arrange
            var userLocationRepositoryMock = new Mock<IUserLocationRepository>();
            userLocationRepositoryMock
                .Setup(x => x.GetUserLocation())
                .ReturnsAsync(MockData.UserLocation1);

            var coffeeShopLocationRepositoryMock = new Mock<ICoffeeShopLocationRepository>();
            coffeeShopLocationRepositoryMock
                .Setup(x => x.GetCoffeeShopLocations())
                .ReturnsAsync(MockData.ValidCoffeeShopLocations);

            var coffeeShopDistanceRepositoryMock = new Mock<ICoffeeShopDistanceRepository>();
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var distanceCalculatorMock = new Mock<IDistanceCalculator>();
            distanceCalculatorMock
                .Setup(x => x.CalculateDistanceToDestination(It.IsAny<Location>(), It.IsAny<Location>()))
                .Throws<ArgumentNullException>();

            var distanceSelectorMock = new Mock<IDistanceSelector>();

            var coffeeShopsMapService = new CoffeeShopsMapService(
                userLocationRepositoryMock.Object,
                coffeeShopLocationRepositoryMock.Object,
                coffeeShopDistanceRepositoryMock.Object,
                outputMessageRepositoryMock.Object,
                distanceCalculatorMock.Object,
                distanceSelectorMock.Object);

            // Act
            async Task Act() => await coffeeShopsMapService.GetClosestCoffeeShops();

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_GetClosestCoffeeShops_When_DistanceSelectorThrowsArgumentNullException_Throws_ArgumentNullException()
        {
            // Arrange
            var userLocationRepositoryMock = new Mock<IUserLocationRepository>();
            var coffeeShopLocationRepositoryMock = new Mock<ICoffeeShopLocationRepository>();

            var coffeeShopDistanceRepositoryMock = new Mock<ICoffeeShopDistanceRepository>();
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var distanceCalculatorMock = new Mock<IDistanceCalculator>();

            var distanceSelectorMock = new Mock<IDistanceSelector>();
            distanceSelectorMock
                .Setup(x => x.SelectDistances(It.IsAny<IEnumerable<Distance>>()))
                .Throws<ArgumentNullException>();

            var coffeeShopsMapService = new CoffeeShopsMapService(
                userLocationRepositoryMock.Object,
                coffeeShopLocationRepositoryMock.Object,
                coffeeShopDistanceRepositoryMock.Object,
                outputMessageRepositoryMock.Object,
                distanceCalculatorMock.Object,
                distanceSelectorMock.Object);

            // Act
            async Task Act() => await coffeeShopsMapService.GetClosestCoffeeShops();

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_GetClosestCoffeeShops_When_DistanceSelectorThrowsArgumentOutOfRangeException_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var userLocationRepositoryMock = new Mock<IUserLocationRepository>();
            var coffeeShopLocationRepositoryMock = new Mock<ICoffeeShopLocationRepository>();

            var coffeeShopDistanceRepositoryMock = new Mock<ICoffeeShopDistanceRepository>();
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var distanceCalculatorMock = new Mock<IDistanceCalculator>();

            var distanceSelectorMock = new Mock<IDistanceSelector>();
            distanceSelectorMock
                .Setup(x => x.SelectDistances(It.IsAny<IEnumerable<Distance>>()))
                .Throws<ArgumentOutOfRangeException>();

            var coffeeShopsMapService = new CoffeeShopsMapService(
                userLocationRepositoryMock.Object,
                coffeeShopLocationRepositoryMock.Object,
                coffeeShopDistanceRepositoryMock.Object,
                outputMessageRepositoryMock.Object,
                distanceCalculatorMock.Object,
                distanceSelectorMock.Object);

            // Act
            async Task Act() => await coffeeShopsMapService.GetClosestCoffeeShops();

            // Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(Act);
        }

        [Fact]
        public async Task TestThat_GetClosestCoffeeShops_When_UserLocationRepositoryThrowsDataValidationException_Throws_DataValidationExceptionWithExpectedMessage()
        {
            // Arrange
            var userLocationRepositoryMock = new Mock<IUserLocationRepository>();
            userLocationRepositoryMock
                .Setup(x => x.GetUserLocation())
                .Throws(new DataValidationException(MockValues.CommandLineDataValidationExceptionMessage));

            var coffeeShopLocationRepositoryMock = new Mock<ICoffeeShopLocationRepository>();

            var coffeeShopDistanceRepositoryMock = new Mock<ICoffeeShopDistanceRepository>();
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var distanceCalculatorMock = new Mock<IDistanceCalculator>();
            var distanceSelectorMock = new Mock<IDistanceSelector>();

            var coffeeShopsMapService = new CoffeeShopsMapService(
                userLocationRepositoryMock.Object,
                coffeeShopLocationRepositoryMock.Object,
                coffeeShopDistanceRepositoryMock.Object,
                outputMessageRepositoryMock.Object,
                distanceCalculatorMock.Object,
                distanceSelectorMock.Object);

            // Act
            async Task Act() => await coffeeShopsMapService.GetClosestCoffeeShops();

            // Assert
            var exception = await Assert.ThrowsAsync<DataValidationException>(Act);
            Assert.Equal(MockValues.CommandLineDataValidationExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_GetClosestCoffeeShops_When_CoffeeShopLocationRepositoryThrowsDataValidationException_Throws_DataValidationExceptionWithExpectedMessage()
        {
            // Arrange
            var userLocationRepositoryMock = new Mock<IUserLocationRepository>();

            var coffeeShopLocationRepositoryMock = new Mock<ICoffeeShopLocationRepository>();
            coffeeShopLocationRepositoryMock
                .Setup(x => x.GetCoffeeShopLocations())
                .Throws(new DataValidationException(MockValues.CsvDataValidationExceptionMessage));

            var coffeeShopDistanceRepositoryMock = new Mock<ICoffeeShopDistanceRepository>();
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var distanceCalculatorMock = new Mock<IDistanceCalculator>();
            var distanceSelectorMock = new Mock<IDistanceSelector>();

            var coffeeShopsMapService = new CoffeeShopsMapService(
                userLocationRepositoryMock.Object,
                coffeeShopLocationRepositoryMock.Object,
                coffeeShopDistanceRepositoryMock.Object,
                outputMessageRepositoryMock.Object,
                distanceCalculatorMock.Object,
                distanceSelectorMock.Object);

            // Act
            async Task Act() => await coffeeShopsMapService.GetClosestCoffeeShops();

            // Assert
            var exception = await Assert.ThrowsAsync<DataValidationException>(Act);
            Assert.Equal(MockValues.CsvDataValidationExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_GetClosestCoffeeShops_When_NoExceptionThrown_Returns_NotNullDistanceList()
        {
            // Arrange
            var userLocationRepositoryMock = new Mock<IUserLocationRepository>();
            var coffeeShopLocationRepositoryMock = new Mock<ICoffeeShopLocationRepository>();

            var coffeeShopDistanceRepositoryMock = new Mock<ICoffeeShopDistanceRepository>();
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var distanceCalculatorMock = new Mock<IDistanceCalculator>();
            var distanceSelectorMock = new Mock<IDistanceSelector>();

            var coffeeShopsMapService = new CoffeeShopsMapService(
                userLocationRepositoryMock.Object,
                coffeeShopLocationRepositoryMock.Object,
                coffeeShopDistanceRepositoryMock.Object,
                outputMessageRepositoryMock.Object,
                distanceCalculatorMock.Object,
                distanceSelectorMock.Object);

            // Act
            var distances = await coffeeShopsMapService.GetClosestCoffeeShops();

            // Assert
            Assert.NotNull(distances);
        }

        [Fact]
        public async Task TestThat_GetClosestCoffeeShops_When_NoExceptionThrown_Returns_ExpectedElementsCount()
        {
            // Arrange
            var userLocationRepositoryMock = new Mock<IUserLocationRepository>();
            userLocationRepositoryMock
                .Setup(x => x.GetUserLocation())
                .ReturnsAsync(MockData.UserLocation1);

            var coffeeShopLocationRepositoryMock = new Mock<ICoffeeShopLocationRepository>();
            coffeeShopLocationRepositoryMock
                .Setup(x => x.GetCoffeeShopLocations())
                .ReturnsAsync(MockData.ValidCoffeeShopLocations);

            var coffeeShopDistanceRepositoryMock = new Mock<ICoffeeShopDistanceRepository>();
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var distanceCalculatorMock = new Mock<IDistanceCalculator>();
            distanceCalculatorMock
                .Setup(x => x.CalculateDistanceToDestination(It.IsAny<Location>(), It.IsAny<Location>()))
                .ReturnsAsync(MockData.ShopDistance1);

            var distanceSelectorMock = new Mock<IDistanceSelector>();
            distanceSelectorMock
                .Setup(x => x.SelectDistances(It.IsAny<IEnumerable<Distance>>()))
                .ReturnsAsync(MockData.SelectedShopDistances);

            var coffeeShopsMapService = new CoffeeShopsMapService(
                userLocationRepositoryMock.Object,
                coffeeShopLocationRepositoryMock.Object,
                coffeeShopDistanceRepositoryMock.Object,
                outputMessageRepositoryMock.Object,
                distanceCalculatorMock.Object,
                distanceSelectorMock.Object);

            // Act
            var distances = await coffeeShopsMapService.GetClosestCoffeeShops();

            // Assert
            Assert.Equal(MockValues.DefaultOutputDistancesCount, distances.Count());
        }
    }
}
