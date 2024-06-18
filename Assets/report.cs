using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class report : MonoBehaviour
{
    public List<levelcontroller> levellist = new List<levelcontroller>();

    public bool canspawn(int x, int y){
        foreach(levelcontroller a in levellist){
            if(a.x == x && a.y == y){
                return false;
            }
        }
        return true;
    }
}
