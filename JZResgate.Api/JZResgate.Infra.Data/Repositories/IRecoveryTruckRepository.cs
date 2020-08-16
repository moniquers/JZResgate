using JZResgate.Domain.ApiModels;
using JZResgate.Infra.Data.ApiModels;
using System;
using System.Collections.Generic;

namespace JZResgate.Infra.Data.Repositories
{
    public interface IRecoveryTruckRepository
    {
        IEnumerable<RecoveryTruckResponse> GetAll();
        RecoveryTruckResponse GetById(Guid id);
        string Create(RecoveryTruckRequest recoveryTruckRequest);
        string Update(RecoveryTruckRequest recoveryTruckRequest, Guid id);
        string Delete(Guid id);
    }
}