using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll
{
    public Vector2Int Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return new Vector2Int(0, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return new Vector2Int(1, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return new Vector2Int(2, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return new Vector2Int(0, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            return new Vector2Int(1, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            return new Vector2Int(2, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            return new Vector2Int(0, 2);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            return new Vector2Int(1, 2);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            return new Vector2Int(2, 2);
        }

        return new Vector2Int(-1, -1);
    }
}
