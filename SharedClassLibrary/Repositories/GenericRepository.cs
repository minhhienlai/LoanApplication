using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;
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
        private DataContext _context;
        private DbSet<T> table;
        public GenericRepository()
        {
            this._context = new DataContext();
            table = _context.Set<T>();
        }
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
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T objToDelete = table.Find(id);
            table.Remove(objToDelete);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
