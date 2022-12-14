namespace ParkingLotStep1.Tests;

public class ParkingLotTest : IDisposable
{
    private ParkingLot _lot;

    private Car _car;

    public ParkingLotTest()
    {
        _lot = new ParkingLot(2);
        _car = new Car();
    }

    public void Dispose() { }

    [Fact]
    public void ShouldParkCar()
    {
        Assert.False(_lot.HasCar(_car));
        _lot.Park(_car);
        Assert.True(_lot.HasCar(_car));
    }

    [Fact]
    public void ShouldNotParkSameCar()
    {
        _lot.Park(_car);
        
        Assert.Throws<ArgumentException>(() => _lot.Park(_car));
    }
    
    [Fact]
    public void ShouldUnparkParkedCar()
    {
        _lot.Park(_car);
        _lot.Unpark(_car);
        Assert.False(_lot.HasCar(_car));
    }
    
    [Fact]
    public void ShouldNotUnparkUnknownCar()
    {
        Assert.Throws<ArgumentException>(() => _lot.Unpark(_car));
    }
    
    [Fact]
    public void ShouldNotParkCarWhileParkingLotIsFull()
    {
        _lot = new ParkingLot(0);
        Assert.Throws<Exception>(() => _lot.Park(_car));
    }
}