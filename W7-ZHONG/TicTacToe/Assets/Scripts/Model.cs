using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public enum Mark
    {
        Empty = 0,
        Circle = 1,
        Cross = -1,
    }

    public Mark[,] board = new Mark[3,3];
    public Mark turn = Mark.Circle;
    public bool endGame;

    public void PlaceMark(Vector2Int pos)
    {
        if (board[pos.x, pos.y] != Mark.Empty)
        {
            return;
        }

        board[pos.x, pos.y] = turn;

        if (CheckLine(pos))
        {
            endGame = true;
        }
        else
        {
            turn = (Mark)(-(int)turn);
        }
    }

    private bool CheckLine(Vector2Int pos)
    {
        if ((board[pos.x, pos.y] == turn && board[pos.x, (pos.y + 1) % 3] == turn && board[pos.x, (pos.y + 2) % 3] == turn) ||
            (board[pos.x, pos.y] == turn && board[(pos.x + 1) % 3, pos.y] == turn && board[(pos.x + 2) % 3, pos.y] == turn) ||
            (board[0,0] == turn && board[1,1] == turn && board[2,2] == turn) ||
            (board[2,0] == turn && board[1,1] == turn && board[0,2] == turn))
        {
            return true;
        }

        return false;
    }
}
