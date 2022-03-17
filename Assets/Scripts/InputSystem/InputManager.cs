using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoSingleton;

namespace InputSystem
{
    public class InputManager : MonoSingleton<InputManager>
    {
        public float horizontal;
        public float vertical;

        private void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }


    }
}

