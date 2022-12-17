namespace ParkingLotStep7.Tests;

public class MostAvailabilityParkingBoyTest : BaseParkingBoyTest
{
    private readonly IParkingStrategy _strategy = new MostAvailabilityParkingStrategy();
    private ParkingBoy? _boy;
    protected override ParkingBoy Role => _boy ?? new ParkingBoy(Parkable1, Parkable2, _strategy);

    [Fact]
    public void ShouldParkFirstWhileFirstLotHasMoreAvailability()
    {
        Parkable1 = new ParkingLot(2);
        Parkable2 = new ParkingLot(1);
        _boy = new ParkingBoy(Parkable1, Parkable2, _strategy);
        Role.Park(Car);
        Assert.True(Parkable1.HasCar(Car));
        Assert.False(Parkable2.HasCar(Car));
    }

    [Fact]
    public void ShouldParkSecondWhileSecondLotHasMoreAvailability()
    {
        Parkable1 = new ParkingLot(1);
        Parkable2 = new ParkingLot(2);
        _boy = new ParkingBoy(Parkable1, Parkable2, _strategy);
        Role.Park(Car);
        Assert.False(Parkable1.HasCar(Car));
        Assert.True(Parkable2.HasCar(Car));
    }

    [Fact]
    public void ShouldParkFirstWhileTwoLotsHaveSameAvailability()
    {
        Parkable1 = new ParkingLot(2);
        Parkable2 = new ParkingLot(2);
        _boy = new ParkingBoy(Parkable1, Parkable2, _strategy);
        Role.Park(Car);
        Assert.True(Parkable1.HasCar(Car));
        Assert.False(Parkable2.HasCar(Car));
    }
}