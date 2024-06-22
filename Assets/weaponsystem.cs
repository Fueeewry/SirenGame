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
            case "getlightboots":
                a = 0;
                break;
            case "getvitality":
                a = 1;
                break;
            case "getbiggerradius":
                a = 2;
                break;
            case "getsharperweaponry":
                a = 3;
                break;
            case "getiframe":
                a = 4;
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
    public playermovement playermov;
    float projectileSize = 1;
    int pierceCount = 0;

    int[] skillsLevels, skillsLevelsPassive;

    void Start(){
        skillsLevels = new int[20];
        skillsLevelsPassive = new int[20];
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
            if(skillList[i].skillCooldown > 0){
                skillsLevels[skillList[i].getidx()] = skillList[i].skillLevel;
                InvokeRepeating(skillList[i].skillFunctionName, 0.1f, skillList[i].skillCooldown);
            }else{
                skillsLevelsPassive[skillList[i].getidx()] = skillList[i].skillLevel;
                Invoke(skillList[i].skillFunctionName, 0.1f);
            }
        }
    }

    //=========================================================================================================//

    void getlightboots(){
        if(skillsLevelsPassive[0] < 6){
            playermov.speed += 0.15f;
        }else{
            playermov.speed += 0.1f;
        }
    }

    void getvitality(){
        playermov.healthbar.maxValue += 20;
        playermov.healthbar.value += 20;
    }

    void getbiggerradius(){
        projectileSize += 0.15f;
    }

    void getsharperweaponry(){
        pierceCount += 1;
    }

    void getiframe(){
        playermov.iframeTime += 1;
    }


    //=========================================================================================================//

    void shootanchor(){
        GameObject a = Instantiate(anchors[skillsLevels[0]], transform);
        a.transform.localScale *= projectileSize;
        a.GetComponent<damagedetection>().pierce += pierceCount;
    }

    void shoottrident(){
        GameObject a = Instantiate(tridents[skillsLevels[1]], transform.position, head.rotation);
        a.transform.localScale *= projectileSize;
        a.GetComponent<damagedetection>().pierce += pierceCount;
    }

    void shootChainLightnings(){
        GameObject a = Instantiate(chainLightnings[skillsLevels[2]], transform.position, Quaternion.Euler(0,0,0));
        a.transform.localScale *= projectileSize;
        a.GetComponent<damagedetection>().pierce += pierceCount;
    }

    void shootfireball(){
        GameObject a = Instantiate(fireballs[skillsLevels[3]], transform.position, head.rotation * Quaternion.Euler(0,0,0));
        a.transform.localScale *= projectileSize;
        a.GetComponent<damagedetection>().pierce += pierceCount;
        a = Instantiate(fireballs[skillsLevels[3]], transform.position, head.rotation * Quaternion.Euler(0,0,90));
        a.transform.localScale *= projectileSize;
        a.GetComponent<damagedetection>().pierce += pierceCount;
        a = Instantiate(fireballs[skillsLevels[3]], transform.position, head.rotation * Quaternion.Euler(0,0,-90));
        a.transform.localScale *= projectileSize;
        a.GetComponent<damagedetection>().pierce += pierceCount;
        a = Instantiate(fireballs[skillsLevels[3]], transform.position, head.rotation * Quaternion.Euler(0,0,180));
        a.transform.localScale *= projectileSize;
        a.GetComponent<damagedetection>().pierce += pierceCount;
    }   

    void shoottidalamulet(){
        GameObject a = Instantiate(tidalamulets[skillsLevels[4]], transform);
        a.transform.localScale *= projectileSize;
        a.GetComponent<damagedetection>().pierce += pierceCount;
    }

    void shootabysalchain(){
        GameObject a = Instantiate(abysalchains[skillsLevels[5]], transform);
        a.transform.localScale *= projectileSize;
        a.GetComponent<damagedetection>().pierce += pierceCount;
    }

    void shootechoconch(){
        GameObject a = Instantiate(echoconchs[skillsLevels[6]], transform.position, head.rotation);
        a.transform.localScale *= projectileSize;
        a.GetComponent<damagedetection>().pierce += pierceCount;
    }
}
