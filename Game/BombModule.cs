namespace KTANE.Game
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using KTANE.Brain;

    internal abstract class BombModule : SpeechProcessor
    {
        public abstract string PreInfo { get; }

        public bool TryDefuse(Bomb bomb, out string response)
        {
            response = null;

            if (this.GetType()
                    .GetMethod(nameof(this.Process))
                    .GetCustomAttribute(typeof(RequiredBombSettingAttribute), true) is RequiredBombSettingAttribute attr)
            {
                List<string> missing = typeof(Bomb).GetProperties()
                    .Where(p => attr.Settings.Contains(p.Name)
                        && p.GetValue(bomb) == null)
                    .Select(p => (p.GetCustomAttribute(typeof(DisplayNameAttribute), false) as DisplayNameAttribute).DisplayName)
                    .ToList();

                if (missing.Count > 0)
                {
                    response = $"Set {string.Join(", ", missing)}!";
                }
            }

            return response == null;
        }
    }
}