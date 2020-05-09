// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{
    using System;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class ExceptionAttribute : Attribute
    {
        public Type Exception { get; }

        public ExceptionAttribute(Type exception)
        {
            this.Exception = exception;
        }
    }
}