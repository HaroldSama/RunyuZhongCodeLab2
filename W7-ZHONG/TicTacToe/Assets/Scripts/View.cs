using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class View
{
    public GameObject UpdateView(Vector2Int pos, Model.Mark markToPut, Model.Mark markInSpace)
    {
        if (markInSpace != Model.Mark.Empty)
        {
            return null;
        }
        
        if (markToPut == Model.Mark.Circle)
        {
            return (GameObject)MonoBehaviour.Instantiate(Resources.Load("Circle"), new Vector3(pos.x, pos.y), Quaternion.identity);
        }
        else
        {
            return (GameObject)MonoBehaviour.Instantiate(Resources.Load("Cross"), new Vector3(pos.x, pos.y), Quaternion.identity);
        }
    }
}
