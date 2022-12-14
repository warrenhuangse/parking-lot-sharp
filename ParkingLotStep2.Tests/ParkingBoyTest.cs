namespace ParkingLotStep2.Tests;

public class ParkingBoyTest : IDisposable
{
    private ParkingBoy _boy;
    private Car _car;
    private ParkingLot _lot1;
    private ParkingLot _lot2;

    public ParkingBoyTest()
    {
        _lot1 = new ParkingLot(1);
        _lot2 = new ParkingLot(1);
        _boy = new ParkingBoy(_lot1, _lot2);
        _car = new Car();
    }

    public void Dispose()
    {
    }

    [Fact]
    public void ShouldParkFirstLotFirst()
    {
        _boy.Park(_car);
        Assert.True(_lot1.HasCar(_car));
        Assert.False(_lot2.HasCar(_car));
    }

    [Fact]
    public void ShouldParkSecondLotWhileFirstLotIsFull()
    {
        _boy.Park(_car);
        var secondCar = new Car();
        _boy.Park(secondCar);
        Assert.False(_lot1.HasCar(secondCar));
        Assert.True(_lot2.HasCar(secondCar));
    }

    [Fact]
    public void ShouldNotParkLotWhileTwoLotsAreFull()
    {
        _boy.Park(_car);
        var secondCar = new Car();
        _boy.Park(secondCar);

        var thirdCar = new Car();
        Assert.Throws<Exception>(() => _boy.Park(thirdCar));
    }

    [Fact]
    public void ShouldNotParkSameCar()
    {
        _boy.Park(_car);
        Assert.Throws<ArgumentException>(() => _boy.Park(_car));

        var secondCar = new Car();
        _boy.Park(secondCar);
        Assert.Throws<ArgumentException>(() => _boy.Park(secondCar));
    }

    [Fact]
    public void ShouldUnparkFirstLotCar()
    {
        _boy.Park(_car);
        _boy.Unpark(_car);
        Assert.False(_lot1.HasCar(_car));
        Assert.False(_lot2.HasCar(_car));
    }

    [Fact]
    public void ShouldUnparkSecondLotCar()
    {
        _boy.Park(_car);
        var secondCar = new Car();
        _boy.Park(secondCar);
        _boy.Unpark(secondCar);
        Assert.False(_lot1.HasCar(secondCar));
        Assert.False(_lot2.HasCar(secondCar));
    }

    [Fact]
    public void ShouldNotUnparkUnknownCar()
    {
        Assert.Throws<ArgumentException>(() => _boy.Unpark(_car));
    }
}