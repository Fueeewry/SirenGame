using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcontroller : MonoBehaviour
{
    public GameObject[] levelobject;
    public int x = 0, y = 0;
    report reportCon;
    GameObject a;
    levelcontroller b;
    public BoxCollider2D col;
    void Start(){
        reportCon = GameObject.Find("map").GetComponent<report>();
    }
    public void generateMap(){
        if(reportCon.canspawn(x,y + 1)){ //UP
            a = Instantiate(levelobject[Random.Range(0,levelobject.Length)], transform.position + new Vector3(0,60,0), Quaternion.Euler(0,0,0));
            b = a.GetComponent<levelcontroller>();
            b.x = x;
            b.y = y;
            b.y++;
            reportCon.levellist.Add(b);
            b.enablemap();
        }
        if(reportCon.canspawn(x,y - 1)){ //DOWN
            a = Instantiate(levelobject[Random.Range(0,levelobject.Length)], transform.position + new Vector3(0,-60,0), Quaternion.Euler(0,0,0));
            b = a.GetComponent<levelcontroller>();
            b.x = x;
            b.y = y;
            b.y--;
            reportCon.levellist.Add(b);
            b.enablemap();
        }
        if(reportCon.canspawn(x + 1,y)){ //RIGHT
            a = Instantiate(levelobject[Random.Range(0,levelobject.Length)], transform.position + new Vector3(60,0,0), Quaternion.Euler(0,0,0));
            b = a.GetComponent<levelcontroller>();
            b.x = x;
            b.y = y;
            b.x++;
            reportCon.levellist.Add(b);
            b.enablemap();
        }
        if(reportCon.canspawn(x - 1,y)){ //LEFT
            a = Instantiate(levelobject[Random.Range(0,levelobject.Length)], transform.position + new Vector3(-60,0,0), Quaternion.Euler(0,0,0));
            b = a.GetComponent<levelcontroller>();
            b.x = x;
            b.y = y;
            b.x--;
            reportCon.levellist.Add(b);
            b.enablemap();
        }
        this.enabled = false;
    }

    public void enablemap(){
        col.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "playerview"){
            generateMap();
        }
    }
}
