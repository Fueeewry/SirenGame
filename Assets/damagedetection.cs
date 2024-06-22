using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class damagedetection : MonoBehaviour
{
    public int damage = 2;
    public int pierce = 1;
    public float dietimer = 3;
    public string spriteName;
    public SpriteAtlas atlas;
    public bool canknockback = false;
    public float knockback = 2;
    void Start()
    {
        SpriteRenderer a = GetComponent<SpriteRenderer>();
        if(a != null && spriteName.Length > 0){
            a.sprite = atlas.GetSprite(spriteName);
        }
        Destroy(this.gameObject, dietimer);
    }
    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("test");
        if(collision.gameObject.tag == "enemy"){
            IDamageable a = collision.gameObject.GetComponent<IDamageable>();
            if(a!=null){
                a.damaged(damage);
                if(canknockback){
                    StartCoroutine(knockbacked(collision.gameObject.transform));
                }
                pierce--;
            }
            if(pierce==0){
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator knockbacked(Transform a){
        Vector3 dir = -(transform.position - a.position).normalized;
        Vector3 des = a.position + dir;
        for(float i = 1; i < knockback + 1; i += 0.2f){
            a.position = des * i;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
