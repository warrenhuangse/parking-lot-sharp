namespace ParkingLotStep5;

public interface IParkable
{
    void Park(Car car);
    void Unpark(Car car);
    bool HasCar(Car car);
    bool IsFull();
    int GetAvailability();
}