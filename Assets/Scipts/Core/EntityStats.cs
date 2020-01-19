using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public void Start()
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (health == default)
        {
            health = maxHealth;
        }
    }

    [Min(0f)]
    public float health;

    [Min(0.1f)]
    public float maxHealth = 100f;

    public bool hittable = true;

    public void Hit(float relativeVelocityMagnitude)
    {
        if(!hittable) return;
        
        health -= relativeVelocityMagnitude;
    }
}