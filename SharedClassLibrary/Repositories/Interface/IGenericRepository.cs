using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(object id);
        public void Insert(T obj);
        public bool Update(T obj);
        public void Delete(object id);
        public void Save();
        public IEnumerable<T> GetByParentId(int id);
    }
}
