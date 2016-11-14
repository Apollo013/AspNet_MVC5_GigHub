using System;

namespace GugHub.Exceptions
{
    public class ContentNotFoundException : Exception
    {
        public ContentNotFoundException(string message) : base(message)
        { }
    }
}