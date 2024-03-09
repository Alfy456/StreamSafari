using StreamSafari.Service;
using StreamSafari.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StreamSafari.Web.Controllers
{
    public class JobController : Controller
    {
        JobService jobService = new JobService();
        MovieService movieService = new MovieService();
        MovieController objMovieController = new MovieController();


       
        public ActionResult Index()
        {
            List<JobViewModel> jobs = jobService.ListJob();
            return View(jobs);
        }

        public ActionResult CreateJob()
        {
            return View();
        }
        public ActionResult Run()
        {
            objMovieController.BulkUpload();
            List<MovieViewModel> movies = movieService.ListMovies();

            return View(movies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJob(JobViewModel p_JobViewModel)
        {
            JobViewModel jobViewModel = jobService.GetJob(p_JobViewModel);
            if (jobViewModel.JobId == 0)
            {
                jobViewModel = jobService.CreateJob(p_JobViewModel);
                if (jobViewModel.JobId != 0)
                {
                    List<JobViewModel> jobViewModels = jobService.ListJob();
                    return View("Index", jobViewModels);
                }
                else
                {
                    //Unable to create movie <Please implement later>
                }
            }
            else
            {
                if (p_JobViewModel.JobId == p_JobViewModel.JobId)
                {

                    ViewBag.IsJobNameAvailable = true;
                }
            }


            return View();
        }

        public ActionResult EditJob(int id)
        {

            JobViewModel jobViewModel = new JobViewModel();

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                jobViewModel = jobService.FindJob(id);

            }
            return View(jobViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobViewModel p_JobViewModel)
        {
            if (ModelState.IsValid)
            {
                JobViewModel jobViewModel = jobService.EditJob(p_JobViewModel);
                List<JobViewModel> jobViewModels = jobService.ListJob();
                return View("JobCreated", jobViewModels);
            }


            return View("EditJob");
        }


        public ActionResult Delete(int? id)
        {
            JobViewModel jobViewModel = new JobViewModel();

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                jobViewModel = jobService.FindJob(id);

            }
            return View(jobViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(JobViewModel p_JobViewModel)
        {

            jobService.DeleteJob(p_JobViewModel);

            List<JobViewModel> jobViewModels = jobService.ListJob();
            return View("JobCreated", jobViewModels);


        }


        public ActionResult Details(int? id)
        {
            JobViewModel jobViewModel = new JobViewModel();

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                jobViewModel = jobService.FindJob(id);

            }
            return View(jobViewModel);
        }
    }
}