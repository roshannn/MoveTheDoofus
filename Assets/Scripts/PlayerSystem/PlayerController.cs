using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;
using GameSystem;
using PulpitSystem;

namespace PlayerSystem
{
    public class PlayerController
    {
        public PlayerView playerView;
        private PlayerModel playerModel;

        public Vector3 movementVector;
        private RaycastHit raycastHit;
        public PulpitController prevPulpit = null;

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
        public async void ScoreUpdate()
        {
            if(GameManager.gameState == GameState.PlayState)
            {
                if (Physics.Raycast(playerView.transform.position, Vector3.down, out raycastHit, Mathf.Infinity, playerView.pulpitLayerMask))
                {
                    
                    PulpitController Pulpit = raycastHit.collider.gameObject.GetComponent<PulpitController>();
                    if (Pulpit != null)
                    {
                        if (prevPulpit != Pulpit)
                        {
                            PlayerSystem.OnPulpitChange?.Invoke();
                            prevPulpit = Pulpit;
                        }
                    }
                    else
                    {
                        Debug.Log("Cant find pulpit");
                    }
                }
                else
                {
                    if (prevPulpit != null)
                    {
                        GameManager.gameState = GameState.GameOver;
                        await System.Threading.Tasks.Task.Delay(500);
                        GameManager.GameOver?.Invoke();
                    }
                }
            }
        }
    }
}

