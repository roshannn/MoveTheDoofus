using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoSingleton;
namespace PlayerSystem
{
    public class PlayerSystem : MonoSingleton<PlayerSystem>
    {
        public PlayerFactory playerFactory;
        PlayerController playerController;

        protected override void Awake()
        {
            base.Awake();
        }
        private void Start()
        {
            playerController = new PlayerController();

        }
    }
}
