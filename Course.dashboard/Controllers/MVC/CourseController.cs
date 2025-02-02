﻿using Course.Domain.Domains;
using Course.Repository.ViewModeles;
using Course.Service.IServices;
using Course.Service.Services;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Controllers.MVC {
    public class CourseController : Controller {
        private readonly ITitleService _titleService;
        private readonly ICourseService _courseService;

        private readonly IToastNotification _toast;

        public CourseController(ITitleService titleService, IToastNotification toast, ICourseService courseService)
        {
            _titleService = titleService;
            _toast = toast;
            _courseService = courseService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            var Course = new CourseViewModel()
            {
                course = new CourseFormViewModel(),
                Title = new TitleFormViewModel(),
                Titles = _titleService.GetAll().Result
            };
            return View(Course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseViewModel model)
        {
            var result = _courseService.AddCourse(model).Result;
            if (result)
            {
                _toast.AddSuccessToastMessage("Done");
                return RedirectToAction(nameof(Coures), new { userName = model.UserName, Search = "", orderby = "", currentPage = 1 });
            }
            _toast.AddErrorToastMessage("Enter Data or Incorrect Data..");
            return RedirectToAction(nameof(Create));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Title(TitleFormViewModel title)
        {
            if (ModelState.IsValid)
            {
                if (_titleService.Create(title).Result)
                {
                    _toast.AddSuccessToastMessage("Saving Data");
                    return RedirectToAction(nameof(Create));
                }
            }
            ModelState.AddModelError(string.Empty, "Incoorect Data");
            _toast.AddErrorToastMessage("Enter or Incorrect Data..");
            return RedirectToAction(nameof(Create));
        }

        public async Task<IActionResult> Coures(string userName, string Search = "", string orderby = "", int currentPage = 1)
        {
            var result = await _titleService.GetAllTitles(currentPage, userName, Search, orderby);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTitle(int Id)
        {
            var TitleVM = await _titleService.GetTitleById(Id);
            return View(TitleVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTitle(UpdateTitleViewModel model)
        {
            if (await _titleService.UpdateTitle(model))
            {
                _toast.AddSuccessToastMessage("Done");
                return RedirectToAction(nameof(Coures), new { userName = Request.Form["userName"], Search = "", orderby = "", currentPage = 1 });
            }
            ModelState.AddModelError(string.Empty, "Data is Invalid");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTitle(int Id, string username)
        {
            if (await _titleService.DeleteTitle(Id))
            {
                _toast.AddSuccessToastMessage("Done");
                return RedirectToAction(nameof(Coures), new { userName = username, Search = "", orderby = "", currentPage = 1 });
            }
            ModelState.AddModelError(string.Empty, "Data is Invalid");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetVideosForTitle(int Id)
        {
            var result = await _courseService.GetAllVideosById(Id);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteVideo(int Id, int? TitleId)
        {
            if (await _courseService.DeleteVideo(Id))
            {
                _toast.AddSuccessToastMessage("Done");
                return RedirectToAction(nameof(GetVideosForTitle), new { Id = TitleId });
            }
            _toast.AddErrorToastMessage("Try in another Time");
            return RedirectToAction(nameof(GetVideosForTitle), new { Id = TitleId });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateVideoById(int id)
        {
            var result = await _courseService.GetVideoById(id);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVideoById(VideoByIdViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _toast.AddErrorToastMessage("Try in another Time");
                return RedirectToAction(nameof(GetVideosForTitle), new { Id = model.TitleId });
            }
            var result = await _courseService.UpdateVideo(model);
            if (!result)
            {
                _toast.AddErrorToastMessage("Try in another Time");
                return RedirectToAction(nameof(GetVideosForTitle), new { Id = model.TitleId });
            }
            _toast.AddSuccessToastMessage("Done");
            return RedirectToAction(nameof(GetVideosForTitle), new { Id = model.TitleId });
        }
        [HttpPost]
        public async Task<JsonResult> GetVideos(int Id,int CurrentPage, int PageSize)
        {
            return Json(await _courseService.GetAllVideosJsonById(Id,CurrentPage,PageSize));
        }

    }
}
