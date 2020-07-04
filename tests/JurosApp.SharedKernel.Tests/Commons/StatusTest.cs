using System;
using Xunit;
using JurosApp.SharedKernel.Commons;

namespace JurosApp.SharedKernel.Tests.Commons
{
    public class StatusTest
    {
        [Fact]
        public void should_set_suceeded_false_when_there_is_an_error_message()
        {
            var status = new Status(errorMessage: "anything");
            Assert.False(status.Succeeded);
        }

        [Fact]
        public void should_set_suceeded_false_when_there_is_an_exception()
        {
            var status = new Status(exception: new Exception());
            Assert.False(status.Succeeded);
        }

        [Fact]
        public void should_set_suceeded_true_when_there_is_not_any_exception_or_error_message()
        {
            var status = new Status();
            Assert.True(status.Succeeded);
        }

        [Fact]
        public void should_set_error_message_from_exception()
        {
            var errorMessage = "test message";
            var status = new Status(exception: new Exception(errorMessage));

            Assert.False(status.Succeeded);
            Assert.Equal(errorMessage, status.ErrorMessage);
        }
    }
}
