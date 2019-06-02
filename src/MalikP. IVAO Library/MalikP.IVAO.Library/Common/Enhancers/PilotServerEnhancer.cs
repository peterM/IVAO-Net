﻿// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: PilotServerEnhancer.cs 
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

using System.Linq;

using MalikP.IVAO.Library.Models.Clients;
using MalikP.IVAO.Library.Models.Servers;
using MalikP.IVAO.Library.Providers;

namespace MalikP.IVAO.Library.Common.Enhancers
{
    public class PilotServerEnhancer : AbstractServerEnhancer<Pilot>, IPilotServerEnhancer
    {
        public PilotServerEnhancer(IServersProvider serversProvider)
            : base(serversProvider)
        {
        }

        public override Pilot Enhance(Pilot modelToEnhance)
        {
            if (modelToEnhance.Server == null)
            {
                return modelToEnhance;
            }

            Server server = ServersProvider.GetData()
                .FirstOrDefault(d => d.Hostname == modelToEnhance.Server.Hostname);

            if (server == null)
            {
                return modelToEnhance;
            }

            return PilotBuilder.FromModel(modelToEnhance)
                .WithServer((Server)server.Clone())
                .Build();
        }
    }
}
