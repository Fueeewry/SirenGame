using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightninglogic : MonoBehaviour
{
    public GameObject enemyGameObject;
    public int damage = 1;
    public int pierce = 2;
    bool hit = false;
    LineRenderer line;
    void Start(){
        line = GetComponent<LineRenderer>();
        Destroy(this.gameObject, 0.5f);
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "enemy" && hit == false && enemyGameObject!=collision.gameObject){
            hit = true;
            chain(collision.gameObject);
        }
    }

    void chain(GameObject b){
        IDamageable a = b.GetComponent<IDamageable>();
        if(a!=null){
            line.SetPosition(0, transform.position);
            line.SetPosition(1, b.transform.position);
            a.damaged(damage);
            pierce--;
            if(pierce > 0){
                Instantiate(this.gameObject, b.transform.position, Quaternion.Euler(0,0,0)).GetComponent<lightninglogic>().enemyGameObject = b;
            
            }
        }
    }
}
