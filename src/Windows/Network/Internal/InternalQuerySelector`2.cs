/// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus.Windows.Network.Internal
{
    using Nautilus.Windows.Network;

    using System;
    using System.Linq.Expressions;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Runtime.InteropServices;

    internal sealed class QuerySelectorBinder<TTable, TRow> : IRowAdapter
        where TRow : IRowAdaptable
    {
        private static readonly Type[] s_signture = { typeof(IntPtr), typeof(Type) };
        public Func<IntPtr, ITrafficRow> Adapt { get; }
        public AddressFamily AddressFamily { get; }
        public Func<IntPtr, uint> CalculateEntries { get; }
        public int RowSize { get; }
        public Type RowType { get; }
        public Type TableType { get; }

        internal QuerySelectorBinder(AddressFamily family)
        {
            this.TableType = typeof(TTable);
            this.RowType = typeof(TRow);

            this.RowSize = Marshal.SizeOf(this.RowType);
            this.AddressFamily = family;

            var parameter = Expression.Parameter(typeof(IntPtr), "intptr");

            // (intptr) => (TTable)Marshal.PtrToStructure(intptr, typeof(TTable)).dwNumEntries;
            var field =
                Expression.Field(
                    Expression.Convert(
                        Expression.Call(typeof(Marshal).GetMethod(nameof(Marshal.PtrToStructure), s_signture),
                            parameter,
                            Expression.Constant(this.TableType)), this.TableType),
                    "_dwNumEntries");
            this.CalculateEntries = (Func<IntPtr, uint>)Expression.Lambda(field, parameter).Compile();

            // (intptr) => (ITrafficAdaptable)Marshal.PtrToStructure(intptr, typeof(TRow)).ToTraffic();
            var traffic =
                Expression.Call(
                    Expression.Convert(
                        Expression.Call(typeof(Marshal).GetMethod(nameof(Marshal.PtrToStructure), s_signture),
                            parameter,
                            Expression.Constant(this.RowType)), typeof(IRowAdaptable)), typeof(IRowAdaptable).GetMethod(nameof(IRowAdaptable.ToRowAdapter), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
            this.Adapt = (Func<IntPtr, ITrafficRow>)Expression.Lambda(traffic, parameter).Compile();
        }
    }
}