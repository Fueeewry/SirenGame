using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tridentlogic : MonoBehaviour
{
    public float speed = 2;
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
