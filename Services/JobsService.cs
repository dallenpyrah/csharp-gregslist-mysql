using System;
using System.Collections.Generic;
using gregslist_sql.Models;
using gregslist_sql.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_sql.Services
{
    public class JobsService
    {
        private readonly JobsRepository _repo;

        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Job> GetAllJobs()
        {
            return _repo.GetAllJobs();
        }

        internal Job GetJobById(int id)
        {
            return _repo.GetJobById(id);
        }

        internal Job CreateJob(Job newJob)
        {
            return _repo.CreateJob(newJob);
        }

        internal Job EditJob(Job editedJob)
        {
            Job currentJob = GetJobById(editedJob.Id);
            if (currentJob == null)
            {
                throw new SystemException("INVALID ID");
            } else {
                currentJob.Company = editedJob.Company != null ? editedJob.Company : currentJob.Company;
                currentJob.Title = editedJob.Title != null ? editedJob.Title : currentJob.Title;
                currentJob.Description = editedJob.Description != null ? editedJob.Description : currentJob.Description;
                currentJob.Location = editedJob.Location != null ? editedJob.Location : currentJob.Location;
                currentJob.Salary = editedJob.Salary > 0 ? editedJob.Salary : currentJob.Salary;
                return _repo.EditJob(currentJob);
            }
        }

        internal Job DeleteJob(int id)
        {
            Job currentJob = GetJobById(id);
            _repo.DeleteJob(id);
            return currentJob;
        }
    }
}