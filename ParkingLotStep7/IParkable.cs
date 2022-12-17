namespace ParkingLotStep7;

public interface IParkable
{
    void Park(Car car);
    void Unpark(Car car);
    bool HasCar(Car car);
    bool IsFull();
    int GetAvailability();
    int GetCapacity();
    string GetStatus();
    string GetStatus(int level);
}