﻿using Application.Repositories;
using Application.UnitOfWorks;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApllicationDbContext _context;
        public UnitOfWork(ApllicationDbContext context)
        {
            _context = context;   
        }
        public async ValueTask DisposeAsync()
       => await _context.DisposeAsync();

        public int Save()=> _context.SaveChanges();

        public async Task<int> SaveAsync()=> await _context.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()=> new ReadRepository<T>(_context);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()=> new WriteRepository<T>(_context);
    }
}
