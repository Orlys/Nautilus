using System;
using System.Collections.Generic;

namespace Orlys.Firewall
{
    public interface IRuleSet
    {
        IRule AddOrGet(string name);
        void Clear();
        IEnumerable<IRule> GetList(Predicate<IRule> filter = null);
        bool Remove(string name);
    }
}