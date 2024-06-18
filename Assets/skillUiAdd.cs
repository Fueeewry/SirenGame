using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class skillUiAdd : MonoBehaviour, IPointerClickHandler
{
    public string skillname;
    public float cooldown = 1;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GameObject.Find("Player").GetComponent<playermovement>().addSkill(skillname, cooldown);
        transform.parent.gameObject.SetActive(false);
    }
}
