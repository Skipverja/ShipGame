using Scipts.Input;
using UnityEngine;

public class KeyboardInput : MonoBehaviour, IPlayerInput
{
    public void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rotation = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotation = 1f;
        }
        else
        {
            Rotation = 0f;
        }

        Acceleration = Input.GetKey(KeyCode.W) ? 1f : 0f;
    }

    public float Rotation { get; set; }
    public float Acceleration { get; set; }
}