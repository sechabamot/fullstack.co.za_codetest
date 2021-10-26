using CoMute.Data;
using CoMute.Helper;
using CoMute.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Services
{
    public class CarpoolService : ICarpoolService
    {
        public ApplicationDbContext _dbContext { get; }

        public CarpoolService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateCarpoolResponse> Create(CreateCarpoolRequest request)
        {
            Carpool cToCreate = new Carpool(request);

            List<Carpool> uCarpools = _dbContext.Carpools.Where(uC => 
            uC.Owner.Equals(request.Owner)).ToList() ?? new List<Carpool>();

            foreach(Carpool cP in uCarpools)
            {
                if (CarpoolHelper.AreCarpool_DateAndTimeFrames_OverLapping(cToCreate, cP))
                {
                    string depTime = new DateTime(cToCreate.DepartureTime.Ticks).ToShortTimeString(); 
                    string arrTime = new DateTime(cToCreate.ArrivalTime.Ticks).ToShortTimeString();

                    string message = $"You have another carpool during {depTime} and {arrTime} for one of the selected travel days";
                    return new CreateCarpoolResponse(false, message, cP);
                }
            }

            await _dbContext.AddAsync(cToCreate);
            await _dbContext.SaveChangesAsync();

            return new CreateCarpoolResponse(true, "Carpool successfuly created. Will let you know if someone wants to join you.", cToCreate);
        }

        public async Task<JoinOrLeaveCarpoolResponse> JoinCarPool(JoinOrLeaveCarpoolRequest request)
        {
            Carpool carpool = _dbContext.Carpools.FirstOrDefault(c => c.Id.Equals(request.CarpoolId));
            if (carpool == null)
            {
                return new JoinOrLeaveCarpoolResponse
                {
                    IsSuccess = false,
                    Message = "The carpool you trying to join is no longer available",
                };
            }
            else
            {

                if (carpool.Passangers.Any(p => p.UserName.Equals(request.PassangerUserName)))
                {
                    return new JoinOrLeaveCarpoolResponse
                    {
                        IsSuccess = false,
                        Message = "You have already joined this carpool",
                    };
                }

                if (carpool.Passangers.Count == carpool.NoSeatsAvailable)
                {
                    return new JoinOrLeaveCarpoolResponse
                    {
                        IsSuccess = false,
                        Message = "There is no more room on the carpool for you to join",
                    };
                }

                List<CarpoolPassangers> newList = carpool.Passangers;
                newList.Add(new CarpoolPassangers(request.PassangerUserName));
                carpool.Passangers = newList;

                _dbContext.Carpools.Update(carpool);
                await _dbContext.SaveChangesAsync();

                return new JoinOrLeaveCarpoolResponse
                {
                    IsSuccess = true,
                    Message = "You have successfuly joined this carpool",
                    Carpool = carpool
                };

            }
        
        }

        public async Task<JoinOrLeaveCarpoolResponse> LeaveCarPool(JoinOrLeaveCarpoolRequest request)
        {
            Carpool carpool = _dbContext.Carpools.FirstOrDefault(c => c.Id.Equals(request.CarpoolId));
            if (carpool == null)
            {
                return new JoinOrLeaveCarpoolResponse
                {
                    IsSuccess = false,
                    Message = "The carpool you trying leave is no longer available",
                };
            }
            else
            {
                if (carpool.Passangers != null)
                {
                    List<CarpoolPassangers> newList = carpool.Passangers;

                    if (carpool.Passangers.Any(p => p.UserName.Equals(request.PassangerUserName)))
                    {
                        
                        newList.Remove(carpool.Passangers.FirstOrDefault(p
                            => p.UserName.Equals(request.PassangerUserName)));
                        carpool.Passangers = newList;

                        _dbContext.Carpools.Update(carpool);
                        await _dbContext.SaveChangesAsync();
                    }
                }

                return new JoinOrLeaveCarpoolResponse
                {
                    IsSuccess = true,
                    Message = "You have successfuly left this carpool",
                    Carpool = carpool
                };
            }
        }

        public List<Carpool> ReadOwnersCarpools(string userName)
        {
            return _dbContext.Carpools.Where(uC =>
                       uC.Owner.Equals(userName)).ToList();
        }

        public List<Carpool> ReadJoinedCarpools(string userName)
        {
            List<Carpool> carpools = new List<Carpool>();
            foreach (Carpool cpool in _dbContext.Carpools)
            {
                List<CarpoolPassangers> passangers = cpool.Passangers;
                if (passangers != null)
                {
                    foreach (CarpoolPassangers p in passangers)
                    {
                        if (p.UserName.Equals(userName))
                        {
                            carpools.Add(cpool);
                        }
                    }
                }
            }

            return carpools;
        }
    }
}
