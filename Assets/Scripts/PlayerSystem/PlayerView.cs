using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;
using System;

namespace PlayerSystem
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;
        
        void Update()
        {
            playerController.SetMovementVector(InputManager.Instance.horizontal, 0, InputManager.Instance.vertical);
            playerController.MovePlayer(playerController.movementVector);
        }

        #region SetControllerMethod
        public void SetController(PlayerController _playerController)
        {
            playerController = _playerController;
        } 
        #endregion
    }
}