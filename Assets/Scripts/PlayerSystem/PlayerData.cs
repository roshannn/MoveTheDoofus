using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerSystem
{
    public class PlayerData
    {
        [JsonProperty("speed")]
        public float Speed { get; set; }
    }
}
