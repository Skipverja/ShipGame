using UnityEngine;

namespace Scipts.Core
{
    public class EntityCollisionHandler : MonoBehaviour
    {
        public EntityStats entityStats;
    
        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.CompareTag(Tags.EntityTag) && !other.collider.CompareTag(Tags.BulletTag)) return;

            entityStats.Hit(other.relativeVelocity.magnitude);
        }
    }
}