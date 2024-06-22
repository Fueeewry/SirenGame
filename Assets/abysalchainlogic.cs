using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abysalchainlogic : MonoBehaviour
{
    List<GameObject> chainedEnemies = new List<GameObject>();
    public int damage = 1;
    public GameObject chain;

    public Collider2D col;

    void Start(){
        Destroy(this.gameObject, 3);
        StartCoroutine(dot());
    }

    public int chaincount = 3;
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "enemy" && chaincount > 0){
            IDamageable a = collision.gameObject.GetComponent<IDamageable>();
            if(a!=null){
                a.reducedby();
                a.vulnerable(1.5f);
                chainedEnemies.Add(collision.gameObject);
                Instantiate(chain, collision.gameObject.transform);
                chaincount--;
            }
        }
    }

    IEnumerator dot(){
        yield return new WaitForSeconds(0.5f);
        col.enabled = false;
        for(int i = 0; i<5; i++){
            dotDamage();
            yield return new WaitForSeconds(0.2f);
        }
        foreach(GameObject a in chainedEnemies){
            IDamageable b = a.GetComponent<IDamageable>();
            if(b!=null){
                b.restorespeed();
            }
        }
    }

    public void dotDamage(){
        chainedEnemies.RemoveAll(item => item == null);
        foreach(GameObject a in chainedEnemies){
            IDamageable b = a.GetComponent<IDamageable>();
            if(b!=null){
                b.damaged(damage);
            }
        }
    }
}
