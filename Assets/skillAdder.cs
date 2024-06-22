using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillAdder : MonoBehaviour
{
    // Update is called once per frame
    public List<GameObject> availableskill = new List<GameObject>();
    public List<GameObject> instantiated = new List<GameObject>();
    void OnEnable()
    {
        StartCoroutine(spawnSkills());
    }
    void OnDisable(){
        foreach(GameObject a in instantiated){
            Destroy(a);
        }
        instantiated.Clear();
    }

    List<GameObject> instantiatedObject = new List<GameObject>();

    IEnumerator spawnSkills(){
        instantiatedObject = new List<GameObject>(availableskill);
        for(int i = 0;i < 3;i++){
            GameObject a = instantiatedObject[Random.Range(0,instantiatedObject.Count)];
            instantiatedObject.Remove(a);
            instantiated.Add(Instantiate(a, transform));
            Debug.Log("testssss");
            yield return new WaitForSeconds(0.2f);
        }
        Time.timeScale = 0;
    }
}
