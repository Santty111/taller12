using Best_Practices.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Best_Practices.Repositories
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly ConcurrentDictionary<Guid, Vehicle> _vehicles = new ConcurrentDictionary<Guid, Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }
            _vehicles[vehicle.ID] = vehicle;
        }

        public Vehicle Find(string id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                _vehicles.TryGetValue(guid, out var vehicle);
                return vehicle;
            }
            return null;
        }

        public ICollection<Vehicle> GetVehicles()
        {
            return _vehicles.Values;
        }
    }
}
