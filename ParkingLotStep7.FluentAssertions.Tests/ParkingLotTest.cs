using FluentAssertions;

namespace ParkingLotStep7.FluentAssertions.Tests;

public class ParkingLotTest : IDisposable
{
    private readonly Car _car;
    private ParkingLot _lot;

    public ParkingLotTest()
    {
        _lot = new ParkingLot(2);
        _car = new Car();
    }

    public void Dispose()
    {
    }

    [Fact]
    public void ShouldParkCar()
    {
        // Arrange
        // Act
        // Assert
        _lot.HasCar(_car).Should().BeFalse();
        // Act
        _lot.Park(_car);
        // Assert
        _lot.HasCar(_car).Should().BeTrue();
    }

    [Fact]
    public void ShouldNotParkSameCar()
    {
        // Arrange
        _lot.Park(_car);
        // Act
        var action = () => _lot.Park(_car);
        // Assert
        action.Should().Throw<ArgumentException>()
            .Where(e => e.Message.Contains("has been parked"));
    }

    [Fact]
    public void ShouldUnparkParkedCar()
    {
        // Arrange
        _lot.Park(_car);
        // Act
        _lot.Unpark(_car);
        // Assert
        _lot.HasCar(_car).Should().BeFalse();
    }

    [Fact]
    public void ShouldNotUnparkUnknownCar()
    {
        // Arrange
        // Act
        var action = () => _lot.Unpark(_car);
        // Assert
        action.Should().Throw<ArgumentException>().WithMessage("Failed to unpark car *");
    }

    [Fact]
    public void ShouldNotParkCarWhileParkingLotIsFull()
    {
        // Arrange
        _lot = new ParkingLot(0);
        // Act
        var action = () => _lot.Park(_car);
        // Assert
        action.Should().Throw<Exception>().WithMessage("No lot for more car");
    }

    [Fact]
    public void ShouldPrintStatus()
    {
        // Arrange
        _lot = new ParkingLot(1);
        // Act
        var status = _lot.GetStatus();
        // Assert
        status.Should().Be("[ParkingLot: 1 total, 0 occupied, 1 available]");
        // Arrange
        _lot.Park(_car);
        // Act
        status = _lot.GetStatus();
        // Assert
        status.Should().Be("[ParkingLot: 1 total, 1 occupied, 0 available]");
    }
}