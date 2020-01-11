using System;
using Scipts.Input;
using UnityEngine;

namespace Scipts
{
    [RequireComponent (typeof(IPlayerInput))] 
    [RequireComponent (typeof(Rigidbody))]
    public class ShipMovement : MonoBehaviour
    {
        private IPlayerInput playerInput;

        public void Start()
        {
            playerInput = GetComponent<IPlayerInput>();
        }

        public void Update()
        {
        }
    }
}