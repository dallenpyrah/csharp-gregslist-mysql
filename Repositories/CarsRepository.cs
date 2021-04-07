using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_sql.Models;

namespace gregslist_sql.Repositories
{
    public class CarsRepository
    {

        public readonly IDbConnection _db;

        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Car> getAllCars()
        {
            string sql = "SELECT * FROM thecars;";
            return _db.Query<Car>(sql);
        }

        internal object CreateCar(Car newCar)
        {
            string sql = @"
            INSERT INTO thecars
            (make, model, year, price)
            VALUES
            (@Make, @Model, @Year, @Price);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCar);
            newCar.Id = id;
            return newCar;
        }

        internal Car GetCarById(int id)
        {
            string sql = "SELECT * FROM thecars WHERE id = @id;";
            return _db.QueryFirstOrDefault<Car>(sql, new { id });
        }

        internal object Edit(Car orginal)
        {
            string sql = @"UPDATE thecars
            SET
                make = @Make,
                model = @Model,
                year = @Year,
                price = @Price
                WHERE id = @Id;
                SELECT * FROM thecars WHERE id = @id;";
            return _db.QueryFirstOrDefault<Car>(sql, orginal);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM thecars where id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}