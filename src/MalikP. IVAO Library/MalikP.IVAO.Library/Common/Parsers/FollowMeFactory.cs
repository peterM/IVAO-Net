﻿// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: FollowMeFactory.cs 
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
using MalikP.IVAO.Library.Models.Clients;

namespace MalikP.IVAO.Library.Common.Parsers
{
    public sealed class FollowMeFactory : AbstractClientFactory<FollowMe>
    {
        public FollowMeFactory()
            : base(ClientType.FollowMeCar)
        {
        }

        public override FollowMe Create(string[] rowData)
        {
            if (rowData.Length == 0)
            {
                return null;
            }

            return AssignGeneralData(FollowMeBuilder.Create(), rowData)
                .Build();
        }
    }
}
