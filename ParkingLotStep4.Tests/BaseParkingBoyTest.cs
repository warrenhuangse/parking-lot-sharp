namespace ParkingLotStep4.Tests;

public abstract class BaseParkingBoyTest<T> : IDisposable
    where T : ParkingBoy
{
    protected readonly Car Car;
    protected ParkingLot Lot1;
    protected ParkingLot Lot2;

    protected BaseParkingBoyTest()
    {
        Lot1 = new ParkingLot(1);
        Lot2 = new ParkingLot(1);
        Car = new Car();
    }

    protected abstract T Boy { get; }

    public void Dispose()
    {
    }

    [Fact]
    public void ShouldNotParkLotWhileTwoLotsAreFull()
    {
        Boy.Park(Car);
        var secondCar = new Car();
        Boy.Park(secondCar);

        var thirdCar = new Car();
        Assert.Throws<Exception>(() => Boy.Park(thirdCar));
    }

    [Fact]
    public void ShouldNotParkSameCar()
    {
        Boy.Park(Car);
        Assert.Throws<ArgumentException>(() => Boy.Park(Car));

        var secondCar = new Car();
        Boy.Park(secondCar);
        Assert.Throws<ArgumentException>(() => Boy.Park(secondCar));
    }

    [Fact]
    public void ShouldUnparkFirstLotCar()
    {
        Boy.Park(Car);
        Boy.Unpark(Car);
        Assert.False(Lot1.HasCar(Car));
        Assert.False(Lot2.HasCar(Car));
    }

    [Fact]
    public void ShouldUnparkSecondLotCar()
    {
        Boy.Park(Car);
        var secondCar = new Car();
        Boy.Park(secondCar);
        Boy.Unpark(secondCar);
        Assert.False(Lot1.HasCar(secondCar));
        Assert.False(Lot2.HasCar(secondCar));
    }

    [Fact]
    public void ShouldNotUnparkUnknownCar()
    {
        Assert.Throws<ArgumentException>(() => Boy.Unpark(Car));
    }
}