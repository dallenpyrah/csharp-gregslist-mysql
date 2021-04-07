using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_sql.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_sql.Repositories
{
    public class HousesRepository
    {
        public readonly IDbConnection _db;
        public HousesRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<House> GetAllHouses()
        {
            string sql = "SELECT * FROM houses;";
            return _db.Query<House>(sql);
        }

        internal House CreateHouse(House newHouse)
        {
            string sql = @"
            INSERT INTO houses
            (location, size, bedrooms, bathrooms, price)
            VALUES
            (@Location, @Size, @Bedrooms, @Bathrooms, @Price);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newHouse);
            newHouse.Id = id;
            return newHouse;
        }

        internal House GetHouseById(int id)
        {
            string sql = "SELECT * FROM houses WHERE id = @id;";
            return _db.QueryFirstOrDefault<House>(sql, new { id });
            
        }

        internal ActionResult<House> EditHouse(House currentHouse)
        {
            string sql = @"UPDATE houses
            SET
            location = @Location,
            size = @Size, 
            bedrooms = @Bedrooms,
            bathrooms = @Bathrooms,
            price = @Price
            WHERE id = @Id;
            SELECT * FROM houses WHERE id = @id;";
            return _db.QueryFirstOrDefault<House>(sql, currentHouse);
        }

        internal void DeleteHouse(int id)
        {
            string sql = @"DELETE FROM houses WHERE id = @id;";
            _db.ExecuteScalar<House>(sql, new { id });
            return;
        }
    }
}