using UnityEngine;

namespace Scipts.Input
{
    public class GamePadInput : PlayerInput
    {
        public void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                Rotation = -1f;
            }
            else if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                Rotation = 1f;
            }
            else
            {
                Rotation = 0f;
            }
        
            Shooting = UnityEngine.Input.GetKey(KeyCode.Return);
        
            Acceleration = UnityEngine.Input.GetKey(KeyCode.UpArrow) ? 1f : 0f;
            if (AllowBackwardMovement)
            {
                Acceleration = UnityEngine.Input.GetKey(KeyCode.DownArrow) ? -0.8f : Acceleration;
            }
        }

        public bool AllowBackwardMovement { get; set; } = true;
    }
}