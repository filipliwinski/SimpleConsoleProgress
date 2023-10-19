// Copyright (c) Filip Liwiński
//  
//  Licensed under the MIT License. See the LICENSE file in the project root for license information.
//

using System;
using Xunit;

namespace SimpleConsoleProgress.Tests
{
    public class ProgressHelperTests
    {
        [Theory]
        [InlineData(0, -1)]
        [InlineData(2, -5)]
        [InlineData(int.MaxValue, int.MinValue)]
        public void WhenTotalLessThanZero_ThenThrowsException(int current, int total)
        {
            var ex = Assert.Throws<ArgumentException>(() => ProgressHelper.ValidateInputs(current, total));

            Assert.True(total < 0);
            Assert.True(current >= 0);
            Assert.Equal("Unable to write progress. Total below or equal zero.", ex.Message);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(2, 0)]
        [InlineData(int.MaxValue, 0)]
        public void WhenTotalEqualsZero_ThenThrowsException(int current, int total)
        {
            var ex = Assert.Throws<ArgumentException>(() => ProgressHelper.ValidateInputs(current, total));

            Assert.True(total == 0);
            Assert.True(current >= 0);
            Assert.Equal("Unable to write progress. Total below or equal zero.", ex.Message);
        }

        [Theory]
        [InlineData(-1, 1)]
        [InlineData(-2, 2)]
        [InlineData(int.MinValue, int.MaxValue)]
        public void WhenCurrentLessThanZero_ThenThrowsException(int current, int total)
        {
            var ex = Assert.Throws<ArgumentException>(() => ProgressHelper.ValidateInputs(current, total));

            Assert.True(current < 0);
            Assert.True(total > 0);
            Assert.Equal("Unable to write progress. Current below zero.", ex.Message);
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(5, 3)]
        [InlineData(int.MaxValue, 1)]
        public void WhenTotalLessThanCurrent_ThenThrowsException(int current, int total)
        {
            var ex = Assert.Throws<ArgumentException>(() => ProgressHelper.ValidateInputs(current, total));

            Assert.True(total < current);
            Assert.Equal("Unable to write progress. Total less than current.", ex.Message);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-9999)]
        [InlineData(-1)]
        public void WhenAccuracyLessThanZero_ThenReturnsInteger(int accuracy)
        {
            var accuracyLevel = ProgressHelper.SetAccuracy(accuracy);

            Assert.True(accuracy < 0);
            Assert.Equal(Accuracy.Integer, accuracyLevel);
        }

        [Fact]
        public void WhenAccuracyEqualsZero_ThenReturnsInteger()
        {
            var accuracy = 0;

            var accuracyLevel = ProgressHelper.SetAccuracy(accuracy);

            Assert.Equal(0, accuracy);
            Assert.Equal(Accuracy.Integer, accuracyLevel);
        }

        [Fact]
        public void WhenAccuracyEqualsOne_ThenReturnsLow()
        {
            var accuracy = 1;

            var accuracyLevel = ProgressHelper.SetAccuracy(accuracy);

            Assert.Equal(1, accuracy);
            Assert.Equal(Accuracy.Low, accuracyLevel);
        }

        [Fact]
        public void WhenAccuracyEqualsTwo_ThenReturnsMedium()
        {
            var accuracy = 2;

            var accuracyLevel = ProgressHelper.SetAccuracy(accuracy);

            Assert.Equal(2, accuracy);
            Assert.Equal(Accuracy.Medium, accuracyLevel);
        }

        [Fact]
        public void WhenAccuracyEqualsThree_ThenReturnsHigh()
        {
            var accuracy = 3;

            var accuracyLevel = ProgressHelper.SetAccuracy(accuracy);

            Assert.Equal(3, accuracy);
            Assert.Equal(Accuracy.High, accuracyLevel);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(9999)]
        [InlineData(int.MaxValue)]
        public void WhenAccuracyMoreThanThree_ThenReturnsInteger(int accuracy)
        {
            var accuracyLevel = ProgressHelper.SetAccuracy(accuracy);

            Assert.True(accuracy > 3);
            Assert.Equal(Accuracy.High, accuracyLevel);
        }
    }
}
