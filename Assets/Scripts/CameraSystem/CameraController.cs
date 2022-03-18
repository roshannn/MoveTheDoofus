using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraSystem
{

    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;

        private void LateUpdate()
        {
            this.gameObject.transform.position = PlayerSystem.PlayerSystem.Instance.playerController.playerView.transform.position + offset;
        }
    } 
}
