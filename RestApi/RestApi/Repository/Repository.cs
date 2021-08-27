using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Repository
{
    public class Repository<T> where T : BaseEntity
    {
        private readonly Context _context;
        private readonly DbSet<T> dataset;

        public Repository(Context context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id == id);
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch
            {
                throw;
            }
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            try
            {
                var result = dataset.SingleOrDefault(p => p.Id == item.Id);
                if (result == null) return null;

                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();

                return item;
            }
            catch
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            if (!Exists(id)) return;

            try
            {
                var result = dataset.SingleOrDefault(p => p.Id == id);
                if (result == null) return;

                dataset.Remove(result);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool Exists(long id) => dataset.Any(p => p.Id == id);
    }
}
