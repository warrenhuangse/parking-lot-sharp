namespace ParkingLotStep7.Tests;

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

    [Fact]
    public void ShouldPrintStatus()
    {
        Assert.Equal(
            "[ParkingSuperManager: 4 total, 0 occupied, 4 available"
            + Environment.NewLine
            + "\t[ParkingLot: 1 total, 0 occupied, 1 available],"
            + Environment.NewLine
            + "\t[ParkingManager: 3 total, 0 occupied, 3 available"
            + Environment.NewLine
            + "\t\t[ParkingLot: 1 total, 0 occupied, 1 available],"
            + Environment.NewLine
            + "\t\t[ParkingBoy: 2 total, 0 occupied, 2 available"
            + Environment.NewLine
            + "\t\t\t[ParkingLot: 1 total, 0 occupied, 1 available],"
            + Environment.NewLine
            + "\t\t\t[ParkingLot: 1 total, 0 occupied, 1 available]]]]",
            Role.GetStatus());
        Role.Park(Car);
        Assert.Equal(
            "[ParkingSuperManager: 4 total, 1 occupied, 3 available"
            + Environment.NewLine
            + "\t[ParkingLot: 1 total, 1 occupied, 0 available],"
            + Environment.NewLine
            + "\t[ParkingManager: 3 total, 0 occupied, 3 available"
            + Environment.NewLine
            + "\t\t[ParkingLot: 1 total, 0 occupied, 1 available],"
            + Environment.NewLine
            + "\t\t[ParkingBoy: 2 total, 0 occupied, 2 available"
            + Environment.NewLine
            + "\t\t\t[ParkingLot: 1 total, 0 occupied, 1 available],"
            + Environment.NewLine
            + "\t\t\t[ParkingLot: 1 total, 0 occupied, 1 available]]]]",
            Role.GetStatus());
    }
}