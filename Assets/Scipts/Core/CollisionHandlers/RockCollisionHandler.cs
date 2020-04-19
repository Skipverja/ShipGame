
using System.Collections.Generic;
using UnityEngine;

namespace Scipts.Core
{
    public class RockCollisionHandler : IslandCollisionHandler
    {
        public override void HandleCollision(Collider other)
        {
            var shipRigidbody = other.GetComponent<Rigidbody>();
            var transform = other.GetComponent<Transform>();
            shipRigidbody.AddForce(3f * transform.forward);
        }
    }
}