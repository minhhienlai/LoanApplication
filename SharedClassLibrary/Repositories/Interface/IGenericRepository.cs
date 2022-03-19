using SharedClassLibrary.Models;

namespace SharedClassLibrary.Repositories.Interface
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        public IEnumerable<T> GetAll();
        public PaginatedList<T> GetPaging(int? pageNumber, int? pageSize);
        public T GetById(object id);
        public IEnumerable<T> GetByParentId(int id);
        public void Insert(T obj);
        public bool UpdateAllProperties(T obj);
        public bool UpdateAllButCreated(int id, T obj);
        public bool UpdateSelectedProperties(int id, T obj) ;
        public void Delete(object id);
        public void Save();
    }
}
