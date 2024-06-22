using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierlogic : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float dietimer = 3;

    void Start()
    {
        Destroy(this.gameObject, dietimer);
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
    }
}
