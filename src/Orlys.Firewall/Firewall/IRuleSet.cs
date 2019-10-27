
namespace Orlys.Firewall
{
    using System;
    using System.Collections.Generic;

    internal interface IRuleSet
    {
        IRule AddOrGet(string name);
        void Clear();
        IEnumerable<IRule> GetList(Predicate<IRule> filter = null);
        bool Remove(string name);
    }
}