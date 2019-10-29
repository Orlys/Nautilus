// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Dev
{
    using System;

    public sealed class ConsoleColorHelper : IDisposable
    {
        public static ConsoleColorHelper Create(ConsoleColor color) => new ConsoleColorHelper(color);

        private readonly ConsoleColor _color;
        private ConsoleColorHelper(ConsoleColor color)
        {
            this._color = Console.ForegroundColor;
            Console.ForegroundColor = color;
        }

        void IDisposable.Dispose() => Console.ForegroundColor = this._color;
    }
}
