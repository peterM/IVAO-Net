﻿// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: Server.cs 
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

using System;
using System.Net;
using System.Runtime.Serialization;

namespace MalikP.IVAO.Library.Models.Servers
{
    [DataContract]
    public sealed class Server : AbstractIvaoModel
    {
        public Server(
            string hostname,
            IPAddress ip,
            string location,
            string name,
            bool connectionsAllowed,
            int maximumConnections)
        {
            Hostname = hostname ?? string.Empty;
            IP = ip;
            Location = location ?? string.Empty;
            Name = name ?? string.Empty;
            ConnectionsAllowed = connectionsAllowed;
            MaximumConnections = maximumConnections;
        }

        private Server()
        {
        }

        [DataMember]
        public string Hostname { get; private set; }

        public IPAddress IP { get; private set; }

        [DataMember]
        private string IPAddressIntenal
        {
            get { return IP == null ? string.Empty : IP.ToString(); }
            set { IP = IPAddress.Parse(value); }
        }

        [DataMember]
        public string Location { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public bool ConnectionsAllowed { get; private set; }

        [DataMember]
        public int MaximumConnections { get; private set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            Server casted = obj as Server;
            if (casted == null)
            {
                return false;
            }

            return base.Equals(obj)
                && string.Equals(casted.Hostname, Hostname, StringComparison.InvariantCultureIgnoreCase)
                && Equals(casted.IP, IP)
                && Equals(casted.ConnectionsAllowed, ConnectionsAllowed)
                && Equals(casted.MaximumConnections, MaximumConnections)
                && string.Equals(casted.Name, Name, StringComparison.InvariantCultureIgnoreCase)
                && string.Equals(casted.Location, Location, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return base.GetHashCode()
                    + (Hostname.ToUpper().GetHashCode() * 3)
                    + (IP.GetHashCode() * 3)
                    + (ConnectionsAllowed.GetHashCode() * 3)
                    + (MaximumConnections.GetHashCode() * 3)
                    + (Name.ToUpper().GetHashCode() * 3)
                    + (Location.ToUpper().GetHashCode() * 3) * 17;
            }
        }

        public override object Clone()
        {
            return ServerBuilder.FromModel(this)
                .Build();
        }

        public static ServerBuilder Builder => ServerBuilder.Create();

        public static bool operator !=(Server instance1, Server instance2)
        {
            return !instance1.Equals(instance2);
        }

        public static bool operator ==(Server instance1, Server instance2)
        {
            return instance1.Equals(instance2);
        }
    }
}
