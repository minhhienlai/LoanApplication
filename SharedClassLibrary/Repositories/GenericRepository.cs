using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using SharedClassLibrary.Repositories.Interface;

namespace SharedClassLibrary.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected DataContext _context;
        protected DbSet<T> table;

        #region GET
        public GenericRepository(DataContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public PaginatedList<T> GetPaging(int? pageNumber, int? pageSize)
        {
            List<T> listAll = table.ToList();
            return PaginatedList<T>.SliceAndCreate(listAll, pageNumber ?? 1, pageSize ?? Common.DEFAULT_PAGE_SIZE);
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public abstract IEnumerable<T> GetByParentId(int id);
        #endregion

        #region INSERT
        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }

        #endregion
        #region UPDATE
        public bool UpdateAllProperties(T obj)
        {
            try {
                table.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
                Save();
                return true;
            }
            catch (Exception ex){
                return false;
        } }
        
        public bool UpdateAllButCreated(int id, T obj)
        {
            try {
                T objToUpdate = table.Find(id);
                if (objToUpdate != null) {
                    obj.CreatedAt = objToUpdate.CreatedAt;
                    obj.CreatedBy = objToUpdate.CreatedBy;
                    _context.Entry(objToUpdate).State = EntityState.Detached;
                    table.Attach(obj);
                    _context.Entry(obj).State = EntityState.Modified;
                    Save();
                }
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        public bool UpdateSelectedProperties(int id, T obj, List<string> propertyList)
        {
            try {
                table.Attach(obj);
                _context = SetPropertiesToUpdate(obj, propertyList);
                Save();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
        private DataContext SetPropertiesToUpdate(T obj, List<string> propertyList)
        {
            foreach (var property in propertyList) {
                _context.Entry(obj).Property(property).IsModified = true;
            }
            return _context;
        }
        #endregion
        #region DELETE
        public void Delete(object id)
        {
            T objToDelete = table.Find(id);
            if (objToDelete != null) {
                table.Remove(objToDelete);
                Save();
            }
        }
        #endregion
        #region SAVE
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
