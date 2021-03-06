﻿// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: AirportBuilder.cs 
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

namespace MalikP.IVAO.Library.Models.Airports
{
    public sealed class AirportBuilder
    {
        private string _icao;
        private string _atis;

        private AirportBuilder()
        {
        }

        public static AirportBuilder Create()
        {
            return new AirportBuilder();
        }

        public static AirportBuilder FromModel(Airport model)
        {
            return new AirportBuilder()
                .WithATIS(model.ATIS)
                .WithICAO(model.ICAO);
        }

        public AirportBuilder WithICAO(string icao)
        {
            _icao = icao;
            return this;
        }

        public AirportBuilder WithATIS(string atis)
        {
            _atis = atis;
            return this;
        }

        public Airport Build()
        {
            return new Airport(
                _icao,
                _atis);
        }
    }
}
