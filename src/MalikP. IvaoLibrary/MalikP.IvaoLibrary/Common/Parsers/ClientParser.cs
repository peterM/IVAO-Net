﻿using System.Collections.Generic;

using MalikP.IvaoLibrary.Common.Enums;
using MalikP.IvaoLibrary.Common.Indexes;
using MalikP.IvaoLibrary.Common.Selector;
using MalikP.IvaoLibrary.Models.Clients;

namespace MalikP.IvaoLibrary.Common.Parsers
{
    public sealed class ClientParser : AbstractParser<Client, IClientsSelector>
    {
        Dictionary<ClientType, ICLientFactory> _factories;

        public ClientParser(IClientsSelector selector)
            : base(selector)
        {
            _factories = new Dictionary<ClientType, ICLientFactory>
            {
                { ClientType.Pilot, new PilotFactory() },
                { ClientType.FollowMeCar, new FollowMeFactory() },
                { ClientType.ATC, new AirTrafficControllerFactory() },
                { ClientType.NotDefined, new NullClientFactory() }
            };
        }

        protected override Client CreateItem(string row)
        {
            string[] rowData = Split(row);

            ClientType clientType = GetClientType(rowData[ClientIndex.All.ClientType]);

            return _factories[clientType].Create(rowData);
        }

        private ClientType GetClientType(string value)
        {
            switch (value)
            {
                case "PILOT":
                    return ClientType.Pilot;

                case "FOLME":
                    return ClientType.FollowMeCar;

                case "ATC":
                    return ClientType.ATC;

                default:
                    return ClientType.NotDefined;
            }
        }
    }
}
