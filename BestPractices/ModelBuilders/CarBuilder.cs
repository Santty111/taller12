using Best_Practices.Models;
using System;

namespace Best_Practices.ModelBuilders
{
    public class CarBuilder : IVehicleBuilder
    {
        // Valores por defecto
        private string _brand = "Ford";
        private string _model = "Mustang";
        private string _color = "Red";
        private double _fuelLimit = 10.0;
        private int _year = DateTime.Now.Year;

        // 20+ propiedades con sus valores por defecto
        private bool _hasGPS = false;
        private bool _hasAirConditioning = true;
        private bool _hasSunroof = false;
        private bool _hasLeatherSeats = false;
        private bool _hasBluetooth = true;
        private bool _hasBackupCamera = true;
        private bool _hasHeatedSeats = false;
        private bool _hasBlindSpotMonitor = false;
        private bool _hasLaneKeepAssist = false;
        private bool _hasAdaptiveCruiseControl = false;
        private bool _hasAppleCarPlay = true;
        private bool _hasAndroidAuto = true;
        private bool _hasWifi = false;
        private bool _hasTurbo = false;
        private bool _hasAllWheelDrive = false;
        private bool _hasThirdRowSeating = false;
        private bool _hasRoofRack = false;
        private bool _hasTowHitch = false;
        private bool _hasKeylessEntry = true;
        private bool _hasRemoteStart = false;

        public IVehicleBuilder SetBrand(string brand)
        {
            _brand = brand;
            return this;
        }

        public IVehicleBuilder SetModel(string model)
        {
            _model = model;
            return this;
        }

        public IVehicleBuilder SetColor(string color)
        {
            _color = color;
            return this;
        }

        public IVehicleBuilder SetFuelLimit(double limit)
        {
            _fuelLimit = limit;
            return this;
        }

        public IVehicleBuilder SetYear(int year)
        {
            _year = year;
            return this;
        }

        public IVehicleBuilder SetGPS(bool hasGPS)
        {
            _hasGPS = hasGPS;
            return this;
        }

        public IVehicleBuilder SetAirConditioning(bool hasAC)
        {
            _hasAirConditioning = hasAC;
            return this;
        }

        public IVehicleBuilder SetSunroof(bool hasSunroof)
        {
            _hasSunroof = hasSunroof;
            return this;
        }

        public IVehicleBuilder SetLeatherSeats(bool hasLeatherSeats)
        {
            _hasLeatherSeats = hasLeatherSeats;
            return this;
        }

        public IVehicleBuilder SetBluetooth(bool hasBluetooth)
        {
            _hasBluetooth = hasBluetooth;
            return this;
        }

        public IVehicleBuilder SetBackupCamera(bool hasBackupCamera)
        {
            _hasBackupCamera = hasBackupCamera;
            return this;
        }

        public IVehicleBuilder SetHeatedSeats(bool hasHeatedSeats)
        {
            _hasHeatedSeats = hasHeatedSeats;
            return this;
        }

        public IVehicleBuilder SetBlindSpotMonitor(bool hasBlindSpotMonitor)
        {
            _hasBlindSpotMonitor = hasBlindSpotMonitor;
            return this;
        }

        public IVehicleBuilder SetLaneKeepAssist(bool hasLaneKeepAssist)
        {
            _hasLaneKeepAssist = hasLaneKeepAssist;
            return this;
        }

        public IVehicleBuilder SetAdaptiveCruiseControl(bool hasAdaptiveCruiseControl)
        {
            _hasAdaptiveCruiseControl = hasAdaptiveCruiseControl;
            return this;
        }

        public IVehicleBuilder SetAppleCarPlay(bool hasAppleCarPlay)
        {
            _hasAppleCarPlay = hasAppleCarPlay;
            return this;
        }

        public IVehicleBuilder SetAndroidAuto(bool hasAndroidAuto)
        {
            _hasAndroidAuto = hasAndroidAuto;
            return this;
        }

        public IVehicleBuilder SetWifi(bool hasWifi)
        {
            _hasWifi = hasWifi;
            return this;
        }

        public IVehicleBuilder SetTurbo(bool hasTurbo)
        {
            _hasTurbo = hasTurbo;
            return this;
        }

        public IVehicleBuilder SetAllWheelDrive(bool hasAllWheelDrive)
        {
            _hasAllWheelDrive = hasAllWheelDrive;
            return this;
        }

        public IVehicleBuilder SetThirdRowSeating(bool hasThirdRowSeating)
        {
            _hasThirdRowSeating = hasThirdRowSeating;
            return this;
        }

        public IVehicleBuilder SetRoofRack(bool hasRoofRack)
        {
            _hasRoofRack = hasRoofRack;
            return this;
        }

        public IVehicleBuilder SetTowHitch(bool hasTowHitch)
        {
            _hasTowHitch = hasTowHitch;
            return this;
        }

        public IVehicleBuilder SetKeylessEntry(bool hasKeylessEntry)
        {
            _hasKeylessEntry = hasKeylessEntry;
            return this;
        }

        public IVehicleBuilder SetRemoteStart(bool hasRemoteStart)
        {
            _hasRemoteStart = hasRemoteStart;
            return this;
        }

        public Vehicle Build()
        {
            var car = new Car(_color, _brand, _model)
            {
                FuelLimit = _fuelLimit,
                Year = _year,
                HasGPS = _hasGPS,
                HasAirConditioning = _hasAirConditioning,
                HasSunroof = _hasSunroof,
                HasLeatherSeats = _hasLeatherSeats,
                HasBluetooth = _hasBluetooth,
                HasBackupCamera = _hasBackupCamera,
                HasHeatedSeats = _hasHeatedSeats,
                HasBlindSpotMonitor = _hasBlindSpotMonitor,
                HasLaneKeepAssist = _hasLaneKeepAssist,
                HasAdaptiveCruiseControl = _hasAdaptiveCruiseControl,
                HasAppleCarPlay = _hasAppleCarPlay,
                HasAndroidAuto = _hasAndroidAuto,
                HasWifi = _hasWifi,
                HasTurbo = _hasTurbo,
                HasAllWheelDrive = _hasAllWheelDrive,
                HasThirdRowSeating = _hasThirdRowSeating,
                HasRoofRack = _hasRoofRack,
                HasTowHitch = _hasTowHitch,
                HasKeylessEntry = _hasKeylessEntry,
                HasRemoteStart = _hasRemoteStart
            };

            return car;
        }
    }
}
