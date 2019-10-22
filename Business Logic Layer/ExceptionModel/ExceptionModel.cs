using System;

namespace Business_Logic_Layer.ExceptionModel
{
    public class ArgumentException : Exception
    {
        public ArgumentException(string message) : base(message)
        {

        }
    }
}
