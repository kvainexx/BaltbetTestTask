using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Data.Entities;

namespace TestTask.Services.Methods.Public.Directories.Abstract
{
    public partial interface IDirectoriesService
    {
        Task<Directory> GetAsync(int id);
        Directory Get(int id);

        Task<IEnumerable<Directory>> GetAllAsync();
        IEnumerable<Directory> GetAll();
    }

}
