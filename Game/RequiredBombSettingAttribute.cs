namespace KTANE.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Method)]
    internal class RequiredBombSettingAttribute : Attribute
    {
        public RequiredBombSettingAttribute(params string[] settings)
        {
            this.Settings = settings.ToList();
        }

        public List<string> Settings { get; private set; }
    }
}
