﻿using System;
using System.Threading.Tasks;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces.Provider;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Data.UnitTests
{
    public class UserLocationDataReaderTests
    {
        [Fact]
        public async Task TestThat_ReadUserLocation_When_ProviderThrowsDataProviderException_Throws_DataProviderExceptionWithExpectedMessage()
        {
            // Arrange
            var userLocationProviderMock = new Mock<IUserLocationProvider>();
            userLocationProviderMock
                .Setup(x => x.GetUserLocationCoordinates())
                .Throws(new DataProviderException(MockValues.UserLocationDataProviderExceptionMessage));

            var dataReader = new UserLocationDataReader(userLocationProviderMock.Object);

            // Act
            async Task Act() => await dataReader.ReadUserLocation();

            // Assert
            var exception = await Assert.ThrowsAsync<DataProviderException>(Act);
            Assert.Equal(MockValues.UserLocationDataProviderExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_ReadUserLocation_When_ProviderThrowsException_Throws_SameException()
        {
            // Arrange
            var mockException = MockObjects.GenericException;

            var userLocationProviderMock = new Mock<IUserLocationProvider>();
            userLocationProviderMock
                .Setup(x => x.GetUserLocationCoordinates())
                .Throws(mockException);

            var dataReader = new UserLocationDataReader(userLocationProviderMock.Object);

            // Act
            async Task Act() => await dataReader.ReadUserLocation();

            // Assert
            var exception = await Assert.ThrowsAnyAsync<Exception>(Act);
            Assert.Equal(mockException, exception);
        }

        [Fact]
        public async Task TestThat_ReadUserLocation_When_ParserAndProviderDoNotThrowException_Returns_NotNullLocation()
        {
            // Arrange
            var userLocationProviderMock = new Mock<IUserLocationProvider>();
            userLocationProviderMock
                .Setup(x => x.GetUserLocationCoordinates())
                .ReturnsAsync(MockObjects.ValidRawUserLocation1);

            var dataReader = new UserLocationDataReader(userLocationProviderMock.Object);

            // Act
            var location = await dataReader.ReadUserLocation();

            // Assert
            Assert.NotNull(location);
        }

        [Fact]
        public async Task TestThat_ReadUserLocation_When_ParserAndProviderDoNotThrowException_Returns_LocationWithExpectedValues()
        {
            // Arrange
            var userLocationMock = MockObjects.UserLocation99;

            var userLocationProviderMock = new Mock<IUserLocationProvider>();
            userLocationProviderMock
                .Setup(x => x.GetUserLocationCoordinates())
                .ReturnsAsync(MockObjects.ValidRawUserLocation99);

            var dataReader = new UserLocationDataReader(userLocationProviderMock.Object);

            // Act
            var location = await dataReader.ReadUserLocation();

            // Assert
            Assert.Equal(userLocationMock.X, location.X);
            Assert.Equal(userLocationMock.Y, location.Y);
            Assert.Equal(userLocationMock.Tag, location.Tag);
        }
    }
}
