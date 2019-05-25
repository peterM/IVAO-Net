﻿using MalikP.IvaoLibrary.Common.Enums;
using MalikP.IvaoLibrary.Models.Other;

namespace MalikP.IvaoLibrary.Models.Clients
{
    public sealed class AirTrafficController : ClientWithRating<ATCRating>
    {
        public AirTrafficController(
            string callsign,
            string vid,
            string name,
            ClientType clientType,
            GPS location,
            string server,
            string protocol,
            string connectionTime,
            string softwareName,
            string softwareVersion,
            string administrativeVersion,
            string version,
            ATCRating rating,
            string frequency,
            FacilityType facilityType,
            string visualRange,
            string atis,
            string atisTime)
            : base(callsign,
                   vid,
                   name,
                   clientType,
                   location,
                   server,
                   protocol,
                   connectionTime,
                   softwareName,
                   softwareVersion,
                   administrativeVersion,
                   version,
                   rating)
        {
            Frequency = frequency;
            FacilityType = facilityType;
            VisualRange = visualRange;
            ATIS = atis;
            ATISTime = atisTime;
        }

        public string Frequency { get; }

        //public string FrequencyCont { get; }

        public FacilityType FacilityType { get; }

        public string VisualRange { get; }

        public string ATIS { get; }

        public string ATISTime { get; }
    }
}
