namespace ParkingLotStep5.Tests;

public abstract class BaseParkingBoyTest : BaseParkingRoleTest<ParkingBoy, ParkingLot, ParkingLot>
{
    protected BaseParkingBoyTest()
    {
        Parkable1 = new ParkingLot(1);
        Parkable2 = new ParkingLot(1);
    }
}