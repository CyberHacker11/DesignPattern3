using System;

namespace DesignPattern3
{
    #region Builder

    class Car
    {
        public string Type { get; set; }
        public byte GPS { get; set; }
        public byte Seats { get; set; }
        public float Engine { get; set; }
        public byte TripComputer { get; set; }

        public override string ToString()
        {
            return $"Seats: {Seats}" +
                $"Engine: {Engine}" +
                $"Trip Computer: {TripComputer}" +
                $"GPS: {GPS}";
        }
    }

    interface IBuilder
    {
        public Car Car { get; set; }

        IBuilder Reset();

        IBuilder SetSeats(int size);
        IBuilder SetEngine(float engine);
        IBuilder SetTripComputer(int size);
        IBuilder SetGPS(int size);

        Car GetResult();
    }

    class CarAvtomat : IBuilder
    {
        public IBuilder Reset()
        {
            Car = new Car();
            return this;
        }

        public IBuilder SetSeats(int size)
        {
            Car.Seats = (byte)(size);
            return this;
        }

        public IBuilder SetEngine(float engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetTripComputer(int size)
        {
            Car.TripComputer = (byte)(size);
            return this;
        }

        public IBuilder SetGPS(int size)
        {
            Car.GPS = (byte)(size);
            return this;
        }

        public Car GetResult() => Car;

        public Car Car { get; set; }
    }

    class CarManual : IBuilder
    {
        public IBuilder Reset()
        {
            Car = new Car();
            return this;
        }

        public IBuilder SetSeats(int size)
        {
            Car.Seats = (byte)(size);
            return this;
        }

        public IBuilder SetEngine(float engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetTripComputer(int size)
        {
            Car.TripComputer = (byte)(size);
            return this;
        }

        public IBuilder SetGPS(int size)
        {
            Car.GPS = (byte)(size);
            return this;
        }

        public Car GetResult() => Car;

        public Car Car { get; set; }
    }


    class Director
    {
        public Director(IBuilder builder)
        {
            _builder = builder;
        }

        public Car MakeSUV(string type)
        {
            _builder.Reset();

            if (type == "Sport Car")
            {
                _builder.Car.Type = type;
                return _builder.SetSeats(4)
                    .SetTripComputer(3)
                    .SetEngine(4.5f)
                    .SetGPS(1)
                    .GetResult();
            }
            else if (type == "Car")
            {
                _builder.Car.Type = type;
                return _builder.SetSeats(4)
                    .SetEngine(1.8f)
                    .GetResult();
            }

            throw new Exception("Wrong Type");
        }

        void SportsCar(IBuilder builder)
        {
            _builder = builder;
        }

        IBuilder _builder;
    }

    #endregion Builder

    #region Singleton

    class Brand
    {
        Brand() { }

        private Brand _instance;
        public Brand Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new Brand {
                        Name = "Nike",
                        DateRegistration = new DateTime(11,11,2011)
                    };
                }
                return _instance; 
            }
        }


        public string Name { get; set; }
        public DateTime DateRegistration { get; set; }
    }

    #endregion Singleton

    #region Protoype

    interface IPrototype
    {
        IPrototype Clone();
    }

    class Robot : IPrototype
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string SerianNumber { get; set; }

        public Robot() { }

        public Robot(Robot prototype) {
            Name = prototype.Name;
            Model = prototype.Model;
            SerianNumber = prototype.SerianNumber;
        }

        public IPrototype Clone() => new Robot(this);
    }

    #endregion Protoype

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
