// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{
    using System;

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class SummaryAttribute : Attribute
    {
        public string Summary { get; }

        public SummaryAttribute(string summary)
        {
            this.Summary = summary;
        }
    }
}