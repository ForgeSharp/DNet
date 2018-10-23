using Newtonsoft.Json;

namespace DNet.Structures {
    public struct User {
        public string id{get;set;}
        public string username{get;set;}
        public string discriminator{get;set;}

        [JsonProperty("avatar")]
        public string avatarHash {get;set;}
    }
}