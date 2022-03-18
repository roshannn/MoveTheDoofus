using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionSystem
{
    public Direction GetRandomDirection()
    {
        int Random = UnityEngine.Random.Range(0, Enum.GetValues(typeof(Direction)).Length);
        return (Direction)Random;
    }
    
}


public enum Direction { North,South,East,West}