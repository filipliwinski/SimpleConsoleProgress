// MIT License
//  
//  Copyright (c) 2020-2021 Filip Liwiński
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

namespace SimpleConsoleProgress
{
    internal static class ProgressHelper
    {
        internal static void ValidateInputs(int current, int total)
        {
            if (total <= 0)
            {
                throw new ArgumentException("Unable to write progress. Total below ore equal zero.");
            }
            if (current < 0)
            {
                throw new ArgumentException("Unable to write progress. Current below zero.");
            }
            if (total < current)
            {
                throw new ArgumentException("Unable to write progress. Total less than current.");
            }
        }

        internal static string GetElapsedString(TimeSpan elapsed)
        {
            var format = elapsed.Hours > 0 ? "hh\\:mm\\:ss" : elapsed.Minutes > 0 ? "mm\\:ss" : elapsed.Seconds > 0 ? "mm\\:ss\\.fff" : "ss\\.fff";
            return $" {elapsed.ToString(format)}";
        }
    }
}
