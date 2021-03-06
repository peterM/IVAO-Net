﻿// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: FollowMeBuilder.cs 
// Company: MalikP.
//
// Repository: https://github.com/peterM/IVAO-Library
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using MalikP.IVAO.Library.Common.Enums;
using MalikP.IVAO.Library.Models.Other;

namespace MalikP.IVAO.Library.Models.Clients
{
    public sealed class FollowMeBuilder : AbstractClientBuilder<FollowMeBuilder>
    {
        private FollowMeBuilder()
        {
        }

        public static FollowMeBuilder Create()
        {
            return new FollowMeBuilder().WithClientType(ClientType.FollowMeCar);
        }

        public static FollowMeBuilder FromModel(FollowMe model)
        {
            return new FollowMeBuilder()
                .WithClientType(model.ClientType)
                .WithAdministrativeVersion(model.AdministrativeVersion)
                .WithCallsign(model.Callsign)
                .WithClientRating(model.ClientRating)
                .WithConnectionTime(model.ConnectionTime)
                .WithLocation(model.Location == null ? model.Location : (GPS)model.Location.Clone())
                .WithName(model.Name)
                .WithProtocol(model.Protocol)
                .WithServer(model.Server)
                .WithSoftwareName(model.SoftwareName)
                .WithSoftwareVersion(model.SoftwareVersion)
                .WithVID(model.VID);
        }

        public FollowMe Build()
        {
            return new FollowMe(
                callsign,
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
                clientRating);
        }

        protected override FollowMeBuilder GetBuilder()
        {
            return this;
        }
    }
}
