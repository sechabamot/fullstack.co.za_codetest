using CoMute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Services
{
    public interface ICarpoolService
    {
        Task<CreateCarpoolResponse> Create(CreateCarpoolRequest request);
        Task<JoinOrLeaveCarpoolResponse> JoinCarPool(JoinOrLeaveCarpoolRequest request);
        Task<JoinOrLeaveCarpoolResponse> LeaveCarPool(JoinOrLeaveCarpoolRequest request);
        List<Carpool> ReadOwnersCarpools(string userName);
        List<Carpool> ReadJoinedCarpools(string userName);
    }
}
