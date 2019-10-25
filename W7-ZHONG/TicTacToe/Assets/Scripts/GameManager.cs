using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Model model = new Model();
    public View view = new View();
    public Controll control = new Controll();
    public Transform markHolder;

    private bool _waitingToRestart;

    private void Update()
    {
        if (_waitingToRestart)
        {
            return;
        }
        
        if (model.endGame)
        {
            _waitingToRestart = false;
            return;
        }
        
        Vector2Int pos = control.Update();

        if (pos == new Vector2Int(-1, -1))
        {
            return;
        }
        
        GameObject newMark = view.UpdateView(pos, model.turn, model.board[pos.x, pos.y]);

        if (newMark)
        {
            newMark.transform.parent = markHolder;
        }
        
        model.PlaceMark(pos);
    }
}
