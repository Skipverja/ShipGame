
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

        public override void HandleCollision(Collider other)
        {
            var poolTransform = this.GetComponent<Transform>();
            var colliderRigidBody = other.GetComponent<Rigidbody>();

            var poolPosition = poolTransform.position;
            var colliderPosition = colliderRigidBody.transform.position;
            var vectorBetween2Objects = poolPosition - colliderPosition;

            var rotationForceVector = CalculateRotationForceVector(poolPosition, colliderPosition);
            var rotationAngle = CalculateRotationAngle(rotationForceVector, colliderRigidBody);

            colliderRigidBody.AddForce(rotationForceVector * vectorBetween2Objects.magnitude * RotatePower);
            colliderRigidBody.AddForce(vectorBetween2Objects * GrabbingPower);
            colliderRigidBody.transform.Rotate(0f, rotationAngle * RotationCoefficient, 0f);
        }

        private Vector3 CalculateRotationForceVector(Vector3 poolPosition, Vector3 colliderPosition)
        {
            var vectorBetween2Objects = poolPosition - colliderPosition;
            var distance = vectorBetween2Objects.magnitude;

            var nx = -vectorBetween2Objects.z * RotatePower / distance;
            var sign = Math.Sign(poolPosition.x - colliderPosition.x);
            var ny = sign * Mathf.Sqrt(RotatePower * RotatePower - nx * nx);
            return new Vector3(nx, 0f, ny);
        }
        private float CalculateRotationAngle(Vector3 rotationForceVector, Rigidbody colliderRigidBody)
        {
            var colliderForwardVector = colliderRigidBody.transform.forward;
            var straightAngle = Vector3.Angle(rotationForceVector, colliderForwardVector);
            var oppositeAngle = Vector3.Angle(rotationForceVector, -colliderForwardVector);
            return Mathf.Min(oppositeAngle, straightAngle);
        }

    }
}