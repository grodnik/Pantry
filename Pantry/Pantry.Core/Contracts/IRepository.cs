﻿using Pantry.Core.Models;
using System.Linq;

namespace Pantry.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string ID);
        T Find(string ID);
        void Insert(T t);
        void Update(T t);
    }
}