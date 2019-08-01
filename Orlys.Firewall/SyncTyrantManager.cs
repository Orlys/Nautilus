namespace SyncTyrant.Firewall
{
    using NetFwTypeLib;
    using SyncTyrant.Firewall.Internal;
    using SyncTyrant.Firewall.Model;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public sealed class SyncTyrantManager : IDisposable
    {
        private static readonly Lazy<SyncTyrantManager> lazy = new Lazy<SyncTyrantManager>(() => new SyncTyrantManager());
        public static SyncTyrantManager Instance { get { return lazy.Value; } }

        private readonly string _groupName;

        private readonly Dictionary<string, SyncTyrantRule> _rules;

        private readonly Action<INetFwRule> _createHandler;
        private readonly Action<string> _deleteHandler;
        private readonly Func<string, INetFwRule> getHandler;

        private SyncTyrantManager()
        {
            this._groupName = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyTrademarkAttribute>().Trademark;

            this._rules = new Dictionary<string, SyncTyrantRule>();
            var policy2 = FwTypes.CreatePolicy2();

            this._createHandler = policy2.Rules.Add;
            this._deleteHandler = policy2.Rules.Remove;
            this.getHandler = policy2.Rules.Item;

            foreach (INetFwRule r in policy2.Rules)
            {
                if (string.Equals(r.Grouping, this._groupName, StringComparison.OrdinalIgnoreCase))
                {
                    this.AddOrGet(r.Name, r);
                } 
            }
        }

        private static readonly string[] s_separator = { "," };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void AppendSharpSymbolToNamePrefix(ref string name)
        {
            if (name.StartsWith("#"))
                return;
            name = "#" + name;
        }
        /// <summary>
        /// 加入規則，若規則已經存在則直接回傳該規則物件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public SyncTyrantRule AddOrGet(string name)
        {
            return AddOrGet(name, null);
        }
        private SyncTyrantRule AddOrGet(string name, INetFwRule rule)
        {
            ArgumentChecker.EnsureNameFormatIsValid(name, out var startWithSharp);
            if (!startWithSharp)
            {
                AppendSharpSymbolToNamePrefix(ref name);
            }

            if (!this._rules.ContainsKey(name))
            {
                if (rule == null)
                {
                    rule = FwTypes.CreateRule();
                    rule.Name = name;
                    rule.Grouping = this._groupName;
                    _createHandler(rule);

                    rule = this.getHandler(name);
                }

                var stRule = new SyncTyrantRule(_deleteHandler, rule) { Enabled = true };

                var separated = default(string[]);
                if (!string.IsNullOrWhiteSpace(rule.LocalAddresses))
                {
                    separated = rule.LocalAddresses.Split(s_separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var entity in separated)
                    {
                        var range = entity.Split('/')[0];
                        if (FixedIPv4Range.TryParse(range, out var r))
                            stRule.LocalAddresses.Add(r, false);
                    }
                }
                if (!string.IsNullOrWhiteSpace(rule.RemoteAddresses))
                {
                    separated = rule.RemoteAddresses.Split(s_separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var entity in separated)
                    {
                        var range = entity.Split('/')[0];
                        if (FixedIPv4Range.TryParse(range, out var r))
                            stRule.RemoteAddresses.Add(r, false);
                    }
                }
                if (!string.IsNullOrWhiteSpace(rule.LocalPorts))
                {
                    separated = rule.LocalPorts.Split(s_separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var entity in separated)
                    {
                        var range = entity.Split('/')[0];
                        if (FixedPortRange.TryParse(range, out var r))
                            stRule.LocalPorts.Add(r, false);
                    }
                }
                if (!string.IsNullOrWhiteSpace(rule.RemotePorts))
                {
                    separated = rule.RemotePorts.Split(s_separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var entity in separated)
                    {
                        var range = entity.Split('/')[0];
                        if (FixedPortRange.TryParse(range, out var r))
                            stRule.RemotePorts.Add(r, false);
                    }
                }

                _rules[name] = stRule;
            }

            return _rules[name];
        }

        public IEnumerable<SyncTyrantRule> Rules => this._rules.Values;

        /// <summary>
        /// 刪除規則
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Delete(string name)
        {
            ArgumentChecker.EnsureNameFormatIsValid(name, out var startWithSharp);
            if (!startWithSharp)
            {
                AppendSharpSymbolToNamePrefix(ref name);
            }

            if (_rules.ContainsKey(name))
            {
                _rules.Remove(name);
                _deleteHandler(name);
            }
            return false;
        }

        /// <summary>
        /// 清除所有規則
        /// </summary>
        public void Clear()
        {
            foreach (IDisposable r in this._rules.Values)
            {
                r.Dispose();
            }
            this._rules.Clear();
        }

        void IDisposable.Dispose() => this.Clear();
    }
}