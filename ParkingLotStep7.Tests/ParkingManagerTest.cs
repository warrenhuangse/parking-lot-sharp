namespace ParkingLotStep7.Tests;

public class ParkingManagerTest : BaseParkingRoleTest<ParkingManager, ParkingLot, ParkingBoy>
{
    private readonly IParkingStrategy _strategy = new FirstAvailabilityParkingStrategy();

    public ParkingManagerTest()
    {
        Parkable1 = new ParkingLot(1);
        Parkable2 = new ParkingBoy(new ParkingLot(1), new ParkingLot(1), _strategy);
        Role = new ParkingManager(Parkable1, Parkable2, _strategy);
    }

    protected override ParkingManager Role { get; }

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

    [Fact]
    public void ShouldPrintStatus()
    {
        Assert.Equal(
            "[ParkingManager: 3 total, 0 occupied, 3 available" 
            + Environment.NewLine
            + "\t[ParkingLot: 1 total, 0 occupied, 1 available]," 
            + Environment.NewLine
            + "\t[ParkingBoy: 2 total, 0 occupied, 2 available" 
            + Environment.NewLine
            + "\t\t[ParkingLot: 1 total, 0 occupied, 1 available]," 
            + Environment.NewLine
            + "\t\t[ParkingLot: 1 total, 0 occupied, 1 available]]]"
            ,Role.GetStatus());
        Role.Park(Car);
        Assert.Equal(
            "[ParkingManager: 3 total, 1 occupied, 2 available" 
            + Environment.NewLine 
            + "\t[ParkingLot: 1 total, 1 occupied, 0 available]," 
            + Environment.NewLine
            + "\t[ParkingBoy: 2 total, 0 occupied, 2 available" 
            + Environment.NewLine
            + "\t\t[ParkingLot: 1 total, 0 occupied, 1 available],"  
            + Environment.NewLine
            + "\t\t[ParkingLot: 1 total, 0 occupied, 1 available]]]"
            , Role.GetStatus());
    }
}