namespace ParkingLotStep3.Tests;

public class MostAvailabilityParkingBoyTest : BaseParkingBoyTest<MostAvailabilityParkingBoy>
{
    protected override MostAvailabilityParkingBoy Boy => new(Lot1, Lot2);

    [Fact]
    public void ShouldParkFirstWhileFirstLotHasMoreAvailability()
    {
        Lot1 = new ParkingLot(2);
        Lot2 = new ParkingLot(1);
        Boy.Park(Car);
        Assert.True(Lot1.HasCar(Car));
        Assert.False(Lot2.HasCar(Car));
    }

    [Fact]
    public void ShouldParkSecondWhileSecondLotHasMoreAvailability()
    {
        Lot1 = new ParkingLot(1);
        Lot2 = new ParkingLot(2);
        Boy.Park(Car);
        Assert.False(Lot1.HasCar(Car));
        Assert.True(Lot2.HasCar(Car));
    }

    [Fact]
    public void ShouldParkFirstWhileTwoLotsHaveSameAvailability()
    {
        Lot1 = new ParkingLot(2);
        Lot2 = new ParkingLot(2);
        Boy.Park(Car);
        Assert.True(Lot1.HasCar(Car));
        Assert.False(Lot2.HasCar(Car));
    }
}