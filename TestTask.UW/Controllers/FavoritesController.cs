using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestTask.Services.Methods.Public.Records.Abstract;
using TestTask.UW.Models;
using TestTask.UW.Models.Records;

namespace TestTask.UW.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IRecordsService _recordsService;

        public FavoritesController(IRecordsService recordsService)
        {
            _recordsService = recordsService;
        }


        public async Task<ActionResult> Index(Paging paging)
        {
            var recordsList = await _recordsService.ListAsync(new Services.Models.Public.Records.Request.List()
            {
                IsFavorite = true,
                Paging = Mapper.Map<Services.Models.Paging>(paging)
            });

            var model = new RecordsModel()
            {
                Records = recordsList.Records,
                Paging = Mapper.Map<Paging>(recordsList.Paging)
            };

            ViewBag.TotalFavorites = (int?)model.Paging.Total.Items;
            return View(model);
        }

        public async Task<ActionResult> UnFave(int id, Paging paging)
        {
            var ans = await _recordsService.SetFavoriteAsync(id);
            if (ans == null)
                return RedirectToAction("Index", paging);

            var favoritesCount = await _recordsService.GetFavoriteCountAsync();

            if (favoritesCount <= 0)
                return RedirectToAction("Index", "Table");

            return RedirectToAction("Index", paging);
        }


    }
}