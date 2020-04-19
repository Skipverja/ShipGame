
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scipts.Core
{
    public class WhirlpoolCollisionHandler : IslandCollisionHandler
    {
        public float RotatePower = 1f;
        public float GrabbingPower = 2.5f;

        public float RotationCoefficient = 0.02f;
        public Transform poolTransform = null;
        
        public override void Start(){
            base.Start();
            poolTransform = this.GetComponent<Transform>();
        }
        
        public override void HandleCollision(Collider other) {
            var poolTransform = this.GetComponent<Transform>();
            var colliderRigidBody = other.GetComponent<Rigidbody>();
            
            var poolPosition = poolTransform.position;
            var colliderVector = colliderRigidBody.transform.position;
            var vectorBetween2Objects = poolPosition - colliderVector;
            var distance = vectorBetween2Objects.magnitude;

            var nx = -vectorBetween2Objects.z * RotatePower / distance;
            var ny = Mathf.Sqrt(RotatePower * RotatePower - nx * nx) * Math.Sign(poolPosition.x - colliderVector.x);
            
            var forceVector = new Vector3(nx, 0f, ny);
           
            var straightAngle = Vector3.Angle(forceVector, colliderRigidBody.transform.forward);
            var oppositeAngle = Vector3.Angle(forceVector, -colliderRigidBody.transform.forward);
            var minAngle = Mathf.Min(oppositeAngle, straightAngle);

            colliderRigidBody.AddForce(forceVector * distance * RotatePower  );
            colliderRigidBody.AddForce(vectorBetween2Objects * GrabbingPower  );
    
            colliderRigidBody.transform.Rotate(0f, minAngle * RotationCoefficient, 0f );
        }
    }
}