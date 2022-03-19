using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlayerSystem
{
    public class PlayerModel
    {
        private PlayerController playerController;

        public float PlayerSpeed;

        public float score;

        public PlayerModel(PlayerData playerData)
        {
            PlayerSpeed = playerData.Speed;
        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }
    }
}
