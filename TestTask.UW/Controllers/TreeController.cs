using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestTask.Services.Methods.Public.Directories.Abstract;
using TestTask.Services.Methods.Public.Records.Abstract;
using TestTask.UW.Models.Directories;

namespace TestTask.UW.Controllers
{
    public class TreeController : Controller
    {
        private readonly IRecordsService _recordsService;
        private readonly IDirectoriesService _directoriesService;

        public TreeController(IRecordsService recordsService, IDirectoriesService directoriesService)
        {
            _recordsService = recordsService;
            _directoriesService = directoriesService;
        }

        public async Task<ActionResult> Index()
        {
            var model = new DirectoriesModel()
            {
                Directories = (await _directoriesService.GetAllAsync())
            };
            ViewBag.TotalFavorites = (int?)model.Directories.SelectMany(x => x.Records).Count(x => x.IsFavorite);
            return View(model);
        }

        public async Task<ActionResult> UnFave(int id)
        {
            var ans = await _recordsService.SetFavoriteAsync(id);

            return RedirectToAction("Index");
        }

    }


}