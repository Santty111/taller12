using Best_Practices.Models;

namespace Best_Practices.ModelBuilders
{
    public interface IVehicleBuilder
    {
        IVehicleBuilder SetBrand(string brand);
        IVehicleBuilder SetModel(string model);
        IVehicleBuilder SetColor(string color);
        IVehicleBuilder SetFuelLimit(double limit);
        IVehicleBuilder SetYear(int year);

        // Setters para las 20+ propiedades
        IVehicleBuilder SetGPS(bool hasGPS);
        IVehicleBuilder SetAirConditioning(bool hasAC);
        IVehicleBuilder SetSunroof(bool hasSunroof);
        IVehicleBuilder SetLeatherSeats(bool hasLeatherSeats);
        IVehicleBuilder SetBluetooth(bool hasBluetooth);
        IVehicleBuilder SetBackupCamera(bool hasBackupCamera);
        IVehicleBuilder SetHeatedSeats(bool hasHeatedSeats);
        IVehicleBuilder SetBlindSpotMonitor(bool hasBlindSpotMonitor);
        IVehicleBuilder SetLaneKeepAssist(bool hasLaneKeepAssist);
        IVehicleBuilder SetAdaptiveCruiseControl(bool hasAdaptiveCruiseControl);
        IVehicleBuilder SetAppleCarPlay(bool hasAppleCarPlay);
        IVehicleBuilder SetAndroidAuto(bool hasAndroidAuto);
        IVehicleBuilder SetWifi(bool hasWifi);
        IVehicleBuilder SetTurbo(bool hasTurbo);
        IVehicleBuilder SetAllWheelDrive(bool hasAllWheelDrive);
        IVehicleBuilder SetThirdRowSeating(bool hasThirdRowSeating);
        IVehicleBuilder SetRoofRack(bool hasRoofRack);
        IVehicleBuilder SetTowHitch(bool hasTowHitch);
        IVehicleBuilder SetKeylessEntry(bool hasKeylessEntry);
        IVehicleBuilder SetRemoteStart(bool hasRemoteStart);

        Vehicle Build();
    }
}
