using Scipts.Input;
using UnityEngine;

public class GamePadInput : MonoBehaviour, IPlayerInput
{
    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotation = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotation = 1f;
        }
        else
        {
            Rotation = 0f;
        }

        Acceleration = Input.GetKey(KeyCode.UpArrow) ? 1f : 0f;
        if (AllowBackwardMovement)
        {
            Acceleration = Input.GetKey(KeyCode.DownArrow) ? -1f : Acceleration;
        }
    }

    public bool AllowBackwardMovement { get; set; } = true;

    public float Rotation { get; set; }

    public float Acceleration { get; set; }
}