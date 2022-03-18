using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;
using GameSystem;

namespace PlayerSystem
{
    public class PlayerController
    {
        public PlayerView playerView;
        private PlayerModel playerModel;

        public Vector3 movementVector;

        public PlayerController()
        {
            playerView = PlayerSystem.Instance.playerFactory.GetNewInstance();
            playerView.SetController(this);
            playerModel = new PlayerModel(GameManager.Instance.GameData.playerData);
            playerModel.SetPlayerController(this);
            movementVector = new Vector3();
        }

        public void SetMovementVector(float setX, float setY, float setZ)
        {
            movementVector.Set(setX, 0, setZ);
        }


        public Vector3 GetMovementVector()
        {
            return movementVector;
        }

        public void MovePlayer(Vector3 move)
        {
            if (Mathf.Abs(movementVector.x) > 0 || Mathf.Abs(movementVector.z) > 0)
            {
                playerView.transform.Translate(move * playerModel.PlayerSpeed * Time.deltaTime);
            }
        }
    }
}

