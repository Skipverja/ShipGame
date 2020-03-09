using Mirror;
using UnityEngine;

public class EntityStats : NetworkBehaviour
{
    public void Start()
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (health == default)
        {
            health = maxHealth;
        }
    }

    [SyncVar] 
    private bool _isFreezed;
    public bool isFreezed
    {
        get { return _isFreezed; }
        set { _isFreezed = value; CmdChangeIsFreezed(value); }
    }
    
    [Command]
    public void CmdChangeIsFreezed(bool value){
        _isFreezed = value;
    }

    [Min(0f)] [SyncVar] public float health;

    [Min(0.1f)] public float maxHealth = 100f;

    public bool hittable = true;

    public void Hit(float power)
    {
        if (!hittable) return;

        health -= power;
    }
}