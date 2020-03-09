using System.Collections.Generic;
using Scipts.Core.Ships;
using UnityEngine;

namespace Scipts.Core
{
    public class ShallowWaterCollisionHandler : MonoBehaviour
    {
        private List<Collider> colliders;
        public void Start(){
            colliders = new List<Collider>();
        }

        public void FixedUpdate(){
            colliders.ForEach(
                (collider) => {
                    var shipRigidbody = collider.GetComponent<PhysicsLink>();
                    var transform = collider.GetComponent<Transform>();
                    shipRigidbody.AddForce(-shipRigidbody.Velocity.magnitude * transform.forward);
                }
            );
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.EntityTag)){
                colliders.Add(other);
            }   
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Tags.EntityTag)){
                colliders.Remove(other);
            }

        }
    }
}