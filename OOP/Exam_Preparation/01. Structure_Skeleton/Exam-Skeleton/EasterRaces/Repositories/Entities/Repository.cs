﻿using EasterRaces.Repositories.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class Repository<T> : IRepository<T>
    {
        public List<T> Models { get; private set; }

        public Repository()
        {
            Models = new List<T>();
        }

        public void Add(T model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return Models.AsReadOnly();
        }

        public T GetByName(string name)
        {
            return Models.Where(x => x.GetType().Name == name).FirstOrDefault();
        }

        public bool Remove(T model)
        {
            if (Models.Contains(model))
            {
                Models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
