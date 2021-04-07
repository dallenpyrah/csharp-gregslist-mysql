using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_sql.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_sql.Repositories
{
    public class JobsRepository
    {
        public readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Job> GetAllJobs()
        {
            string sql = "SELECT * FROM jobs;";
            return _db.Query<Job>(sql);
        }

        internal Job GetJobById(int id)
        {
            string sql = "SELECT * FROM jobs WHERE id = @id;";
            return _db.QueryFirstOrDefault<Job>(sql, new { id });
        }

        internal Job CreateJob(Job newJob)
        {
            string sql = @"
            INSERT INTO jobs
            (company, title, salary, location, description)
            VALUES
            (@Company, @Title, @Salary, @Location, @Description);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newJob);
            newJob.Id = id;
            return newJob;
        }

        internal Job EditJob(Job currentJob)
        {
            string sql = @"UPDATE jobs
            SET
            company = @Company,
            title = @Title,
            salary = @Salary,
            location = @Location,
            description = @Description
            WHERE id = @Id;
            SELECT * FROM jobs WHERE id = @id;";
            return _db.QueryFirstOrDefault<Job>(sql, currentJob);
            
        }

        internal void DeleteJob(int id)
        {
            string sql = "DELETE FROM jobs WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}