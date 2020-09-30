using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;
using System.Linq;
using System.Threading;

namespace ProgramRunner
{
    [Skip]
    public class OOD_ParkingLot : Runner
    {
        #region VehicleType SpotType
        public enum VehicleType
        {
            Bike = 100,
            Car,
            Truck,
            Bus
        }
        public enum SpotType
        {
            Bike = 1,
            Car = Bike * 2,
            Truck = Bike * 3,
            Bus = Bike * 5
        } 
        #endregion

        public abstract class Vehicle
        {
            public Vehicle(string no, VehicleType vehicleType, SpotType requiredSpotType)
            {
                this.No = no;
                this.Type = vehicleType;
                this.RequiredSpotType = requiredSpotType;
            }
            public string No { get; }
            public VehicleType Type { get; }
            public SpotType RequiredSpotType { get; set; }
        }

        #region Bike Car Truck Bus
        public class Bike : Vehicle
        {
            public Bike(string vehicleNo)
                : base(vehicleNo, VehicleType.Bike, SpotType.Bike)
            {
            }
        }

        public class Car : Vehicle
        {
            public Car(string vehicleNo)
                : base(vehicleNo, VehicleType.Car, SpotType.Car)
            {
            }
        }

        public class Truck : Vehicle
        {
            public Truck(string vehicleNo)
                : base(vehicleNo, VehicleType.Truck, SpotType.Truck)
            {
            }
        }

        public class Bus : Vehicle
        {
            public Bus(string vehicleNo)
                : base(vehicleNo, VehicleType.Bus, SpotType.Bus)
            {
            }
        } 
        #endregion

        public class ParkingSpot
        {
            public ParkingSpot(SpotType spotType, int floor, int sequenceNo)
            {
                this.SpotType = spotType;
                this.Floor = floor;
                this.SpotNo = Guid.NewGuid();
                this.SequenceNo = sequenceNo;
            }
            public SpotType SpotType { get; }
            public int Floor { get; }
            public Guid SpotNo { get; }
            public int SequenceNo { get; set; } // This will determine if 5 bikes can acomodate one car or not
        }


        public class ParkingLot
        {
            #region Singleton
            private static Lazy<ParkingLot> _instance = new Lazy<ParkingLot>(() => new ParkingLot());
            private ParkingLot() 
            {
                Initialize();
            }
            public static ParkingLot Instance
            {
                get
                {
                    return _instance.Value;
                }
            } 
            #endregion

            #region Atomicity
            private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
            private T AtomicOperation<T>(Func<T> action)
            {
                semaphoreSlim.Wait();
                try
                {
                    return action();
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            }

            private void AtomicOperation(Action action)
            {
                semaphoreSlim.Wait();
                try
                {
                    action();
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            }
            #endregion

            // Row => floor, Column
            // <Floor, ParkingSpots in sequence>
            private Dictionary<int, ParkingSpot[]> AllParkingSpots { get; } = new Dictionary<int, ParkingSpot[]>();

            // <Spot Number , Vehicle>
            private Dictionary<Guid, Vehicle> AllParkedVehicles { get; } = new Dictionary<Guid, Vehicle>();

            private void Initialize()
            {
                // Prepare all the parking spots in sequence in all the floors
                throw new NotImplementedException();
            }

            private ParkingSpot CheckSpot(SpotType requiredSpotType)
            {
                throw new NotImplementedException();
            }

            public bool IsParkingAvailable(SpotType requiredSpotType, out int floor)
            {
                floor =  AtomicOperation<int>(() =>
                {
                    throw new NotImplementedException();
                });

                return floor != int.MinValue;

            }

            public ParkingSpot Park(Vehicle vehicle)
            {
                return AtomicOperation<ParkingSpot>(() =>
                {
                    throw new NotImplementedException();
                });
            }

            // Called by sensor when vehicle leaves parking spot
            public void UnPark(ParkingSpot spot)
            {
                AtomicOperation(() =>
                {
                    throw new NotImplementedException();
                });
            }

        }


        public override void Run(string[] args)
        {
          var x =   Convert.ToBoolean(Convert.ToInt32(0xB)) &&
            Convert.ToBoolean(Convert.ToInt32(0x22)) &&
            Convert.ToBoolean(Convert.ToInt32('\xeb'));

           // static int[] k = new int90;

        }
    }
}
