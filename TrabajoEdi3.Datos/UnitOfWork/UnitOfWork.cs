using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoEdi3.Datos.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContex _Context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(DbContex contex)
        {
            _Context = contex;
              
        }
        public void BeginTransaction()
        {
            _transaction= _Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction?.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }
    }
}
