﻿
using System.Collections.Generic;
using UnityEngine;

namespace Scipts.Core
{
    public class RockCollisionHandler : MonoBehaviour
    {
        
        public List<Collider> colliders;
        public void Start(){
            colliders = new List<Collider>();
        }

        public void FixedUpdate(){
            colliders.ForEach(
                (collider) => {
                    // TODO remove exited colliders
                    if (collider == null) return;
                    var shipRigidbody = collider.GetComponent<PhysicsLink>();
                    var transform = collider.GetComponent<Transform>();
                    shipRigidbody.AddForce(3f * transform.forward);
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