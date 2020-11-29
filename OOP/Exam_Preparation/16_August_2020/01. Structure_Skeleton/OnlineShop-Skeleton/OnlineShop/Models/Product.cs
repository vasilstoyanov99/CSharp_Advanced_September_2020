using OnlineShop.Common.Constants;
using OnlineShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models
{
    public abstract class Product : IProduct
    {
        private int _id;
        private string _manufacturer;
        private string _model;
        private decimal _price;
        private double _overallPerformance;

        protected Product
            (int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }
        public int Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }

                _id = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }

                _manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }

                _model = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return _price;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                _price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get
            {
                return _overallPerformance;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }

                _overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id})";
        }
    }
}
