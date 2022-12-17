namespace ParkingLotStep3.Tests;

public class FirstAvailabilityParkingBoyTest : BaseParkingBoyTest<FirstAvailabilityParkingBoy>
{
    protected override FirstAvailabilityParkingBoy Boy => new(Lot1, Lot2);

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