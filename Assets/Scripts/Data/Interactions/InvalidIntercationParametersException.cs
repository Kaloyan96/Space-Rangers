using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class InvalidIntercationParameters : Exception
{
    public InvalidIntercationParameters()
    {
    }

    public InvalidIntercationParameters(string message) : base(message)
    {
    }

    public InvalidIntercationParameters(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected InvalidIntercationParameters(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
