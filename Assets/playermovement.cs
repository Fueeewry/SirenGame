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
    public GameObject[] enemytype;
    public Slider healthbar, expbar;
    public TMP_Text exptext;
    public weaponsystem weaponsys;
    public int level = 1;

    void Start(){
        InvokeRepeating("SpawnEnemy", 1, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxisRaw("Vertical");
        if(movX!=0||movY!=0){
            rb.velocity = new Vector2(movX, movY) * speed;
        }else{
            rb.velocity = new Vector2(0,0);
        }
    }


    void SpawnEnemy(){
        for(int i = 0; i < 3; i++){
            int x = Random.Range(-4,4);
            int y = Random.Range(0,2);
            if(y == 0){
                Instantiate(enemytype[Random.Range(0, enemytype.Length)], transform.position + new Vector3(x, -20), Quaternion.Euler(0,0,0));
            }else if(y == 1){
                Instantiate(enemytype[Random.Range(0, enemytype.Length)], transform.position + new Vector3(x, 20), Quaternion.Euler(0,0,0));
            }
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
            expbar.maxValue += 1000;
            expbar.value = 0;
        }
    }

    public void addSkill(string functionName, float cooldown){
        weaponsys.addFunction(functionName, cooldown);
        weaponsys.resetSkill();
    }
}
