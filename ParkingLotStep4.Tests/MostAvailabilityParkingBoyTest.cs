namespace ParkingLotStep4.Tests;

public class MostAvailabilityParkingBoyTest : BaseParkingBoyTest<ParkingBoy>
{
    private readonly IParkingStrategy _strategy = new MostAvailabilityParkingStrategy();
    private ParkingBoy? _boy;
    protected override ParkingBoy Boy => _boy ?? new ParkingBoy(Lot1, Lot2, _strategy);

    [Fact]
    public void ShouldParkFirstWhileFirstLotHasMoreAvailability()
    {
        Lot1 = new ParkingLot(2);
        Lot2 = new ParkingLot(1);
        _boy = new ParkingBoy(Lot1, Lot2, _strategy);
        Boy.Park(Car);
        Assert.True(Lot1.HasCar(Car));
        Assert.False(Lot2.HasCar(Car));
    }
    
    [Fact]
    public void ShouldParkSecondWhileSecondLotHasMoreAvailability()
    {
        Lot1 = new ParkingLot(1);
        Lot2 = new ParkingLot(2);
        _boy = new ParkingBoy(Lot1, Lot2, _strategy);
        Boy.Park(Car);
        Assert.False(Lot1.HasCar(Car));
        Assert.True(Lot2.HasCar(Car));
    }
    
    [Fact]
    public void ShouldParkFirstWhileTwoLotsHaveSameAvailability()
    {
        Lot1 = new ParkingLot(2);
        Lot2 = new ParkingLot(2);
        _boy = new ParkingBoy(Lot1, Lot2, _strategy);
        Boy.Park(Car);
        Assert.True(Lot1.HasCar(Car));
        Assert.False(Lot2.HasCar(Car));
    }
}