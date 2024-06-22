using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class playermovement : MonoBehaviour
{
    public float speed;
    float movX,movY;
    public Rigidbody2D rb;
    public Transform head;
    public GameObject lvlupgrade;
    public GameObject[] enemytype;
    public Slider healthbar, expbar;
    public TMP_Text exptext, timertxt;
    public weaponsystem weaponsys;
    public int level = 1, TIMENEEDED = 180;

    public void reducedby(){}
    public void restorespeed(){}
    public void vulnerable(){}
    public void restorevulnerable(){}

    void Start(){
        InvokeRepeating("SpawnEnemy", 1, 5);
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        if(movX!=0&&movY!=0){
            rb.velocity = new Vector2(movX, movY) * speed / 1.5f;
        }else if(movX!=0||movY!=0){
            rb.velocity = new Vector2(movX, movY) * speed;
        }else{
            rb.velocity = new Vector2(0,0);
        }
    }

    public void damaged(int damage){
        healthbar.value -= damage;
    }

    void OnParticleCollision(GameObject other){
        expbar.value += 100;
        if(expbar.value == expbar.maxValue){
            level++;
            exptext.text = level.ToString();
            lvlupgrade.SetActive(true);
            expbar.value = 0;
            expbar.maxValue += 1000;
        }
    }

    public void addSkill(string functionName, float cooldown){
        Time.timeScale = 1;
        weaponsys.addFunction(functionName, cooldown);
        weaponsys.resetSkill();
    }

    IEnumerator timer(){
        int seconds = 0, seconds1 = 0;
        int minutes = 0, minutes1 = 0;

        for(int i = 0; i < TIMENEEDED; i++){
            yield return new WaitForSeconds(1);
            seconds++;
            if(seconds > 9){
                seconds1++;
                seconds=0;
            }
            if(seconds1>5){
                seconds1=0;
                seconds=0;
                minutes++;
            }
            if(minutes>9){
                minutes = 0;
                minutes1++;
            }
            timertxt.text = minutes1.ToString() + minutes.ToString() + ":"+ seconds1.ToString() + seconds.ToString();
        }
    }

    void SpawnEnemy(){
        for(int i = 0; i < 6; i++){
            int x = Random.Range(-4,4);
            int y = Random.Range(0,2);
            if(y == 0){
                Instantiate(enemytype[Random.Range(0, enemytype.Length)], transform.position + new Vector3(x, -18), Quaternion.Euler(0,0,0));
            }else if(y == 1){
                Instantiate(enemytype[Random.Range(0, enemytype.Length)], transform.position + new Vector3(x, 18), Quaternion.Euler(0,0,0));
            }
        }
    }

}
