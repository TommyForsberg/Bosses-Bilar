using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using AutoMapper;

namespace BossesBilar.Models.Entities
{
    public partial class CarsContext : DbContext
    {
       public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {

        }

        public CarsIndexVM[] ListCars()
        {
            return Car.Select(o => new CarsIndexVM
            {
                Brand = o.Brand,
                ShowAsFast = o.TopSpeed > 250,
                OwnerName = o.Owner.Name
            })
                .ToArray();
        }
        public void AddCar(CarsCreateVM view)
        {
            //var newCar = new Car
            //{
            //    Brand = view.Brand,
            //    Doors = view.Doors,
            //    TopSpeed = view.TopSpeed,
            //};

            var newCar = Mapper.Map<Car>(view);
            //newCar.Id = cars.Max(o => o.Id) + 1;
            Car.Add(newCar);
            SaveChanges();
        }
    }
}