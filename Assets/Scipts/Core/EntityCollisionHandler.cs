using Scipts.Core;
using UnityEngine;

public class EntityCollisionHandler : MonoBehaviour
{
    public EntityStats entityStats;
    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag(Tags.EntityTag)) return;

        entityStats.Hit(other.relativeVelocity.magnitude);
    }
}