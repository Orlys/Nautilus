/// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus
{
    using System;
    using System.Linq.Expressions;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Runtime.InteropServices;

    internal class RowBinderInfo
    {
        internal readonly Func<IntPtr, TcpTrafficRow> Adapt;
        internal readonly Func<IntPtr, uint> CalculateEntries;
        internal readonly AddressFamily Family;
        internal readonly int PerRowSize;

        private RowBinderInfo(AddressFamily family, int perRowSize, Func<IntPtr, uint> calculateEntriesDelegate, Func<IntPtr, TcpTrafficRow> adaptDelegate)
        {
            this.Family = family;
            this.PerRowSize = perRowSize;
            this.CalculateEntries = calculateEntriesDelegate;
            this.Adapt = adaptDelegate;
        }

        public static RowBinderInfo Create<TTable, TRow>(AddressFamily family)
            where TTable : ITcpTableContract
            where TRow : ITcpRowContract
        {
            var tableType = typeof(TTable);
            var rowType = typeof(TRow);
            var signture = new[] { typeof(IntPtr), typeof(Type) };

            var perRowSize = Marshal.SizeOf(rowType);

            //Native.IPv4Table, Native.IPv4Row > (AddressFamily.InterNetwork


            var parameter = Expression.Parameter(typeof(IntPtr), "intptr");

            // (intptr) => (TTable)Marshal.PtrToStructure(intptr, typeof(TTable)).dwNumEntries;
            var field =
                Expression.Field(
                    Expression.Convert(
                        Expression.Call(typeof(Marshal).GetMethod(nameof(Marshal.PtrToStructure), signture),
                            parameter,
                            Expression.Constant(tableType)), tableType),
                    "_dwNumEntries");
            var calculateEntries = Expression.Lambda<Func<IntPtr, uint>>(field, parameter).Compile();

            // (intptr) => (ITrafficAdaptable)Marshal.PtrToStructure(intptr, typeof(TRow)).ToRow();
            var toRowMethod = typeof(ITcpRowContract).GetMethod(nameof(ITcpRowContract.ToRow), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var traffic =
                Expression.Call(
                    Expression.Convert(
                        Expression.Call(typeof(Marshal).GetMethod(nameof(Marshal.PtrToStructure), signture),
                            parameter,
                            Expression.Constant(rowType)), typeof(ITcpRowContract)), toRowMethod);

            var adapt = Expression.Lambda<Func<IntPtr, TcpTrafficRow>>(traffic, parameter).Compile();

            return new RowBinderInfo(family, perRowSize, calculateEntries, adapt);
        }

    }

}