using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour
{

    public Quaternion Rotation {get; set;}
    

    // Start is called before the first frame update
    void Start()
    {
        Rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Rotation;
        
    }
}
