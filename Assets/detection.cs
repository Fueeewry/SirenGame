using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour
{
    public Transform targeted;
    List<Transform> enemylist = new List<Transform>();
    void Start(){
        InvokeRepeating("checkclosest",0.5f, 1);
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "enemy"){
            enemylist.Add(collision.gameObject.transform);
        }
    }
    void checkclosest(){
        enemylist.RemoveAll(item => item == null);
        float dis, shortestdis = 30;
        Transform targetclosest = null;
        foreach (Transform a in enemylist){
            dis = Vector3.Distance(transform.position, a.position);
            if(dis < shortestdis){
                targetclosest = a;
                shortestdis = dis;
            }
        }
        targeted = targetclosest;
    }
}
