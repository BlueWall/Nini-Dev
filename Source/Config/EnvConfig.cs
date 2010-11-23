using System;

namespace Nini.Config
{
    public class EnvConfig : ConfigBase
    {
        #region Private variables
        EnvConfigSource parent = null;
        #endregion
        #region constructors
        public EnvConfig(string name, IConfigSource source)
            :base(name, source)
        {
            parent = (EnvConfigSource)source;
        }
        #endregion
        #region public methods
        // The base class contains other methods like Get(string, string), so a
        // default value can be passed to the class, if we have one
        //
        public override string Get (string key)
        {
            if (!parent.CaseSensitive) {
                key = CaseInsensitiveKeyName (key);
            }

            return base.Get (key);
        }

        public override void Set (string key, object value)
        {
            if (!parent.CaseSensitive) {
                key = CaseInsensitiveKeyName (key);
            }

            base.Set (key, value);
        }
        #endregion
        #region Private methods
        /// <summary>
        /// Returns the key name if the case insensitivity is turned on.  
        /// </summary>
        private string CaseInsensitiveKeyName (string key)
        {
            string result = null;

            string lowerKey = key.ToLower ();
            foreach (string currentKey in keys.Keys)
            {
                if (currentKey.ToLower () == lowerKey) {
                    result = currentKey;
                    break;
                }
            }

            return (result == null) ? key : result;
        }
        #endregion
    }
}

