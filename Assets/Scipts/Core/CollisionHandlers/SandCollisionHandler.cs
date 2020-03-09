using System.Collections.Generic;
using UnityEngine;

namespace Scipts.Core
{
    public class SandCollisionHandler : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            var es = other.GetComponent<EntityStats>();
            es.isFreezed = true;
            
        }

        private void OnTriggerExit(Collider other)
        {
            var es = other.GetComponent<EntityStats>();
            es.isFreezed = false;
        }
    }
}