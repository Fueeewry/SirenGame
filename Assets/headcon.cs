using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headcon : MonoBehaviour
{
    public detection det;
    void FixedUpdate(){
        if(det.targeted != null){
            var dir = det.targeted.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward * 1);
        }
    }
}
