namespace ParkingLotStep4.Tests;

public class FirstAvailabilityParkingBoyTest : BaseParkingBoyTest<ParkingBoy>
{
    protected override ParkingBoy Boy => new ParkingBoy(Lot1, Lot2, new FirstAvailabilityParkingStrategy());

    [Fact]
    public void ShouldParkFirstLotFirst()
    {
        Boy.Park(Car);
        Assert.True(Lot1.HasCar(Car));
        Assert.False(Lot2.HasCar(Car));
    }

    [Fact]
    public void ShouldParkSecondLotWhileFirstLotIsFull()
    {
        Boy.Park(Car);
        var secondCar = new Car();
        Boy.Park(secondCar);
        Assert.False(Lot1.HasCar(secondCar));
        Assert.True(Lot2.HasCar(secondCar));
    }
}