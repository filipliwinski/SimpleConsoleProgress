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
