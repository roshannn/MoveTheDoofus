using Newtonsoft.Json;
using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PulpitSystem;

namespace GameSystem
{
    public class GameData
    {
        [JsonProperty("player_data")]
        public PlayerData playerData { get; set; }

        [JsonProperty("pulpit_data")]
        public PulpitData pulpitData { get; set; }

        public GameData()
        {
            playerData = new PlayerData();
            pulpitData = new PulpitData();
        }
    }
}
