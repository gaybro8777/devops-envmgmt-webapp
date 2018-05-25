using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBDevOps.Models;

namespace DBDevOps.DataProvider
{
    public interface IEnvReqStatusTypes
    {
        Task<IEnumerable<tblEnvReqStatusTypes>> GetEnvReqStatusTypes();

        Task<tblEnvReqStatusTypes> GetEnvReqStatusType(int id);

        Task AddEnvReqStatusType(tblEnvReqStatusTypes envreqsstatustypes);

        Task UpdateEnvReqStatusType(tblEnvReqStatusTypes evreqstatustypes);

        Task DeleteEnvReqStatusType(int id);
    }
}
