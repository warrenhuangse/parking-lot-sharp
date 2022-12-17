using FluentAssertions;

namespace ParkingLotStep7.FluentAssertions.Tests;

public class MostAvailabilityParkingBoyTest : BaseParkingBoyTest
{
    private readonly IParkingStrategy _strategy = new MostAvailabilityParkingStrategy();
    private ParkingBoy? _boy;
    protected override ParkingBoy Role => _boy ?? new ParkingBoy(Parkable1, Parkable2, _strategy);

    [Fact]
    public void ShouldParkFirstWhileFirstLotHasMoreAvailability()
    {
        // Arrange
        Parkable1 = new ParkingLot(2);
        Parkable2 = new ParkingLot(1);
        _boy = new ParkingBoy(Parkable1, Parkable2, _strategy);
        // Act
        Role.Park(Car);
        // Assert
        Parkable1.HasCar(Car).Should().BeTrue();
        Parkable2.HasCar(Car).Should().BeFalse();
    }

    [Fact]
    public void ShouldParkSecondWhileSecondLotHasMoreAvailability()
    {
        // Arrange
        Parkable1 = new ParkingLot(1);
        Parkable2 = new ParkingLot(2);
        _boy = new ParkingBoy(Parkable1, Parkable2, _strategy);
        // Act
        Role.Park(Car);
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
        _boy = new ParkingBoy(Parkable1, Parkable2, _strategy);
        // Act
        Role.Park(Car);
        // Assert
        Parkable1.HasCar(Car).Should().BeTrue();
        Parkable2.HasCar(Car).Should().BeFalse();
    }
}