using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstHueristicScript : HueristicScript
{
    GameObject[,] pos;
    private int step;

    public override float Hueristic(int x, int y, Vector3 start, Vector3 goal, GridScript gridScript)
    {
        step++;
        return - step * 500;
    }
}
