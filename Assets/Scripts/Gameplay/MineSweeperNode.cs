using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileState
{
    open,
    closed
}

public class MineSweeperNode : Node {

    [SerializeField]private bool _isBomb = false;
    private bool _isFlagged = false;


    [SerializeField] private int neighboursBombs = 0;
    [SerializeField] private bool open = false;

    public bool IsBomb { get { return _isBomb; } }
    public bool IsFlaggeed { get { return _isFlagged; } }
    public int NeighbourBombs { get { return neighboursBombs; } }
    public bool IsOpen { get { return open; } }



    public StateMachine<TileState> _stateMachine;

    public StateMachine<TileState> StateMachine { get { return _stateMachine; } }

    private void Start()
    {
        CheckNeighbours();

        _stateMachine = new StateMachine<TileState>();
        _stateMachine.AddState(TileState.closed, GetComponent<ClosedState>());
        _stateMachine.AddState(TileState.open, GetComponent<OpenState>());
        _stateMachine.SetState(TileState.closed);

    }

    public void SetIsBomb(bool bomb)
    {

        _isBomb = bomb;
    }

    public void SetIsFlagged(bool isFlagged)
    {
        _isFlagged = isFlagged;
    }

    public void Open()
    {
        open = true;
    }

    private void Update()
    {
        StateMachine.Update();
    }

    public void CheckNeighbours()
    {
        if (!IsBomb)
        {
            var bombs = 0;
            var neighbours = GameManager.instance.Grid.GetNeighbours(new Vector2(x, y));
            for (int i = 0; i < neighbours.Length; i++)
            {
                if (neighbours[i].IsBomb)
                    bombs++;
            }
            neighboursBombs = bombs;
        }

        //if (neighboursBombs == 0 && !IsBomb)
           // GetComponent<SpriteRenderer>().color = Color.red;

    }



}
