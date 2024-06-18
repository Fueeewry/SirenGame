using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyscript : MonoBehaviour, IDamageable
{
    public int damage;
    public Slider healthbar;
    public GameObject spawnexp;
    Transform player;
    public Rigidbody2D rb;
    bool canatk = true;
    void Start(){
        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate(){
        var dir = (player.position - transform.position).normalized;
        if(Vector3.Distance(player.position, transform.position) > 2){
            rb.velocity = dir * 3;
        }else if(canatk == true){
            StartCoroutine(attack());
        }   
    }

    IEnumerator attack(){
        canatk = false;
        player.GetComponent<playermovement>().damaged(damage);
        yield return new WaitForSeconds(1);
        canatk = true;
    }

    public void damaged(int damage){
        healthbar.value-=damage;
        if(healthbar.value==0){
            die();
        }
    }

    public void die(){
        Instantiate(spawnexp, transform.position, Quaternion.Euler(0,0,0));
        Destroy(this.gameObject);
    }
}
