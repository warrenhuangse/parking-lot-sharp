using FluentAssertions;

namespace ParkingLotStep7.FluentAssertions.Tests;

public class ParkingManagerTest : BaseParkingRoleTest<ParkingManager, ParkingLot, ParkingBoy>
{
    private readonly IParkingStrategy _strategy = new FirstAvailabilityParkingStrategy();

    public ParkingManagerTest()
    {
        Parkable1 = new ParkingLot(1);
        Parkable2 = new ParkingBoy(new ParkingLot(1), new ParkingLot(1), _strategy);
        Role = new ParkingManager(Parkable1, Parkable2, _strategy);
    }

    protected override ParkingManager Role { get; }

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
    public void ShouldParSecondLotWhileFirstLotIsFull()
    {
        // Arrange
        Role.Park(Car);
        var secondCar = new Car();
        // Act
        Role.Park(secondCar);
        // Assert
        Parkable1.HasCar(secondCar).Should().BeFalse();
        Parkable2.HasCar(secondCar).Should().BeTrue();

        Role.HasCar(Car).Should().BeTrue();
        Role.HasCar(secondCar).Should().BeTrue();
        Role.GetAvailability().Should().Be(1);
    }

    [Fact]
    public void ShouldPrintStatus()
    {
        // Arrange
        // Act
        var status = Role.GetStatus();
        // Assert
        status.Should().Be("[ParkingManager: 3 total, 0 occupied, 3 available"
                           + Environment.NewLine
                           + "\t[ParkingLot: 1 total, 0 occupied, 1 available],"
                           + Environment.NewLine
                           + "\t[ParkingBoy: 2 total, 0 occupied, 2 available"
                           + Environment.NewLine
                           + "\t\t[ParkingLot: 1 total, 0 occupied, 1 available],"
                           + Environment.NewLine
                           + "\t\t[ParkingLot: 1 total, 0 occupied, 1 available]]]");
        // Arrange
        Role.Park(Car);
        // Act
        status = Role.GetStatus();
        // Assert
        status.Should().Be("[ParkingManager: 3 total, 1 occupied, 2 available"
                           + Environment.NewLine
                           + "\t[ParkingLot: 1 total, 1 occupied, 0 available],"
                           + Environment.NewLine
                           + "\t[ParkingBoy: 2 total, 0 occupied, 2 available"
                           + Environment.NewLine
                           + "\t\t[ParkingLot: 1 total, 0 occupied, 1 available],"
                           + Environment.NewLine
                           + "\t\t[ParkingLot: 1 total, 0 occupied, 1 available]]]");
    }
}