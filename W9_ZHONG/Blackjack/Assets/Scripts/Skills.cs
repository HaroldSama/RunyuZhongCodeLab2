using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skills : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rt;
    private bool _up;
    public static int mP = 10;
    public RectTransform nextCard;
    public RectTransform nextCardBack;
    public Text mPText;

    private bool _flipping;
    private Vector3 _zeroSize = new Vector3(1, 0, 1);

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

        mPText.text = "MP: " + mP;
    }
    
    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        //Debug.Log("Cursor Entering " + name + " GameObject");
        _up = true;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        //Debug.Log("Cursor Exiting " + name + " GameObject");
        _up = false;
    }

    public void FlipNextCard()
    {
        if (_flipping || mP < 2)
        {
            return;
        }
        
        _flipping = true;

        mP -= 2;
        
        StartCoroutine(Flip(nextCardBack, _zeroSize, 1));
    }

    IEnumerator Flip(RectTransform card, Vector3 end, int step)
    {
        float timer = 0;

        while (timer < 0.5f)
        {
            card.localScale = Vector3.Lerp(card.localScale, end, timer / 0.5f);

            timer += Time.deltaTime;

            yield return 0;
        }

        card.localScale = end;

        if (step == 1)
        {
            StartCoroutine(Flip(nextCard, Vector3.one, 2));
        }
        else if (step == 2)
        {
            StartCoroutine(Flip(nextCard, _zeroSize, 3));
        }
        else if (step == 3)
        {
            StartCoroutine(Flip(nextCardBack, Vector3.one, 4));
        }
        else if (step == 4)
        {
            _flipping = false;
        }
    }
}
