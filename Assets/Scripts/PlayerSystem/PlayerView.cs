using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;
using System;
using PulpitSystem;

namespace PlayerSystem
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;
        public LayerMask pulpitLayerMask;



        void Update()
        {
            playerController.SetMovementVector(InputManager.Instance.horizontal, 0, InputManager.Instance.vertical);
            playerController.MovePlayer(playerController.movementVector);
        }

        private void FixedUpdate()
        {
            playerController.ScoreUpdate();
        }
        
        #region SetControllerMethod
        public void SetController(PlayerController _playerController)
        {
            playerController = _playerController;
        } 
        #endregion
    }
}