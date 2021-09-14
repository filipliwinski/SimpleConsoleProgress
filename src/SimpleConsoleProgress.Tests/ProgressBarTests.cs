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

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        [InlineData(BarSize.Full)]
        public void WhenDefault_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Fact]
        public void WhenElapsedTimeProvidedInSeconds_ThenProgressBarLengthEqualsFullBarSize()
        {
            var elapsed = new TimeSpan(0, 0, 1);
            var size = BarSize.Full;

            var elapsedString = ProgressHelper.GetElapsedString(elapsed);

            Assert.True(elapsedString.Length > 0);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, elapsed: elapsed);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenElapsedTimeProvidedInSecondsAndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var elapsed = new TimeSpan(0, 0, 1);

            var elapsedString = ProgressHelper.GetElapsedString(elapsed);

            Assert.True(elapsedString.Length > 0);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, elapsed: elapsed);

                Assert.Equal((int)size, progressBar.Length - elapsedString.Length);
            }
        }

        [Fact]
        public void WhenElapsedTimeProvidedInMinutes_ThenProgressBarLengthEqualsFullBarSize()
        {
            var elapsed = new TimeSpan(0, 3, 10);
            var size = BarSize.Full;

            var elapsedString = ProgressHelper.GetElapsedString(elapsed);

            Assert.True(elapsedString.Length > 0);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, elapsed: elapsed);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenElapsedTimeProvidedInMinutesAndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var elapsed = new TimeSpan(0, 3, 10);

            var elapsedString = ProgressHelper.GetElapsedString(elapsed);

            Assert.True(elapsedString.Length > 0);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, elapsed: elapsed);

                Assert.Equal((int)size, progressBar.Length - elapsedString.Length);
            }
        }

        [Fact]
        public void WhenElapsedTimeProvidedInHours_ThenProgressBarLengthEqualsFullBarSize()
        {
            var elapsed = new TimeSpan(2, 3, 10);
            var size = BarSize.Full;

            var elapsedString = ProgressHelper.GetElapsedString(elapsed);

            Assert.True(elapsedString.Length > 0);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, elapsed: elapsed);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenElapsedTimeProvidedInHoursAndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var elapsed = new TimeSpan(2, 3, 10);

            var elapsedString = ProgressHelper.GetElapsedString(elapsed);

            Assert.True(elapsedString.Length > 0);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, elapsed: elapsed);

                Assert.Equal((int)size, progressBar.Length - elapsedString.Length);
            }
        }

        [Fact]
        public void WhenLocationLeft_ThenProgressBarLengthEqualsFullBarSize()
        {
            var location = PercentLocation.Left;
            var size = BarSize.Full;

            Assert.Equal(PercentLocation.Left, location);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenLocationLeftAndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var location = PercentLocation.Left;
            var percentString = "###% ";

            Assert.Equal(PercentLocation.Left, location);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location);

                Assert.Equal((int)size, progressBar.Length - percentString.Length);
            }
        }

        [Fact]
        public void WhenLocationRight_ThenProgressBarLengthEqualsFullBarSize()
        {
            var size = BarSize.Full;
            var location = PercentLocation.Right;

            Assert.Equal(PercentLocation.Right, location);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenLocationRightAndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var location = PercentLocation.Right;
            var percentString = " ###%";

            Assert.Equal(PercentLocation.Right, location);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location);

                Assert.Equal((int)size, progressBar.Length - percentString.Length);
            }
        }

        [Fact]
        public void WhenLocationNone_ThenProgressBarLengthEqualsFullBarSize()
        {
            var size = BarSize.Full;
            var location = PercentLocation.None;

            Assert.Equal(PercentLocation.None, location);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenLocationNoneAndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var location = PercentLocation.None;

            Assert.Equal(PercentLocation.None, location);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        [InlineData(BarSize.Full)]
        public void WhenAccuracy1_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var accuracy = 1;

            Assert.Equal(1, accuracy);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        [InlineData(BarSize.Full)]
        public void WhenAccuracy2_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var accuracy = 2;

            Assert.Equal(2, accuracy);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        [InlineData(BarSize.Full)]
        public void WhenAccuracy3_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var accuracy = 3;

            Assert.Equal(3, accuracy);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Fact]
        public void WhenLocationLeftAndAccuracy1_ThenProgressBarLengthEqualsFullBarSize()
        {
            var location = PercentLocation.Left;
            var accuracy = 1;
            var size = BarSize.Full;

            Assert.Equal(1, accuracy);
            Assert.Equal(PercentLocation.Left, location);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenLocationLeftAndAccuracy1AndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var location = PercentLocation.Left;
            var accuracy = 1;
            var percentString = "###.#% ";

            Assert.Equal(1, accuracy);
            Assert.Equal(PercentLocation.Left, location);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length - percentString.Length);
            }
        }

        [Fact]
        public void WhenLocationLeftAndAccuracy2_ThenProgressBarLengthEqualsFullBarSize()
        {
            var size = BarSize.Full;
            var location = PercentLocation.Left;
            var accuracy = 2;

            Assert.Equal(2, accuracy);
            Assert.Equal(PercentLocation.Left, location);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenLocationLeftAndAccuracy2AndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var location = PercentLocation.Left;
            var accuracy = 2;
            var percentString = "###.##% ";

            Assert.Equal(2, accuracy);
            Assert.Equal(PercentLocation.Left, location);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length - percentString.Length);
            }
        }

        [Fact]
        public void WhenLocationLeftAndAccuracy3_ThenProgressBarLengthEqualsFullBarSize()
        {
            var size = BarSize.Full;
            var location = PercentLocation.Left;
            var accuracy = 3;

            Assert.Equal(3, accuracy);
            Assert.Equal(PercentLocation.Left, location);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length);
            }

        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenLocationLeftAndAccuracy3AndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var location = PercentLocation.Left;
            var accuracy = 3;
            var percentString = "###.###% ";

            Assert.Equal(3, accuracy);
            Assert.Equal(PercentLocation.Left, location);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length - percentString.Length);
            }
        }

        [Fact]
        public void WhenLocationRightAndAccuracy1_ThenProgressBarLengthEqualsFullBarSize()
        {
            var location = PercentLocation.Right;
            var accuracy = 1;
            var size = BarSize.Full;

            Assert.Equal(1, accuracy);
            Assert.Equal(PercentLocation.Right, location);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenLocationRightAndAccuracy1AndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var location = PercentLocation.Right;
            var accuracy = 1;
            var percentString = " ###.#%";

            Assert.Equal(1, accuracy);
            Assert.Equal(PercentLocation.Right, location);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length - percentString.Length);
            }
        }

        [Fact]
        public void WhenLocationRightAndAccuracy2_ThenProgressBarLengthEqualsFullBarSize()
        {
            var size = BarSize.Full;
            var location = PercentLocation.Right;
            var accuracy = 2;

            Assert.Equal(2, accuracy);
            Assert.Equal(PercentLocation.Right, location);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenLocationRightAndAccuracy2AndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var location = PercentLocation.Right;
            var accuracy = 2;
            var percentString = " ###.##%";

            Assert.Equal(2, accuracy);
            Assert.Equal(PercentLocation.Right, location);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length - percentString.Length);
            }
        }

        [Fact]
        public void WhenLocationRightAndAccuracy3_ThenProgressBarLengthEqualsFullBarSize()
        {
            var size = BarSize.Full;
            var location = PercentLocation.Right;
            var accuracy = 3;

            Assert.Equal(3, accuracy);
            Assert.Equal(PercentLocation.Right, location);
            Assert.Equal(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length);
            }

        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenLocationRightAndAccuracy3AndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var location = PercentLocation.Right;
            var accuracy = 3;
            var percentString = " ###.###%";

            Assert.Equal(3, accuracy);
            Assert.Equal(PercentLocation.Right, location);
            Assert.NotEqual(BarSize.Full, size);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length - percentString.Length);
            }
        }

        [Fact]
        public void WhenElapsedTimeProvidedInSecondsAndLocationLeftAndAccuracy1_ThenProgressBarLengthEqualsFullBarSize()
        {
            var location = PercentLocation.Left;
            var accuracy = 1;
            var elapsed = new TimeSpan(0, 0, 1);
            var size = BarSize.Full;

            var elapsedString = ProgressHelper.GetElapsedString(elapsed);

            Assert.True(elapsedString.Length > 0);
            Assert.Equal(BarSize.Full, size);
            Assert.Equal(1, accuracy);
            Assert.Equal(PercentLocation.Left, location);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, elapsed: elapsed, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length);
            }
        }

        [Theory]
        [InlineData(BarSize.Small)]
        [InlineData(BarSize.Medium)]
        [InlineData(BarSize.Big)]
        public void WhenElapsedTimeProvidedInSecondsAndLocationLeftAndAccuracy1AndBarSizeNotFull_ThenProgressBarLengthEqualsSpecified(BarSize size)
        {
            var location = PercentLocation.Left;
            var accuracy = 1;
            var elapsed = new TimeSpan(0, 0, 1);
            var percentString = "###.#% ";

            var elapsedString = ProgressHelper.GetElapsedString(elapsed);

            Assert.True(elapsedString.Length > 0);
            Assert.NotEqual(BarSize.Full, size);
            Assert.Equal(1, accuracy);
            Assert.Equal(PercentLocation.Left, location);

            for (int i = 0; i < total; i++)
            {
                var progressBar = ProgressBar.GetProgress(i, total, size, elapsed: elapsed, location: location, accuracy: accuracy);

                Assert.Equal((int)size, progressBar.Length - percentString.Length - elapsedString.Length);
            }
        }
    }
}
