using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll
{
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            MonoBehaviour.print(Input.mousePosition);
        }
    }
}
