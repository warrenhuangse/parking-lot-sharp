using FluentAssertions;

namespace ParkingLotStep7.FluentAssertions.Tests;

public class LeastAvailabilityParkingBoyTest : BaseParkingBoyTest
{
    private readonly IParkingStrategy _strategy = new LeastAvailabilityParkingStrategy();
    private ParkingBoy? _boy;

    protected override ParkingBoy Role => _boy ?? new ParkingBoy(Parkable1, Parkable2, _strategy);

    [Fact]
    public void ShouldParkFirstWhileFirstLotHasLeastAvailability()
    {
        // Arrange
        Parkable1 = new ParkingLot(1);
        Parkable2 = new ParkingLot(2);
        var role = new ParkingBoy(Parkable1, Parkable2, _strategy);
        // Act
        role.Park(Car);
        // Assert
        Parkable1.HasCar(Car).Should().BeTrue();
        Parkable2.HasCar(Car).Should().BeFalse();
    }

    [Fact]
    public void ShouldParkSecondWhileSecondLotHasLeastAvailability()
    {
        // Arrange
        Parkable1 = new ParkingLot(2);
        Parkable2 = new ParkingLot(1);
        var role = new ParkingBoy(Parkable1, Parkable2, _strategy);
        // Act
        role.Park(Car);
        // Assert
        Parkable1.HasCar(Car).Should().BeFalse();
        Parkable2.HasCar(Car).Should().BeTrue();
    }

    [Fact]
    public void ShouldParkFirstWhileTwoLotsHaveSameAvailability()
    {
        // Arrange
        Parkable1 = new ParkingLot(2);
        Parkable2 = new ParkingLot(2);
        var role = new ParkingBoy(Parkable1, Parkable2, _strategy);
        // Act
        role.Park(Car);
        // Assert
        Parkable1.HasCar(Car).Should().BeTrue();
        Parkable2.HasCar(Car).Should().BeFalse();
    }
}