using System;
using System.Runtime.Serialization;

namespace WebApi.Services
{
    [Serializable]
    internal class NoConnectionException : Exception
    {
        private object ex;

        public NoConnectionException()
        {
        }

        public NoConnectionException(object ex)
        {
            this.ex = ex;
        }

        public NoConnectionException(string message) : base(message)
        {
        }

        public NoConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}