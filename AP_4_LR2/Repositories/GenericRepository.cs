﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_4_LR2.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        protected readonly LibraryContext _context;
        protected readonly DbSet<TModel> _dbSet;

        public GenericRepository(LibraryContext context)
        {
            _context = context;
            _dbSet = _context.Set<TModel>();
        }

        public TModel GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Create(TModel model)
        {
            _dbSet.Add(model);
        }

        public void Update(TModel model)
        {
            _dbSet.Update(model);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Помилка при збереженні змін:");
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }


        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

}
