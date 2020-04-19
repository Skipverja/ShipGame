using UnityEngine;
using Mirror;

public class PhysicsLink : NetworkBehaviour
{
    private Rigidbody rb;

    [SyncVar] public Vector3 Velocity;
    [SyncVar] public Vector3 AngularVelocity;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (isServer)
        {
            Velocity = rb.velocity;
            AngularVelocity = rb.angularVelocity;
        }

        if (isClient)
        {
            rb.velocity = Velocity;
            rb.angularVelocity = AngularVelocity;
        }
    }
}