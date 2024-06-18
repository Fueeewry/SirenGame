using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorlogic : MonoBehaviour
{
    public float speed = 1;
    public LineRenderer liner;
    Transform player, head;
    public Transform ropepoint;
    WaitForSeconds t;
    bool canlook = false;
    void Start(){
        player = GameObject.Find("Player").transform;
        head = GameObject.Find("Head").transform;
        t = new WaitForSeconds(0.02f);
        Destroy(this.gameObject, 15);
        StartCoroutine(anim());
    }
    void FixedUpdate(){
        liner.SetPosition(0, player.position);
        liner.SetPosition(1, ropepoint.position);
    }
    IEnumerator anim(){
        float a = GameObject.Find("Head").transform.eulerAngles.z - 90;
        transform.eulerAngles = new Vector3(0,0, a);
        for(float i = 0 ; i < 4 * speed ; i += 0.1f){
            transform.eulerAngles += new Vector3(0, 0, 17.5f * speed);
            yield return t;
        }
        transform.parent = null;
        for(float i = 0 ; i < 2.5f ; i += 0.1f){
            transform.Translate(Vector2.up * 0.25f * (2.5f - i) * speed);
            yield return t;
        }
        canlook = true;
        yield return new WaitForSeconds(2f);
        Vector3 originalPosition = transform.position;
        var dir = (player.position - transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward * 0.1f);
        for(float i = 0 ; i < 1 ; i += 0.05f){
            transform.position = player.position * i + originalPosition * (1f - i);
            yield return t;
        }
        StartCoroutine(die());
    }
    IEnumerator die(){
        for(float i = 1 ; i > 0 ; i -= 0.05f){
            transform.localScale = new Vector3(i,i,i);
            yield return t;
        }
        Destroy(this.gameObject);
    }

}
