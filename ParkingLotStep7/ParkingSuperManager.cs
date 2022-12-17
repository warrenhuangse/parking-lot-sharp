namespace ParkingLotStep7;

public class ParkingSuperManager : ParkingRole
{
    protected override string Name => "ParkingSuperManager";
    
    public ParkingSuperManager(IParkable parkable1, IParkable parkable2, IParkingStrategy strategy)
        : base(parkable1, parkable2, strategy)
    {
    }
}