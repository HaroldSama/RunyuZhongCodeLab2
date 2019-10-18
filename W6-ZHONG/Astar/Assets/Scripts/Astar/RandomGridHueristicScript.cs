using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGridHueristicScript : HueristicScript
{
    public override float Hueristic(int x, int y, Vector3 start, Vector3 goal, GridScript gridScript)
    {
        return 500 * Mathf.Abs(goal.x - x) + Mathf.Abs(goal.y - y);
    }
}
