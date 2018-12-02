using Newtonsoft.Json;

namespace DNet.Core
{
    public class AutoJsonSerialize
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
