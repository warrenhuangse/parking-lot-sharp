namespace ParkingLotStep7.Tests;

public class LeastAvailabilityParkingBoyTest : BaseParkingBoyTest
{
    private readonly IParkingStrategy _strategy = new LeastAvailabilityParkingStrategy();
    private ParkingBoy? _boy;

    protected override ParkingBoy Role => _boy ?? new ParkingBoy(Parkable1, Parkable2, _strategy);

    [Fact]
    public void ShouldParkFirstWhileFirstLotHasLeastAvailability()
    {
        Parkable1 = new ParkingLot(1);
        Parkable2 = new ParkingLot(2);
        var role = new ParkingBoy(Parkable1, Parkable2, _strategy);
        role.Park(Car);
        Assert.True(Parkable1.HasCar(Car));
        Assert.False(Parkable2.HasCar(Car));
    }

    [Fact]
    public void ShouldParkSecondWhileSecondLotHasLeastAvailability()
    {
        Parkable1 = new ParkingLot(2);
        Parkable2 = new ParkingLot(1);
        var role = new ParkingBoy(Parkable1, Parkable2, _strategy);
        role.Park(Car);
        Assert.False(Parkable1.HasCar(Car));
        Assert.True(Parkable2.HasCar(Car));
    }

    [Fact]
    public void ShouldParkFirstWhileTwoLotsHaveSameAvailability()
    {
        Parkable1 = new ParkingLot(2);
        Parkable2 = new ParkingLot(2);
        var role = new ParkingBoy(Parkable1, Parkable2, _strategy);
        role.Park(Car);
        Assert.True(Parkable1.HasCar(Car));
        Assert.False(Parkable2.HasCar(Car));
    }
}