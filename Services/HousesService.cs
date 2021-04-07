using System;
using System.Collections.Generic;
using gregslist_sql.Models;
using gregslist_sql.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_sql.Services
{
    public class HousesService
    {

        private readonly HousesRepository _repo;

        public HousesService(HousesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<House> GetAllHouses()
        {
            return _repo.GetAllHouses();
        }

        internal House CreateHouse(House newHouse)
        {
            return _repo.CreateHouse(newHouse);
        }

        internal House GetHouseById(int id)
        {
            House house = _repo.GetHouseById(id);
            if(house == null){
                throw new SystemException("INVALID ID");
            } else {
                return house;
            }
        }

        internal ActionResult<House> EditHouse(int id, House editedHouse)
        {
            House currentHouse = GetHouseById(id);
            if(currentHouse == null){
                throw new SystemException("INVALID ID");
            } else {
                currentHouse.Bathrooms = editedHouse.Bathrooms > 0 ? editedHouse.Bathrooms : currentHouse.Bathrooms;
                currentHouse.Bedrooms = editedHouse.Bedrooms > 0 ? editedHouse.Bedrooms : currentHouse.Bedrooms;
                currentHouse.Location = editedHouse.Location != null ? editedHouse.Location : currentHouse.Location;
                currentHouse.Price = editedHouse.Price > 0 ? editedHouse.Price : currentHouse.Price;
                currentHouse.Size = editedHouse.Size != null ? editedHouse.Size : currentHouse.Size;
                return _repo.EditHouse(currentHouse);
            }
        }

        internal object DeleteHouse(int id)
        {
            House currentHouse = _repo.GetHouseById(id);
            if(currentHouse == null){
                throw new SystemException("INVALID ID");
            } else {
                _repo.DeleteHouse(id);
                return currentHouse;
            }
        }
    }
}