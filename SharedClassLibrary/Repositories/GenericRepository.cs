using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using SharedClassLibrary.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
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
        public virtual IEnumerable<T> GetByParentId(int id)
        {
            return null;
        }
    }
}
