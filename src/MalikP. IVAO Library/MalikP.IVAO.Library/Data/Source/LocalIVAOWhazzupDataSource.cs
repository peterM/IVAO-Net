﻿// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: LocalIVAOWhazzupDataSource.cs 
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

using System.IO;

using MalikP.IVAO.Library.Models.DataHolders;

namespace MalikP.IVAO.Library.Data.Source
{
    public sealed class LocalIVAOWhazzupDataSource : AbstractIVAOWhazzupDataSource, ILocalIVAOWhazzupDataSource
    {
        public LocalIVAOWhazzupDataSource(string path)
        {
            Path = path;
        }

        private string Path { get; }

        public override IWhazzup GetIVAOData()
        {
            if (string.IsNullOrWhiteSpace(Path) || !File.Exists(Path))
            {
                return Whazzup.Null;
            }

            return new Whazzup(File.ReadAllLines(Path));
        }
    }
}
