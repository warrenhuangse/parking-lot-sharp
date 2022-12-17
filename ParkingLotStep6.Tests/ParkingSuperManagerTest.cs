namespace ParkingLotStep6.Tests;

public class ParkingSuperManagerTest : BaseParkingRoleTest<ParkingSuperManager, ParkingLot, ParkingManager>
{
    private readonly IParkingStrategy _strategy = new FirstAvailabilityParkingStrategy();

    public ParkingSuperManagerTest()
    {
        Parkable1 = new ParkingLot(1);
        var boy = new ParkingBoy(new ParkingLot(1), new ParkingLot(1), _strategy);
        Parkable2 = new ParkingManager(new ParkingLot(1), boy, _strategy);
        Role = new ParkingSuperManager(Parkable1, Parkable2, _strategy);
    }

    protected override ParkingSuperManager Role { get; }

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
        Assert.Equal(2, Role.GetAvailability());
    }
}