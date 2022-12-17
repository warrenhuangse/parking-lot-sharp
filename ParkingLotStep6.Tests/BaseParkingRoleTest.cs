namespace ParkingLotStep6.Tests;

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
        while (!Role.IsFull())
        {
            Role.Park(new Car());
        }
        
        Assert.Throws<Exception>(() => Role.Park(Car));
    }

    [Fact]
    public void ShouldNotParkSameCar()
    {
        Role.Park(Car);
        Assert.Throws<ArgumentException>(() => Role.Park(Car));

        var secondCar = new Car();
        Role.Park(secondCar);
        Assert.Throws<ArgumentException>(() => Role.Park(secondCar));
    }

    [Fact]
    public void ShouldUnparkFirstLotCar()
    {
        Role.Park(Car);
        Role.Unpark(Car);
        Assert.False(Parkable1.HasCar(Car));
        Assert.False(Parkable2.HasCar(Car));
    }

    [Fact]
    public void ShouldUnparkSecondLotCar()
    {
        Role.Park(Car);
        var secondCar = new Car();
        Role.Park(secondCar);
        Role.Unpark(secondCar);
        Assert.False(Parkable1.HasCar(secondCar));
        Assert.False(Parkable2.HasCar(secondCar));
    }

    [Fact]
    public void ShouldUnparkUnknownCar()
    {
        Assert.Throws<ArgumentException>(() => Role.Unpark(Car));
    }
}