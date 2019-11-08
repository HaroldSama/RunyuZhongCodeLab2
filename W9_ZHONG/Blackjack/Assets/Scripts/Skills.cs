using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skills : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rt;
    private bool _up;
    public int mP = 10;

    void Awake()
    {
        _rt = GetComponent<RectTransform>();
    }
    
    void Update()
    {
        if (_up)
        {
            Vector3 pos = _rt.position;
            pos.y = Mathf.Clamp(pos.y + 5, -40, 75);
            
            _rt.position = pos;
        }
        else
        {
            Vector3 pos = _rt.position;
            pos.y = Mathf.Clamp(pos.y - 5, -40, 75);
            
            _rt.position = pos;
        }
    }
    
    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
        _up = true;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
        _up = false;
    }
}
