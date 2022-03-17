using UnityEngine;
using MonoSingleton;
using System.IO;
using Newtonsoft.Json;

namespace GameSystem
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public GameData GameData;
        protected override void Awake()
        {
            base.Awake();
            ParseGameData();
        }

        private void ParseGameData()
        {
            string path = Application.dataPath + "/Data/doofus_diary.json";
            GameData = new GameData();
            StreamReader streamReader = File.OpenText(path);
            string json = streamReader.ReadToEnd();
            GameData = JsonConvert.DeserializeObject<GameData>(json);
        }
    }



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