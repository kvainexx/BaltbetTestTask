using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestTask.Services.Methods.Public.Records.Abstract;
using TestTask.UW.Models;
using TestTask.UW.Models.Records;

namespace TestTask.UW.Controllers
{
    public class TableController : Controller
    {
        private readonly IRecordsService _recordsService;

        public TableController(IRecordsService recordsService)
        {
            _recordsService = recordsService;
        }

        public async Task<ActionResult> Index(Paging paging)
        {
            var recordsList = await _recordsService.ListAsync(new Services.Models.Public.Records.Request.List()
            {
                Paging = Mapper.Map<Services.Models.Paging>(paging)
            });

            var model = new RecordsModel()
            {
                Records = recordsList.Records,
                Paging = Mapper.Map<Paging>(recordsList.Paging)
            };

            ViewBag.TotalFavorites = await _recordsService.GetFavoriteCountAsync();

            return View(model);
        }

        public async Task<ActionResult> UnFave(int id, Paging paging)
        {
            var ans = await _recordsService.SetFavoriteAsync(id);

            return RedirectToAction("Index", paging);
        }

    }

}