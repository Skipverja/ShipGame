
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scipts.Core
{
    public abstract class IslandCollisionHandler : MonoBehaviour
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
                    HandleCollision(collider);
                }
            );
        }

        public abstract void HandleCollision(Collider other);
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