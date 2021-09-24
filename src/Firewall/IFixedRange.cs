// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{
    public interface IFixedRange<TUnit>
    {
        TUnit Begin { get; }
        TUnit End { get; }

        bool Contains(TUnit value);
    }
}