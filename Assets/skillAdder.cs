using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillAdder : MonoBehaviour
{
    public GameObject[] availableskill;

    // Update is called once per frame
    List<GameObject> instantiatedObject = new List<GameObject>();
    void OnEnable()
    {
        for(int i = 0;i < 3;i++){
            instantiatedObject.Add(Instantiate(availableskill[Random.Range(0,availableskill.Length)], transform));
        }
    }
    void OnDisable(){
        foreach(GameObject a in instantiatedObject){
            Destroy(a);
        }
        instantiatedObject.RemoveAll(item => item == null);
    }
}
