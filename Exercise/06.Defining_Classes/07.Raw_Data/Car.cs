using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _07.Raw_Data
{
    class Car
    {
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
        public string Model { get; set; }
        public Car(string[] rawData)
        {
            string model = rawData[0];
            Model = model;
            int engineSpeed = int.Parse(rawData[1]);
            int enginePower = int.Parse(rawData[2]);
            AddEngineData(engineSpeed, enginePower);
            int cargoWeight = int.Parse(rawData[3]);
            string type = rawData[4];
            AddCargoData(cargoWeight, type);
            AddTiresData(rawData);
        }

        private void AddEngineData(int engineSpeed, int enginePower)
        {
            Engine engine = new Engine(engineSpeed, enginePower);
            this.Engine = engine;
        }

        private void AddCargoData(int cargoWeight, string type)
        {
            Cargo cargo = new Cargo(cargoWeight, type);
            this.Cargo = cargo;
        }

        private void AddTiresData(string[] rawData)
        {
            this.Tires = new Tire[3];
            int index = 5;

            for (int i = 0; i < 3; i++)
            {
                double pressure = double.Parse(rawData[index]);
                int age = int.Parse(rawData[index + 1]);
                index += 2;
                Tire tire = new Tire(age, pressure);
                this.Tires[i] = tire;
            }
        }
    }
}
