using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoSingleton;
namespace PlayerSystem
{
    public class PlayerSystem : MonoSingleton<PlayerSystem>
    {
        public PlayerFactory playerFactory;
        public PlayerController playerController;

        protected override void Awake()
        {
            base.Awake();
        }
        private void OnEnable()
        {
            playerController = new PlayerController();

        }
    }
}
