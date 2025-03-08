using System;
using Newtonsoft.Json;

namespace Code.Progress.Data
{
    public class ProgressData
    {
        [JsonProperty("e")] public EntityData EntityData = new();
        [JsonProperty("at")] public DateTime LastSimulationTickTime;
        
        [JsonProperty("so")] public bool Sound = true;
        [JsonProperty("mu")] public bool Music = true;
        [JsonProperty("vi")] public bool Vibration = true;
    }
}