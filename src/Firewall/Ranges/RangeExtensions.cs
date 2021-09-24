// derived from https://github.com/jsakamoto/ipaddressrange/ which as of March 2020 was using
// mozilla public license (MPL-2.0)

namespace System.Net
{
    using System;
    using System.Net;

    public static class RangeExtensions
    {

        public static IPAddressRange WithMaskLength(this IPAddress address, int maskLength)
        {
            if (address is null) throw new ArgumentNullException(nameof(address));
            return new IPAddressRange(address, maskLength);
        }
        public static IPAddressRange To(this IPAddress from, IPAddress to)
        {
            if (from is null) throw new ArgumentNullException(nameof(from));
            if (to is null) throw new ArgumentNullException(nameof(to));

            return new IPAddressRange(from, to);
        }

        public static PortRange To(this ushort from, ushort to)
        { 
            return new PortRange(from, to);
        } 
    }

}