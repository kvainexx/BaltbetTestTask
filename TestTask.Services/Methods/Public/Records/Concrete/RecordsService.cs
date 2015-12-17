using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Entities;
using TestTask.Data.Repositories;
using System.Collections.ObjectModel;





namespace TestTask.Services.Methods.Public.Records.Concrete
{
    public partial class RecordsService : Abstract.IRecordsService
    {
        #region Properties
        private readonly IGenericRepository<Record> _recordsRepository;
        #endregion

        #region Constructors
        public RecordsService(IGenericRepository<Record> recordsRepository)
        {
            _recordsRepository = recordsRepository;
        }
        #endregion


        public async Task<Record> GetAsync(int id)
        {
            var ans = await Task.Factory.StartNew(() => Get(id));
            return ans;
        }
        public Record Get(int id)
        {
            var item = _recordsRepository.GetByID(id);
            return item;
        }

        public async Task<IEnumerable<Record>> GetAllAsync()
        {
            var ans = await Task.Factory.StartNew(() => GetAll());
            return ans;
        }
        public IEnumerable<Record> GetAll()
        {
            return _recordsRepository.Table().ToList();
        }

        public async Task<int> GetFavoriteCountAsync()
        {
            var ans = await Task.Factory.StartNew(() => GetFavoriteCount());
            return ans;
        }
        public int GetFavoriteCount()
        {
            return _recordsRepository.Table().Count(x => x.IsFavorite);
        }

        public async Task<Models.Public.Records.Response.List> ListAsync(Models.Public.Records.Request.List model)
        {
            var ans = await Task.Factory.StartNew(() => List(model));
            return ans;
        }
        public Models.Public.Records.Response.List List(Models.Public.Records.Request.List model)
        {
            var query = _recordsRepository.Table();
            query = query.OrderBy(x => x.Id);

            #region FAVORITES
            if (model.IsFavorite)
                query = query.Where(x => x.IsFavorite);
            #endregion

            #region PAGING

            if (model.Paging == null)
            {
                model.Paging = new Models.Paging()
                {
                    Page = 1,
                    Rows = 10,
                    TotalItems = 0
                };
            }
            else if (model.Paging.Rows == 0 || model.Paging.Page == 0)
            {
                if (model.Paging.Rows == 0) model.Paging.Rows = 10;
                if (model.Paging.Page == 0) model.Paging.Page = 1;
            }

            model.Paging.TotalItems = query.Count();

            query = query
                .Skip((model.Paging.Page - 1) * model.Paging.Rows)
                .Take(model.Paging.Rows);

            #endregion

            return new Models.Public.Records.Response.List()
            {
                Records = query.ToList(),
                Paging = model.Paging
            };

        }


        public async Task<bool?> SetFavoriteAsync(int id)
        {
            var ans = await Task.Factory.StartNew(() => SetFavorite(id));
            return ans;
        }
        public bool? SetFavorite(int id)
        {
            var item = Get(id);
            if (item == null)
                return null;

            item.IsFavorite = !item.IsFavorite;
            _recordsRepository.Update(item);
            _recordsRepository.Save();

            return item.IsFavorite;
        }
    }
}
