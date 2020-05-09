

namespace Nautilus
{
    using System; 
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class SummaryAttribute : Attribute
    {
        public SummaryAttribute(string summary)
        {
            this.Summary = summary;
        }

        public string Summary { get; }  
    }
}
