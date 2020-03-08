// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus.Windows.Firewall
{
    public interface IFixedRange<T>
    {
        T Begin { get; }
        T End { get; }

        bool Contains(T value);
    }
}