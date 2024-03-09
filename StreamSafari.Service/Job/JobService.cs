using StreamSafari.Model;
using StreamSafari.Repository;
using StreamSafari.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSafari.Service
{
    public class JobService
    {

        JobRepository jobRepository = new JobRepository();

        public Job JobViewModelToEntity(JobViewModel p_JobViewModel)
        {
            Job job = new Job();
            job.JobId = (p_JobViewModel.JobId == 0) ? 0 : p_JobViewModel.JobId;
            job.Name = p_JobViewModel.Name;
            job.CreatedWhen = p_JobViewModel.CreatedWhen;
            job.UpdatedWhen = p_JobViewModel.UpdatedWhen;
            job.Status = p_JobViewModel.Status;
            return job;
        }

        public JobViewModel EnitityToJobViewModel(Job p_JobCreated)
        {
            JobViewModel jobViewModel = new JobViewModel();
            jobViewModel.JobId = p_JobCreated.JobId;
            jobViewModel.Name = p_JobCreated.Name;
            jobViewModel.CreatedWhen = p_JobCreated.CreatedWhen;
            jobViewModel.UpdatedWhen = p_JobCreated.UpdatedWhen;
            jobViewModel.Status = p_JobCreated.Status;
            return jobViewModel;
        }
        public JobViewModel GetJob(JobViewModel p_JobViewModel)
        {
            Job job = JobViewModelToEntity(p_JobViewModel);
            Job jobExists = jobRepository.GetJob(job);
            JobViewModel jobViewModel = new JobViewModel();
            if (jobExists != null)
            {
                jobViewModel = EnitityToJobViewModel(jobExists);
            }
            else
            {
                jobViewModel = EnitityToJobViewModel(job);
            }

            return jobViewModel;
        }

        public JobViewModel CreateJob(JobViewModel p_MovieViewModel)
        {
            Job job = JobViewModelToEntity(p_MovieViewModel);
            Job jobCreated = jobRepository.CreateJob(job);
            JobViewModel jobViewModel = EnitityToJobViewModel(jobCreated);
            return jobViewModel;
        }

        public JobViewModel EditJob(JobViewModel p_JobViewModel)
        {
            Job job = JobViewModelToEntity(p_JobViewModel);
            Job jobEdited = jobRepository.EditJob(job);
            JobViewModel jobViewModel = EnitityToJobViewModel(jobEdited);
            return jobViewModel;
        }

        public JobViewModel FindJob(int? p_JobId)
        {

            Job findJob = jobRepository.FindJob(p_JobId);
            JobViewModel jobViewModel = EnitityToJobViewModel(findJob);
            return jobViewModel;
        }

        public List<JobViewModel> ListJob()
        {
            List<Job> jobs = jobRepository.ListJob();
            List<JobViewModel> jobViewModels = new List<JobViewModel>();

            foreach (var job in jobs)
            {
                JobViewModel jobViewModel = new JobViewModel
                {

                    JobId = job.JobId,
                    Name = job.Name,
                    CreatedWhen = DateTime.Now,
                    UpdatedWhen = DateTime.Now,
                    Status = job.Status,

                };
                jobViewModels.Add(jobViewModel);
            }

            return jobViewModels;
        }

        public JobViewModel DeleteJob(JobViewModel p_JobViewModel)
        {
            JobViewModel jobViewModel = new JobViewModel();
            Job job = JobViewModelToEntity(p_JobViewModel);
            Job findJob = jobRepository.FindJob(job.JobId);
            if (findJob != null)
            {
                Job movieDelete = jobRepository.DeleteJob(findJob);
                jobViewModel = EnitityToJobViewModel(movieDelete);
            }

            return jobViewModel;
        }

    }
}
