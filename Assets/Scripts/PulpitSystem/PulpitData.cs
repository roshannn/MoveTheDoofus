using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PulpitSystem
{
    [System.Serializable]
    public class PulpitData
    {
        [JsonProperty("min_pulpit_destroy_time")]

        public float MinPulpitDestroyTime { get; set; }
        [JsonProperty("max_pulpit_destroy_time")]

        public float MaxPulpitDestroyTime { get; set; }
        [JsonProperty("pulpit_spawn_time")]
        public float PulpitSpawnTime { get; set; }
    }
}
