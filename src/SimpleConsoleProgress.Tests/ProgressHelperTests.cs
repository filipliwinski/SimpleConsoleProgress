// MIT License
//  
//  Copyright (c) 2020-2021 Filip Liwiñski
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
//

using System;
using Xunit;

namespace SimpleConsoleProgress.Tests
{
    public class ProgressHelperTests
    {
        [Fact]
        public void WhenTotalLessThanZero_ThenThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => ProgressHelper.ValidateInputs(current: 0, total: -1));
            Assert.Equal("Unable to write progress. Total below ore equal zero.", ex.Message);
        }

        [Fact]
        public void WhenTotalEqualsZero_ThenThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => ProgressHelper.ValidateInputs(current: 0, total: 0));
            Assert.Equal("Unable to write progress. Total below ore equal zero.", ex.Message);
        }

        [Fact]
        public void WhenCurrentLessThanZero_ThenThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => ProgressHelper.ValidateInputs(current: -1, total: 1));
            Assert.Equal("Unable to write progress. Current below zero.", ex.Message);
        }

        [Fact]
        public void WhenTotalLessThanCurrent_ThenThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => ProgressHelper.ValidateInputs(current: 2, total: 1));
            Assert.Equal("Unable to write progress. Total less than current.", ex.Message);
        }
    }
}
