using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Data.Entities;

namespace TestTask.Services.Methods.Public.Records.Abstract
{
    public partial interface IRecordsService
    {
        Task<Record> GetAsync(int id);
        Record Get(int id);

        Task<IEnumerable<Record>> GetAllAsync();
        IEnumerable<Record> GetAll();

        Task<bool?> SetFavoriteAsync(int id);
        bool? SetFavorite(int id);

        Task<Models.Public.Records.Response.List> ListAsync(Models.Public.Records.Request.List model);
        Models.Public.Records.Response.List List(Models.Public.Records.Request.List model);

        Task<int> GetFavoriteCountAsync();
        int GetFavoriteCount();

    }
}
