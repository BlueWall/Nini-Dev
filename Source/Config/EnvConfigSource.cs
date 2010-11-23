
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Nini.Util;
using Nini.Env;

namespace Nini.Config
{
    // This needs to use the events to make changes to the shell environment
    // if a key-pair changes in the EnvConfig occurs
    //
    // This class knows how to load and save the environment variables. It is our
    // "document". This is the system facing side of our implementation that will
    
    //
    public class EnvConfigSource : ConfigSourceBase
    {
        #region private variables
        EnvMap envmap = EnvMap.Instance;
        bool caseSensitive = true;
        #endregion

        #region constructors
        // We will need to create an EnvMap and populate it with the
        // keys to the environmant variable we are interested in using
        //
        // Then it will load them, or set a default
        //
        public EnvConfigSource()
        {
			
        }
        public EnvConfigSource(string[] envars)
        {

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
        // This started as a clone of the ArgvConfig family.
        // But not sure if it fits for this.
        // The Environment is dynamic and needs to be synchronized
        // between all the elements, each item, the config source
        // and the actual shell environment values.
        //
        // TODO: This needs sorting out - is it a section or an item?
        //
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
        //
        // Make a loader to get each value we are interested in
        // and look in the shell for the value, then create a
        // config item in our config source to match it's value.
        // If no shell item is found, then we create our item with
        // a default value (if supplied) and synchronize our list
        // of config items with the shell environment.
        //
        #endregion
    }
}