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
using Xunit;

namespace SimpleConsoleProgress.Tests
{
    public class ProgressBarTests
    {
        private readonly int total = 20;

        [Fact]
        public void WhenDefault_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(0, total, barLength);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenElapsedTimeProvided_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var elapsed = new TimeSpan(0, 0, 1);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(0, total, barLength, elapsed: elapsed);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenLocationLeft_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var location = PercentLocation.Left;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(0, total, barLength, location: location);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenLocationRight_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var location = PercentLocation.Right;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(0, total, barLength, location: location);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenLocationNone_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var location = PercentLocation.None;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(0, total, barLength, location: location);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenAccuracy1_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var accuracy = 1;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(0, total, barLength, accuracy: accuracy);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenAccuracy2_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var accuracy = 2;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(0, total, barLength, accuracy: accuracy);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenAccuracy3_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var accuracy = 3;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(0, total, barLength, accuracy: accuracy);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenLocationLeftAndAccuracy1_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var location = PercentLocation.Left;
            var accuracy = 1;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(0, total, barLength, location: location, accuracy: accuracy);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenLocationLeftAndAccuracy2_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var location = PercentLocation.Left;
            var accuracy = 2;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, barLength, location: location, accuracy: accuracy);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenLocationLeftAndAccuracy3_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var location = PercentLocation.Left;
            var accuracy = 3;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, barLength, location: location, accuracy: accuracy);

                Assert.Equal(barLength, progressBar.Length);
            }
            
        }

        [Fact]
        public void WhenLocationRightAndAccuracy1_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var location = PercentLocation.Right;
            var accuracy = 1;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, barLength, location: location, accuracy: accuracy);

                Assert.Equal(barLength, progressBar.Length);
            }
            
        }

        [Fact]
        public void WhenLocationRightAndAccuracy2_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var location = PercentLocation.Right;
            var accuracy = 2;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, barLength, location: location, accuracy: accuracy);

                Assert.Equal(barLength, progressBar.Length);
            }
        }

        [Fact]
        public void WhenLocationRightAndAccuracy3_ThenProgressBarLengthEqualsSpecified()
        {
            var barLength = 120;
            var location = PercentLocation.Right;
            var accuracy = 3;

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(0, total, barLength, location: location, accuracy: accuracy);

                Assert.Equal(barLength, progressBar.Length);
            }
        }
    }
}
