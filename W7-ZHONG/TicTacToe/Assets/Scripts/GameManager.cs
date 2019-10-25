using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Model model = new Model();
    public View view = new View();
    public Control control = new Control();
    public Transform markHolder;
    public Text winText;
    public bool vsAi;
    
    private bool _waitingToRestart;
    private bool _waitingAiToRespond;
    private List<Vector2Int> availableBoardPos;

    private void Awake()
    {
        availableBoardPos = new List<Vector2Int>()
        {
            new Vector2Int(0, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, 2),
            new Vector2Int(1, 0),
            new Vector2Int(1, 1),
            new Vector2Int(1, 2),
            new Vector2Int(2, 0),
            new Vector2Int(2, 1),
            new Vector2Int(2, 2)            
        };
    }

    private void Update()
    {
        if (_waitingAiToRespond)
        {
            return;
        }
        
        if (_waitingToRestart)
        {
            if (control.ConfirmRestart())
            {
                ResetGame();
            }
            
            return;
        }
        
        Vector2Int pos = control.Update();

        if (pos == new Vector2Int(-1, -1) || model.board[pos.x, pos.y] != Model.Mark.Empty)
        {
            return;
        }
        
        PlayAMove(pos);
        
        if (!model.endGame && vsAi)
        {
            _waitingAiToRespond = true;
            Invoke(nameof(AiPlay), 1);
        }
    }

    void PlayAMove(Vector2Int pos)
    {
        GameObject newMark = view.UpdateView(pos, model.turn, model.board[pos.x, pos.y]);

        if (newMark)
        {
            newMark.transform.SetParent(markHolder);
        }
        
        model.PlaceMark(pos);

        availableBoardPos.Remove(pos);
        
        if (model.endGame)
        {
            winText.text = model.turn + " Wins. Press [R] to restart.";
            _waitingToRestart = true;
        }       
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

        availableBoardPos = new List<Vector2Int>()
        {
            new Vector2Int(0, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, 2),
            new Vector2Int(1, 0),
            new Vector2Int(1, 1),
            new Vector2Int(1, 2),
            new Vector2Int(2, 0),
            new Vector2Int(2, 1),
            new Vector2Int(2, 2)            
        };
    }

    void AiPlay()
    {
        _waitingAiToRespond = false;
        PlayAMove(availableBoardPos[Random.Range(0, availableBoardPos.Count)]);
    }

    Vector2Int BestMove()
    {
        int move = -1;
        int score = -2;

        for (int i = 0; i < 9; i++)
        {
            
        }

        return availableBoardPos[move];
    }
}
