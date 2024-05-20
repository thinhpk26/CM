using System.Reflection;
using System.Resources;
using Utility.Resource;

namespace Repo.Entities
{
    public class MethodBase
    {
        public string GetResource(string key)
        {
            ResourceManager rm = new ResourceManager("Utility.Resource.DatabaseUS", typeof(DatabaseUS).Assembly);
            return rm.GetString(key);
        }
    }
}
