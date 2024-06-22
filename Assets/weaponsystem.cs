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
            case "shoottrident":
                a = 1;
                break;
            case "shootChainLightnings":
                a = 2;
                break;
            case "shootfireball":
                a = 3;
                break;
            case "shoottidalamulet":
                a = 4;
                break;
            case "shootabysalchain":
                a = 5;
                break;
            case "shootechoconch":
                a = 6;
                break;
        }
        return a;
    }
}

public class weaponsystem : MonoBehaviour
{
    public int skillcount = 2;
    public GameObject[] anchors, tridents, chainLightnings, fireballs, tidalamulets, abysalchains, echoconchs;
    List<skill> skillList = new List<skill>();
    public Transform head;

    int[] skillsLevels;

    void Start(){
        skillsLevels = new int[20];
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

    void shoottrident(){
        Instantiate(tridents[skillsLevels[1]], transform.position, head.rotation);
    }

    void shootChainLightnings(){
        Instantiate(chainLightnings[skillsLevels[2]], transform.position, Quaternion.Euler(0,0,0));
    }

    void shootfireball(){
        Instantiate(fireballs[skillsLevels[3]], transform.position, head.rotation);
        Instantiate(fireballs[skillsLevels[3]], transform.position, head.rotation * Quaternion.Euler(0,0,90));
        Instantiate(fireballs[skillsLevels[3]], transform.position, head.rotation * Quaternion.Euler(0,0,-90));
        Instantiate(fireballs[skillsLevels[3]], transform.position, head.rotation * Quaternion.Euler(0,0,180));
    }

    void shoottidalamulet(){
        Instantiate(tidalamulets[skillsLevels[4]], transform);
    }

    void shootabysalchain(){
        Instantiate(abysalchains[skillsLevels[5]], transform);
    }

    void shootechoconch(){
        Instantiate(echoconchs[skillsLevels[6]], transform.position, head.rotation);
    }
}
