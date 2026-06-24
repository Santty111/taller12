using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Models
{
    public abstract class Vehicle : IVehicle
    {
        #region Private properties
        private bool _isEngineOn { get; set; }
        #endregion

        #region Properties
        public readonly Guid ID;
        public virtual int Tires { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Gas { get; set; }
        public double FuelLimit { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;

        // 20+ Propiedades por defecto solicitadas por el negocio
        public bool HasGPS { get; set; } = false;
        public bool HasAirConditioning { get; set; } = true;
        public bool HasSunroof { get; set; } = false;
        public bool HasLeatherSeats { get; set; } = false;
        public bool HasBluetooth { get; set; } = true;
        public bool HasBackupCamera { get; set; } = true;
        public bool HasHeatedSeats { get; set; } = false;
        public bool HasBlindSpotMonitor { get; set; } = false;
        public bool HasLaneKeepAssist { get; set; } = false;
        public bool HasAdaptiveCruiseControl { get; set; } = false;
        public bool HasAppleCarPlay { get; set; } = true;
        public bool HasAndroidAuto { get; set; } = true;
        public bool HasWifi { get; set; } = false;
        public bool HasTurbo { get; set; } = false;
        public bool HasAllWheelDrive { get; set; } = false;
        public bool HasThirdRowSeating { get; set; } = false;
        public bool HasRoofRack { get; set; } = false;
        public bool HasTowHitch { get; set; } = false;
        public bool HasKeylessEntry { get; set; } = true;
        public bool HasRemoteStart { get; set; } = false;

        #endregion

        #region Constructors

        public Vehicle(string color, string brand, string model, double fuelLimit = 10)
        {
            ID = Guid.NewGuid();
            Color = color;
            Brand = brand;
            Model = model;
            FuelLimit = fuelLimit;
        }

        #endregion

        #region Methods
        public void AddGas()
        {
            if(Gas + 0.1 <= FuelLimit)
            {
                Gas += 0.1;
            }
            else
            {
                throw new Exception("Gas Full");
            }
        }
        public void StartEngine()
        {
            if (_isEngineOn)
            {
                throw new Exception("Engine is already on");
            }
            if (NeedsGas())
            {
                throw new Exception("No enoguht gas. You need to go to Gas Station");
            }
            _isEngineOn = true;
        }

        public bool NeedsGas()
        {
            return !(Gas > 0);
        }

        public bool IsEngineOn()
        {
            return _isEngineOn;
        }

        public void StopEngine()
        {
            if (!_isEngineOn)
            {
                throw new Exception("Enigne already stopped");
            }

            _isEngineOn = false;
        }

        #endregion

    }
}
