namespace ParkingLotStep5.Tests;

public class ParkingManagerTest : BaseParkingRoleTest<ParkingManager, ParkingLot, ParkingBoy>
{
    private readonly IParkingStrategy _strategy = new FirstAvailabilityParkingStrategy();
    private ParkingManager _manager;
    protected override ParkingManager Role => _manager;
    
    public ParkingManagerTest()
    {
        Parkable1 = new ParkingLot(1);
        Parkable2 = new ParkingBoy(new ParkingLot(1), new ParkingLot(1), _strategy);
        _manager = new ParkingManager(Parkable1, Parkable2, _strategy);
    }

    [Fact]
    public void ShouldParkFirstLotFirst()
    {
        Role.Park(Car);
        Assert.True(Parkable1.HasCar(Car));
        Assert.False(Parkable2.HasCar(Car));
    }

    [Fact]
    public void ShouldParSecondLotWhileFirstLotIsFull()
    {
        Role.Park(Car);
        var secondCar = new Car();
        Role.Park(secondCar);
        Assert.False(Parkable1.HasCar(secondCar));
        Assert.True(Parkable2.HasCar(secondCar));
        
        Assert.True(Role.HasCar(Car));
        Assert.True(Role.HasCar(secondCar));
        Assert.Equal(1, Role.GetAvailability());
    }
}