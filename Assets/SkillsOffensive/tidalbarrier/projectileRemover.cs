using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileRemover : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "enemyprojectile"){
            Destroy(collision.gameObject);
        }
    }
}
