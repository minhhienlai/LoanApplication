﻿using Microsoft.AspNetCore.JsonPatch;
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
                    //_context.Entry(obj).Property(o => o.CreatedAt).IsModified = true;
                    //_context.AttachToFetch(obj).PropertyToFetch(o => o.CreatedAt)
                    //                            .PropertyToFetch(o => o.CreatedBy)
                    //                            .Fetch();
                    //_context.Attach(obj).PropertyToFetch(o => o.CreatedAt)
                    //                            .PropertyToFetch(o => o.CreatedBy)
                    //                            .Fetch();
                    Save();
                }
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        public abstract bool Fetch(int id, T obj);
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

        public PaginatedList<T> GetPaging(int? pageNumber, int? pageSize)
        {
            List<T> listAll = table.ToList();
            return PaginatedList<T>.Create(listAll, pageNumber ?? 1, pageSize ?? Common.DEFAULT_PAGE_SIZE);
        }

       
    }
}
