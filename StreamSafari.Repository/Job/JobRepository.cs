using StreamSafari.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSafari.Repository
{
    public class JobRepository
    {
        StreamSafariEntities db = new StreamSafariEntities();

        public Job CreateJob(Job p_Job)
        {
            Job job = db.Jobs.Add(p_Job);
            db.SaveChanges();
            return job;
        }

        public Job GetJob(Job p_Job)
        {
            Job job = db.Jobs.Where(u => u.JobId == p_Job.JobId).FirstOrDefault();
            return job;
        }


        public Job EditJob(Job p_Job)
        {

            db.Entry(p_Job).State = EntityState.Modified;
            db.SaveChanges();
            return p_Job;


        }

        public Job FindJob(int? p_Job)
        {
            Job job = db.Jobs.Find(p_Job);
            return job;
        }

        public List<Job> ListJob()
        {
            List<Job> job = db.Jobs.OrderByDescending(u => u.JobId).ToList();
            return job;
        }

        public Job DeleteJob(Job p_Job)
        {
            db.Jobs.Remove(p_Job);
            db.SaveChanges();
            return p_Job;
        }
    }
}
