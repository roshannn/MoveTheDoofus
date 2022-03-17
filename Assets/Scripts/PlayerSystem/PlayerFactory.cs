using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbstractFactory;

namespace PlayerSystem
{
    public class PlayerFactory : AbstractFactory<PlayerView>
    {
        public override PlayerView GetNewInstance()
        {
            return base.GetNewInstance();
        }
    }
}
