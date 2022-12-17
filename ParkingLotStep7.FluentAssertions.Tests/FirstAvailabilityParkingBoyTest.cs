namespace ParkingLotStep7.FluentAssertions.Tests;

public class FirstAvailabilityParkingBoyTest : BaseParkingBoyTest
{
    private readonly IParkingStrategy _strategy = new FirstAvailabilityParkingStrategy();

    protected override ParkingBoy Role => new(Parkable1, Parkable2, _strategy);

    [Fact]
    public void ShouldParkFirstLotFirst()
    {
        Role.Park(Car);
        Assert.True(Parkable1.HasCar(Car));
        Assert.False(Parkable2.HasCar(Car));
    }

    [Fact]
    public void ShouldParkSecondLotWhileFirstLotIsFull()
    {
        Role.Park(Car);
        var secondCar = new Car();
        Role.Park(secondCar);
        Assert.False(Parkable1.HasCar(secondCar));
        Assert.True(Parkable2.HasCar(secondCar));
    }

    [Fact]
    public void ShouldPrintStatus()
    {
        Assert.Equal(
            "[ParkingBoy: 2 total, 0 occupied, 2 available"
            + Environment.NewLine
            + "\t[ParkingLot: 1 total, 0 occupied, 1 available],"
            + Environment.NewLine
            + "\t[ParkingLot: 1 total, 0 occupied, 1 available]]",
            Role.GetStatus());
        Role.Park(Car);
        Assert.Equal(
            "[ParkingBoy: 2 total, 1 occupied, 1 available"
            + Environment.NewLine
            + "\t[ParkingLot: 1 total, 1 occupied, 0 available],"
            + Environment.NewLine
            + "\t[ParkingLot: 1 total, 0 occupied, 1 available]]",
            Role.GetStatus());
    }
}