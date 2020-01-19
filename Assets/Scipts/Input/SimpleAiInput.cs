using System;
using Scipts.Input;
using UnityEngine;

public class SimpleAiInput : MonoBehaviour, IPlayerInput
{
    public float rotation = 0f;
    
    public float acceleration = 0f;

    public float Rotation
    {
        get => rotation;
        set => rotation = value;
    }

    public float Acceleration
    {
        get => acceleration;
        set => acceleration = value;
    }
}
