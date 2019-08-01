﻿
namespace Orlys.Firewall.Collections
{
    public interface IFixedRange<T>
    {
        T Begin { get; }
        T End { get; }
        bool Contains(T value);
    }
} 