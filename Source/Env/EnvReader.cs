using System;



namespace Nini.Env
{
    // Read single environment variables form the shell
    //
    public class EnvReader {

        public string Get(string key, string defaultValue)
        {
            string val = Environment.GetEnvironmentVariable(key);
            if(val == null)
            {
                EnvWriter writer = new EnvWriter();
                writer.Set(key, defaultValue);
                return defaultValue;
            }
            return val;
        }
    }
}
