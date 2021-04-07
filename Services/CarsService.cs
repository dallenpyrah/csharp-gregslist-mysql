using System;
using System.Collections.Generic;
using gregslist_sql.Models;
using gregslist_sql.Repositories;

namespace gregslist_sql.Services
{
    public class CarsService
    {

        private readonly CarsRepository _repo;

        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Car> GetAllCars()
        {
            return _repo.getAllCars();
        }

        internal object CreateCar(Car newCar)
        {
            return _repo.CreateCar(newCar);
        }

        internal Car GetCarById(int id)
        {
            Car car = _repo.GetCarById(id);
            if (car == null)
            {
                throw new SystemException("INVALID ID");
            } else {
                return car;
            }
        }

        internal object EditCar(Car editedCar)
        {
            Car orginal = GetCarById(editedCar.Id);
            if(orginal == null){
                throw new SystemException("INVALID ID");
            } else {
                orginal.Make = editedCar.Make != null ? editedCar.Make : orginal.Make; 
                orginal.Model = editedCar.Model != null ? editedCar.Model : orginal.Model;
                orginal.Price = editedCar.Price > 0 ? editedCar.Price : orginal.Price;
                orginal.Year = editedCar.Year > 0 ? editedCar.Year : orginal.Year;
                return _repo.Edit(orginal);
            }
        }

        internal Car DeleteCar(int id)
        {
            Car original = GetCarById(id);
            _repo.Delete(id);
            return original;
        }
    }
}