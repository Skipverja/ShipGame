using System.Collections.Generic;
using Scipts.Core.Ships;
using UnityEngine;

namespace Scipts.Core
{
    public class SandCollisionHandler : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            var shipMovement = other.GetComponent<ShipMovement>();
            if (shipMovement != null){
                shipMovement.isFreezed = true;
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            var shipMovement = other.GetComponent<ShipMovement>();
            if (shipMovement != null){
                shipMovement.isFreezed = false;
            }
        }
    }
}