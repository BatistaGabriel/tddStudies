using System;
using Xunit;

namespace OnlineCourses.Domain.Test._Utils
{
    public static class AssertExtension
    {
        /// <summary>
        /// This extension method was created to better handle the
        /// exception messages thrown by ArgumentException.
        /// </summary>
        public static void HasMessage(this ArgumentException exception, string message)
        {
            if(exception.Message.Equals(message))
                Assert.True(true);

            Assert.False(true, $"Expected message: '{exception.Message}' but got '{message}'");
        }
    }
}