﻿namespace MusicLibrary.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T Get(int id);

        void Add(T item);

        void Delete(int id);

        void Update(int id, T item);
    }
}