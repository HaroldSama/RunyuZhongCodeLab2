using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Model model = new Model();
    public View view = new View();
    public Control control = new Control();
    public Transform markHolder;
    public Text winText;

    private bool _waitingToRestart;

    private void Update()
    {
        if (_waitingToRestart)
        {
            if (control.ConfirmRestart())
            {
                ResetGame();
            }
            
            return;
        }
        
        if (model.endGame)
        {
            winText.text = model.turn + " Wins. Press [R] to restart.";
            _waitingToRestart = true;
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
            newMark.transform.SetParent(markHolder);
        }
        
        model.PlaceMark(pos);
    }

    void ResetGame()
    {
        winText.text = "";
        model = new Model();
        view = new View();
        control = new Control();

        foreach (Transform mark in markHolder.transform)
        {
            Destroy(mark.gameObject);
        }

        _waitingToRestart = false;
    }
}
