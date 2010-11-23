using System;

namespace Nini.Env
{
    public class EnvWriter
    {
        // Set environment variables in the shell
        public EnvWriter()
        {
        }
        /// <summary>
        /// Set key:value pair to shell environment
        /// </summary>
        /// <param name="key">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="val">
        /// A <see cref="System.String"/>
        /// </param>
        public void Set(string key, string val)
        {
            Environment.SetEnvironmentVariable(key, val);
        }

    }
}