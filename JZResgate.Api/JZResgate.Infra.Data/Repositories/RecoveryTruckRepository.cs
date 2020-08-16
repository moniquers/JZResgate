using JZResgate.Domain.ApiModels;
using JZResgate.Domain.Models;
using JZResgate.Infra.Data.ApiModels;
using JZResgate.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;


namespace JZResgate.Infra.Data.Repositories
{
    public class RecoveryTruckRepository : BaseRepository<RecoveryTruck>, IRecoveryTruckRepository
    {
        public RecoveryTruckRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<RecoveryTruckResponse> GetAll()
        {
            var response = _dbSet.ToList();

            return response.Select(x => new RecoveryTruckResponse
            {
                Id = x.Id,
                Alias = x.Alias,
                Plate = x.Plate,
                Model = x.Model,
                CreateDate = x.CreateDate
            });
        }

        public RecoveryTruckResponse GetById(Guid id)
        {
            var recoveryTruck = _dbSet.SingleOrDefault(x => x.Id.Equals(id));

            if (recoveryTruck == null)
                throw new Exception("Guincho não localizado");

            return new RecoveryTruckResponse
            {
                Id = recoveryTruck.Id,
                Alias = recoveryTruck.Alias,
                Model = recoveryTruck.Model,
                Plate = recoveryTruck.Plate,
                CreateDate = recoveryTruck.CreateDate
            };
        }

        public string Create(RecoveryTruckRequest recoveryTruckRequest)
        {
            try
            {
                var addRecoveryTruck = new RecoveryTruck
                {
                    Alias = recoveryTruckRequest.Alias,
                    Plate = recoveryTruckRequest.Plate,
                    Model = recoveryTruckRequest.Model,
                    CreateDate = DateTime.Now
                };

                _context.Set<RecoveryTruck>().Add(addRecoveryTruck);
                _context.SaveChanges();

                return null;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }

        public string Update(RecoveryTruckRequest recoveryTruckRequest, Guid id)
        {
            try
            {
                var recoveryTruck = _dbSet
                    .Where(o => o.Id.Equals(id)).FirstOrDefault();

                if (recoveryTruck == null)
                    throw new Exception("Guincho não localizado");

                recoveryTruck.Alias = recoveryTruckRequest.Alias;
                recoveryTruck.Plate = recoveryTruckRequest.Plate;
                recoveryTruck.Model = recoveryTruckRequest.Model;

                _context.SaveChanges();

                return null;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string Delete(Guid id)
        {
            try
            {
                var recoveryTruck = _dbSet
                    .Where(x => x.Id.Equals(id)).SingleOrDefault();

                if (recoveryTruck == null)
                    throw new Exception("Guincho não localizado");

                _context.Remove(recoveryTruck);
                _context.SaveChanges();

                return null;

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}
