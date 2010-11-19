
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Nini.Util;
using Nini.Env;

namespace Nini.Config
{
    public class EnvConfigSource : ConfigSourceBase
    {
        #region private variables
        EnvMap envmap = EnvMap.Instance;
        bool caseSensitive = true;
        #endregion

        #region constructors
        public EnvConfigSource() {
			
        }
        public EnvConfigSource(string[] envars) {

        }
        #endregion

        #region public properties
        #endregion

        #region public methods
        // Can use this to set environment variables in the shell
        // See how this works!
        // If it just save to the source, it is good
        // If it wants to save everything, not so good
        // In that case, a special method will be made for that
        public override void Save() {


        }
		/// <summary>
		/// The case sensitive flag
		/// </summary>
        public bool CaseSensitive
        {
            get { return caseSensitive; }
            set { caseSensitive = value; }
        }

        #endregion
        #region private methods
        IConfig GetConfig(string name) {
            IConfig result = null;

            if (this.Configs[name] == null) {
                result = new ConfigBase (name, this);
                this.Configs.Add (result);
            } else {
                result = this.Configs[name];
            }

            return result;
        }
        #endregion
    }
}