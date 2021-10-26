using CoMuse.Models;
using CoMute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Helper
{
    public static class CarpoolHelper
    {
        public static bool AreCarpool_DateAndTimeFrames_OverLapping(Carpool xC, Carpool yC)
        {
            bool timesAreOverlap = xC.DepartureTime < yC.ArrivalTime || xC.ArrivalTime > yC.DepartureTime;
            if (timesAreOverlap)
            {
                foreach (Day day in xC.DaysAvailable)
                {
                    return yC.DaysAvailable.Contains(day);
                }
            }
            return false;
        }
    }
}
