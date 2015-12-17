using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Entities;
using TestTask.Data.Repositories;

namespace TestTask.Services.Methods.Public.Directories.Concrete
{
    public partial class DirectoriesService : Abstract.IDirectoriesService
    {
        #region Properties
        private readonly IGenericRepository<Directory> _directoriesRepository;
        #endregion

        #region Constructors
        public DirectoriesService(IGenericRepository<Directory> directoriesRepository)
        {
            _directoriesRepository = directoriesRepository;
        }
        #endregion


        public async Task<Directory> GetAsync(int id)
        {
            var ans = await Task.Factory.StartNew(() => Get(id));
            return ans;
        }
        public Directory Get(int id)
        {
            var item = _directoriesRepository.GetByID(id);
            return item;
        }

        public async Task<IEnumerable<Directory>> GetAllAsync()
        {
            var ans = await Task.Factory.StartNew(() => GetAll());
            return ans;
        }
        public IEnumerable<Directory> GetAll()
        {
            return _directoriesRepository.Table().ToList();
        }


    }
}
