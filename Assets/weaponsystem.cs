using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill
{
    public string skillFunctionName;
    public float skillCooldown;
    public int skillLevel;
    public skill(string skillFunctionName, float skillCooldown, int skillLevel){
        this.skillFunctionName = skillFunctionName;
        this.skillCooldown = skillCooldown;
        this.skillLevel = skillLevel;
    }
    public int getidx(){
        int a = 0;
        switch(skillFunctionName){
            case "shootanchor":
                a = 0;
                break;
            case "shootfireball":
                a = 1;
                break;
        }
        return a;
    }
}

public class weaponsystem : MonoBehaviour
{
    public int skillcount = 2;
    public GameObject[] anchors, fireballs;
    List<skill> skillList = new List<skill>();
    public Transform head;

    int[] skillsLevels;

    void Start(){
        skillsLevels = new int[6];
    }

    public void addFunction(string a, float b){
        foreach(skill s in skillList){
            if(s.skillFunctionName.Equals(a)){
                s.skillLevel++;
                return;
            }
        }
        skillList.Add(new skill(a,b,0));
    }

    public void resetSkill(){
        CancelInvoke();
        for(int i = 0; i<skillList.Count;i++){  
            skillsLevels[skillList[i].getidx()] = skillList[i].skillLevel;
            InvokeRepeating(skillList[i].skillFunctionName, 0.1f, skillList[i].skillCooldown);
        }
    }

    //=========================================================================================================//

    void shootanchor(){
        Instantiate(anchors[skillsLevels[0]], transform);
    }

    void shootfireball(){
        Instantiate(fireballs[skillsLevels[1]], transform.position, head.rotation);
        Instantiate(fireballs[skillsLevels[1]], transform.position, head.rotation * Quaternion.Euler(0,0,90));
        Instantiate(fireballs[skillsLevels[1]], transform.position, head.rotation * Quaternion.Euler(0,0,-90));
        Instantiate(fireballs[skillsLevels[1]], transform.position, head.rotation * Quaternion.Euler(0,0,180));
    }
}
