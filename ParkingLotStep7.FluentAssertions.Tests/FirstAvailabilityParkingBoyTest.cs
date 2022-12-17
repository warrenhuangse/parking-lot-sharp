using FluentAssertions;

namespace ParkingLotStep7.FluentAssertions.Tests;

public class FirstAvailabilityParkingBoyTest : BaseParkingBoyTest
{
    private readonly IParkingStrategy _strategy = new FirstAvailabilityParkingStrategy();

    protected override ParkingBoy Role => new(Parkable1, Parkable2, _strategy);

    [Fact]
    public void ShouldParkFirstLotFirst()
    {
        // Arrange
        // Act
        Role.Park(Car);
        // Assert
        Parkable1.HasCar(Car).Should().BeTrue();
        Parkable2.HasCar(Car).Should().BeFalse();
    }

    [Fact]
    public void ShouldParkSecondLotWhileFirstLotIsFull()
    {
        // Arrange
        Role.Park(Car);
        // Act
        var secondCar = new Car();
        Role.Park(secondCar);
        // Assert
        Parkable1.HasCar(secondCar).Should().BeFalse();
        Parkable2.HasCar(secondCar).Should().BeTrue();
    }

    [Fact]
    public void ShouldPrintStatus()
    {
        // Arrange
        // Act
        var status = Role.GetStatus();
        // Assert
        status.Should().Be("[ParkingBoy: 2 total, 0 occupied, 2 available"
                           + Environment.NewLine
                           + "\t[ParkingLot: 1 total, 0 occupied, 1 available],"
                           + Environment.NewLine
                           + "\t[ParkingLot: 1 total, 0 occupied, 1 available]]");
        // Arrange
        Role.Park(Car);
        // Act
        status = Role.GetStatus();
        // Assert
        status.Should().Be("[ParkingBoy: 2 total, 1 occupied, 1 available"
                           + Environment.NewLine
                           + "\t[ParkingLot: 1 total, 1 occupied, 0 available],"
                           + Environment.NewLine
                           + "\t[ParkingLot: 1 total, 0 occupied, 1 available]]");
    }
}