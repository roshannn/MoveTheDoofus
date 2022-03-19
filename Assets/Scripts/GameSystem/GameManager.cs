using UnityEngine;
using MonoSingleton;
using System.IO;
using System;
using Newtonsoft.Json;
using PulpitSystem;
using PlayerSystem;

namespace GameSystem
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public GameData GameData;
        public static GameState gameState;
        public static Action InitializeGame;
        public static Action GameOver;
        
        protected override void Awake()
        {
            base.Awake();
            ParseGameData();
            gameState = GameState.MainScreen;
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



    
}