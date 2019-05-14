using System;

namespace RundvisningRagnaRock.ViewModels
{
  
    public class MissingLocationException : Exception
    {
        public MissingLocationException()
        {
        }

        public MissingLocationException(string message) : base(message)
        {
        }

        public MissingLocationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}