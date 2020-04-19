using System.Collections.Generic;
using Scipts.Core.Ships;
using UnityEngine;

namespace Scipts.Core
{
    public class ShallowWaterCollisionHandler : IslandCollisionHandler
    {
        public override void HandleCollision(Collider other)
        {
            var shipRigidbody = other.GetComponent<Rigidbody>();
            var transform = other.GetComponent<Transform>();
            shipRigidbody.AddForce(-shipRigidbody.velocity.magnitude * transform.forward);
        }
    }
}