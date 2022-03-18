using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Data
{
    internal static class DataContextExtension
    {
        public static EntityEntry<TEntity> AttachToFetch<TContext,TEntity>(this TContext context, TEntity entity) 
            where TContext: DataContext where TEntity : BaseModel
        {
            context.Attach(entity);
            return context.Entry(entity);
        }
        public static EntityEntry<TEntity> PropertyToFetch<TEntity, TProperty>(this EntityEntry<TEntity> entityEntry, Expression<Func<TEntity, TProperty>> propertyExpression)
         where TEntity : BaseModel
        {
            entityEntry.Property(propertyExpression).IsModified = true;
            return entityEntry;
        }

        public static int Fetch<TEntity>(this EntityEntry<TEntity> entityEntry)
            where TEntity : BaseModel
        {
            return entityEntry.Context.SaveChanges();
        }
    }
}
