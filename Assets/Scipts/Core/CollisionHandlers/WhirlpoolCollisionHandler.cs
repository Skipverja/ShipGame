
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scipts.Core
{
    public class WhirlpoolCollisionHandler : MonoBehaviour
    {
        public const float GravityModifier = 10f;
        public Transform poolTransform = null;
        public void HandleCollision(Collider other)
        {
            var poolTransform = this.GetComponent<Transform>();
            var colliderRigidBody = other.GetComponent<PhysicsLink>();
            
            var vectorBetween2Objects = poolTransform.position - colliderRigidBody.transform.position;
            

            var angle = Vector3.Angle(colliderRigidBody.transform.forward, vectorBetween2Objects);
            var clockModifier = angle > 90f ? 1f : -1f;
            var velocity = colliderRigidBody.Velocity.magnitude;
            var direction = vectorBetween2Objects.normalized;
            var power =  GravityModifier / vectorBetween2Objects.magnitude;

           
            // colliderRigidBody.AddForce(-direction * power / 10f);
             colliderRigidBody.transform.Rotate(0f,isClock[other] ? 1f : -1f ,0f);
            
        }

        public List<Collider> colliders;
        public Dictionary<Collider, bool> isClock;
    
        public void Start(){
            colliders = new List<Collider>();
            poolTransform = this.GetComponent<Transform>();
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

         private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.EntityTag)){
                
                var colliderRigidBody = other.GetComponent<PhysicsLink>();
                var vectorBetween2Objects = poolTransform.position - colliderRigidBody.transform.position;
                var angle = Vector3.Angle(colliderRigidBody.transform.forward, vectorBetween2Objects);
                var clockModifier = angle > 90f;
                colliders.Add(other);
                isClock.Add(other, clockModifier );
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