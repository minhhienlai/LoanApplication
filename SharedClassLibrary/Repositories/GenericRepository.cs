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
        public GenericRepository(DataContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }
        public bool Update(T obj)
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

        public void Delete(object id)
        {
            T objToDelete = table.Find(id);
            if (objToDelete != null) {
                table.Remove(objToDelete);
                Save();
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public abstract IEnumerable<T> GetByParentId(int id);
        
    }
}
