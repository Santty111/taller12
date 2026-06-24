using System;
using System.Linq;
using Best_Practices.Models;
using Best_Practices.Repositories;
using Best_Practices.ModelBuilders;
using Best_Practices.Infraestructure.Factories;
using Xunit;

namespace BestPractices.Tests
{
    public class VehicleDomainTests
    {
        [Fact]
        public void StartEngine_WithoutGas_ShouldThrowException()
        {
            // Arrange
            var vehicle = new Car("Red", "Ford", "Mustang");
            vehicle.Gas = 0; // Asegurar que no tiene combustible

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => vehicle.StartEngine());
            Assert.Contains("No enoguht gas", exception.Message);
        }

        [Fact]
        public void StartEngine_WithGas_ShouldTurnOn()
        {
            // Arrange
            var vehicle = new Car("Red", "Ford", "Mustang");
            vehicle.Gas = 5.0;

            // Act
            vehicle.StartEngine();

            // Assert
            Assert.True(vehicle.IsEngineOn());
        }

        [Fact]
        public void StartEngine_AlreadyStarted_ShouldThrowException()
        {
            // Arrange
            var vehicle = new Car("Red", "Ford", "Mustang");
            vehicle.Gas = 5.0;
            vehicle.StartEngine();

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => vehicle.StartEngine());
            Assert.Contains("already on", exception.Message);
        }

        [Fact]
        public void AddGas_ExceedingFuelLimit_ShouldThrowException()
        {
            // Arrange
            var vehicle = new Car("Red", "Ford", "Mustang");
            vehicle.FuelLimit = 10.0;
            vehicle.Gas = 10.0; // Tanque lleno

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => vehicle.AddGas());
            Assert.Contains("Gas Full", exception.Message);
        }
    }

    public class InMemoryVehicleRepositoryTests
    {
        [Fact]
        public void AddAndFindVehicle_ShouldWorkCorrectly()
        {
            // Arrange
            var repository = new InMemoryVehicleRepository();
            var vehicle = new Car("Red", "Ford", "Mustang");

            // Act
            repository.AddVehicle(vehicle);
            var retrieved = repository.Find(vehicle.ID.ToString());

            // Assert
            Assert.NotNull(retrieved);
            Assert.Equal(vehicle.ID, retrieved.ID);
            Assert.Equal("Mustang", retrieved.Model);
        }

        [Fact]
        public void Find_NonExistentId_ShouldReturnNull()
        {
            // Arrange
            var repository = new InMemoryVehicleRepository();

            // Act
            var retrieved = repository.Find(Guid.NewGuid().ToString());

            // Assert
            Assert.Null(retrieved);
        }

        [Fact]
        public void GetVehicles_ShouldReturnAllAddedVehicles()
        {
            // Arrange
            var repository = new InMemoryVehicleRepository();
            var v1 = new Car("Red", "Ford", "Mustang");
            var v2 = new Car("Black", "Ford", "Explorer");

            // Act
            repository.AddVehicle(v1);
            repository.AddVehicle(v2);
            var list = repository.GetVehicles();

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Contains(v1, list);
            Assert.Contains(v2, list);
        }
    }

    public class VehicleBuilderTests
    {
        [Fact]
        public void Build_WithDefaults_ShouldProduceValidVehicleAndDefaultProperties()
        {
            // Arrange
            var builder = new CarBuilder();

            // Act
            var vehicle = builder.Build();

            // Assert
            Assert.NotNull(vehicle);
            Assert.Equal("Ford", vehicle.Brand);
            Assert.Equal("Mustang", vehicle.Model);
            Assert.Equal("Red", vehicle.Color);
            Assert.Equal(DateTime.Now.Year, vehicle.Year);
            
            // Verificar valores por defecto (20+ propiedades)
            Assert.False(vehicle.HasGPS);
            Assert.True(vehicle.HasAirConditioning);
            Assert.False(vehicle.HasSunroof);
            Assert.True(vehicle.HasBluetooth);
            Assert.True(vehicle.HasBackupCamera);
            Assert.True(vehicle.HasKeylessEntry);
            Assert.False(vehicle.HasRemoteStart);
        }

        [Fact]
        public void Build_WithCustomValues_ShouldOverrideDefaults()
        {
            // Arrange
            var builder = new CarBuilder();

            // Act
            var vehicle = builder
                .SetBrand("Tesla")
                .SetModel("Model S")
                .SetColor("Blue")
                .SetYear(2025)
                .SetGPS(true)
                .SetAirConditioning(false)
                .SetSunroof(true)
                .Build();

            // Assert
            Assert.Equal("Tesla", vehicle.Brand);
            Assert.Equal("Model S", vehicle.Model);
            Assert.Equal("Blue", vehicle.Color);
            Assert.Equal(2025, vehicle.Year);
            Assert.True(vehicle.HasGPS);
            Assert.False(vehicle.HasAirConditioning);
            Assert.True(vehicle.HasSunroof);
        }
    }

    public class VehicleFactoryTests
    {
        [Fact]
        public void FordMustangCreator_ShouldCreateMustang()
        {
            // Arrange
            var creator = new FordMustangCreator();

            // Act
            var vehicle = creator.Create();

            // Assert
            Assert.Equal("Mustang", creator.ModelKey);
            Assert.Equal("Ford", vehicle.Brand);
            Assert.Equal("Mustang", vehicle.Model);
            Assert.IsType<Car>(vehicle);
        }

        [Fact]
        public void FordExplorerCreator_ShouldCreateExplorer()
        {
            // Arrange
            var creator = new FordExplorerCreator();

            // Act
            var vehicle = creator.Create();

            // Assert
            Assert.Equal("Explorer", creator.ModelKey);
            Assert.Equal("Ford", vehicle.Brand);
            Assert.Equal("Explorer", vehicle.Model);
            Assert.Equal("Black", vehicle.Color);
            Assert.IsType<Car>(vehicle);
        }

        [Fact]
        public void FordEscapeCreator_ShouldCreateEscape()
        {
            // Arrange
            var creator = new FordEscapeCreator();

            // Act
            var vehicle = creator.Create();

            // Assert
            Assert.Equal("Escape", creator.ModelKey);
            Assert.Equal("Ford", vehicle.Brand);
            Assert.Equal("Escape", vehicle.Model);
            Assert.Equal("Red", vehicle.Color);
            Assert.IsType<Car>(vehicle);
        }
    }
}
