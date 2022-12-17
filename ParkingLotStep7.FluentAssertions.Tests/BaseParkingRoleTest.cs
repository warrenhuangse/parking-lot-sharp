using FluentAssertions;

namespace ParkingLotStep7.FluentAssertions.Tests;

public abstract class BaseParkingRoleTest<TRole, TParkable1, TParkable2> : IDisposable
    where TRole : ParkingRole where TParkable1 : IParkable where TParkable2 : IParkable
{
    protected readonly Car Car;
    protected TParkable1 Parkable1;
    protected TParkable2 Parkable2;

    protected BaseParkingRoleTest()
    {
        Car = new Car();
    }

    protected abstract TRole Role { get; }

    public void Dispose()
    {
    }

    [Fact]
    public void ShouldNotParkLotWhileRoleAreFull()
    {
        // Arrange
        while (!Role.IsFull())
        {
            Role.Park(new Car());
        }
        // Act
        var action = () => Role.Park(Car);
        // Assert
        action.Should().Throw<Exception>().WithMessage("No lot for more cars");
    }

    [Fact]
    public void ShouldNotParkSameCar()
    {
        // Arrange
        Role.Park(Car);
        // Act
        var action = () => Role.Park(Car);
        // Assert
        action.Should().Throw<ArgumentException>().WithMessage("Car * has been parked");

        // Arrange
        var secondCar = new Car();
        Role.Park(secondCar);
        // Act
        action = () => Role.Park(secondCar);
        // Assert
        action.Should().Throw<ArgumentException>()
            .Where(ex => ex.Message.Contains("has been parked"));
    }

    [Fact]
    public void ShouldUnparkFirstLotCar()
    {
        // Arrange
        Role.Park(Car);
        // Act
        Role.Unpark(Car);
        // Assert
        Parkable1.HasCar(Car).Should().BeFalse();
        Parkable2.HasCar(Car).Should().BeFalse();
    }

    [Fact]
    public void ShouldUnparkSecondLotCar()
    {
        // Arrange
        Role.Park(Car);
        var secondCar = new Car();
        Role.Park(secondCar);
        // Act
        Role.Unpark(secondCar);
        // Assert
        Parkable1.HasCar(secondCar).Should().BeFalse();
        Parkable2.HasCar(secondCar).Should().BeFalse();
    }

    [Fact]
    public void ShouldUnparkUnknownCar()
    {
        // Arrange
        // Act
        var action = () => Role.Unpark(Car);
        // Assert
        action.Should().Throw<ArgumentException>()
            .Where(ex => ex.Message.StartsWith("Failed to unpark car"));
    }
}