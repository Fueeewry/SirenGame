using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagedetection : MonoBehaviour
{
    public int damage = 2;
    public int pierce = 1;
    public float dietimer = 3;
    void Start()
    {
        Destroy(this.gameObject, dietimer);
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "enemy"){
            IDamageable a = collision.gameObject.GetComponent<IDamageable>();
            if(a!=null){
                a.damaged(damage);
                pierce--;
            }
            if(pierce==0){
                Destroy(this.gameObject);
            }
        }
    }
}
