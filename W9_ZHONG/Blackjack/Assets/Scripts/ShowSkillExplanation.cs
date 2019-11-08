using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowSkillExplanation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject explanation;
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        explanation.SetActive(true);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        explanation.SetActive(false);
    }
}
