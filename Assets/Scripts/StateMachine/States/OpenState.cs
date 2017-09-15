using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenState : State {

    [SerializeField] private Color _openColor = Color.white;

    private MineSweeperNode _node;
    private SpriteHandler _spriteHandler;

    private bool _isActive = false;

    public override void EnterState()
    {

        GetComponent<SpriteRenderer>().color = _openColor;
        _node = GetComponent<MineSweeperNode>();
        _spriteHandler = GetComponentInChildren<SpriteHandler>();

        _isActive = true;
        SetSprite();
        GetComponent<SpriteRenderer>().color = _openColor;
        if (_node.IsBomb)
        {
            GameManager.instance.GameLost();
            return;
        }


        OpenOtherNeighbours();

    }

    public override void Reason()
    {

    }

    private void OpenOtherNeighbours()
    {

        var neighbours = GameManager.instance.Grid.GetNeighbours(new Vector2(_node.x, _node.y));

        for (int i = 0; i < neighbours.Length; i++)
        {
            if (!neighbours[i].IsBomb && neighbours[i].NeighbourBombs == 0 || !neighbours[i].IsBomb && _node.NeighbourBombs == 0)
            {
                if (!neighbours[i].IsOpen)
                    neighbours[i].OpenTile();
            }
        }

    }

    private void SetSprite()
    {
        if (_node.IsBomb)
        {
            _spriteHandler.SetSprite("bomb");
        }
        else
        {
            _node.CheckNeighbours();
            if (_node.NeighbourBombs > 0)
            {
                _spriteHandler.SetSprite(_node.NeighbourBombs.ToString());
            }
            else
            {
                _spriteHandler.NullSprite();
            }
        }
    }
}
