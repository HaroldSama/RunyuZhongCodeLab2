using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public enum Mark
    {
        Circle,
        Cross,
        Empty,
    }

    public Mark[,] board = new Mark[3,3];
    public bool isCircleTurn;
    public Mark winSide = Mark.Empty;
    public bool endGame;

    public void PlaceMark(Vector2Int pos)
    {
        if (pos.x < 0 || pos.x > 2)
        {
            return;
        }

        if (pos.y < 0 || pos.y > 2)
        {
            return;
        }

        if (board[pos.x, pos.y] != Mark.Empty)
        {
            return;
        }

        if (isCircleTurn)
        {
            board[pos.x, pos.y] = Mark.Circle;
        }
        else
        {
            board[pos.x, pos.y] = Mark.Cross;
        }

        winSide = CheckLine(pos);

        if (winSide == Mark.Empty)
        {
            isCircleTurn = !isCircleTurn;
        }
        else
        {
            WinnerIs(winSide);
        }
    }

    public Mark CheckLine(Vector2Int pos)
    {
        if ((board[pos.x, pos.y] == board[pos.x, (pos.y + 1) % 3] && board[pos.x, pos.y] == board[pos.x, (pos.y + 2) % 3]) ||
            (board[pos.x, pos.y] == board[(pos.x + 1) % 3, pos.y] && board[pos.x, pos.y] == board[(pos.x + 2) % 3, pos.y]) ||
            (board[0,0] == board[1,1] && board[0,0] == board[2,2]) ||
            (board[2,0] == board[1,1] && board[2,0] == board[0,2]))
        {
            return board[pos.x, pos.y];
        }

        return Mark.Empty;
    }

    public void WinnerIs(Mark winner)
    {
        endGame = true;
        MonoBehaviour.print("Winner is " + winner);
    }
}
