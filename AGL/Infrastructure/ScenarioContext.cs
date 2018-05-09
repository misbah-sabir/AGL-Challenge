using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGL.Infrastructure
{
    class ScenarioContext
    {

        public static TechTalk.SpecFlow.ScenarioContext Current
        {
            get
            {
                return TechTalk.SpecFlow.ScenarioContext.Current;
            }
        }

        public static void SetKeyValue(string key, string value)
        {
            Current[key] = value;
        }

        public static string GetKeyValue(string key)
        {
            return Current.Keys.Contains(key) ? Current[key].ToString() : null;
        }

    }
}
