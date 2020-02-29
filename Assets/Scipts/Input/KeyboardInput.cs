using Mirror;
using UnityEngine;

namespace Scipts.Input
{
    public class KeyboardInput : NetworkBehaviour, IPlayerInput
    {
        public void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }
            
            if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                Rotation = -1f;
            }
            else if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                Rotation = 1f;
            }
            else
            {
                Rotation = 0f;
            }

            Shooting = UnityEngine.Input.GetKey(KeyCode.Space);

            Acceleration = UnityEngine.Input.GetKey(KeyCode.W) ? 1f : 0f;
            if (AllowBackwardMovement){
                Acceleration = UnityEngine.Input.GetKey(KeyCode.S) ? -0.8f : Acceleration;
            }
        }

        public bool AllowBackwardMovement {get; set;} = true;
        public float Rotation { get; set; }
        public float Acceleration { get; set; }
        public bool Shooting { get; private set; }
    }
}