using System.Collections.Generic;
using Newtonsoft.Json;

namespace A7MovieLibrary.Models
{
  [JsonObject(MemberSerialization.OptIn)]
    public class Movie

    {
        [JsonProperty]
        public int MovieId { get; set; }
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public string Genres { get; set; }
    }

}