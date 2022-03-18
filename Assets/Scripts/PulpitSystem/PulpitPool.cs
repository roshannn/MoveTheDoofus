using GenericPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PulpitSystem
{
    public class PulpitPool : GenericPool<PulpitController>
    {
        protected override void Awake()
        {
            base.Awake();
        }
    } 
 }
