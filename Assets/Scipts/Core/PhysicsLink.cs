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
        if (GetComponent<NetworkIdentity>().isServer)
        {
            Velocity = rb.velocity;
            AngularVelocity = rb.angularVelocity;
        }

        if (GetComponent<NetworkIdentity>().isClient)
        {
            rb.velocity = Velocity;
            rb.angularVelocity = AngularVelocity;
        }
    }

    public void AddForce(Vector3 force)
    {
        if (!(isClient && isServer))
        {
            rb.AddForce(force);
        }

        CmdAddForce(force);
    }

    [Command]
    public void CmdAddForce(Vector3 force)
    {
        rb.AddForce(force);
    }
}