// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{
    public interface IFixedRange<T>
    {
        T Begin { get; }
        T End { get; }

        bool Contains(T value);
    }
}