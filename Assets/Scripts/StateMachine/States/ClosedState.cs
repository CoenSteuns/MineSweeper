using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedState : State {

    private MineSweeperNode _node;
    private SpriteHandler _spriteHandler;

    private bool _isActive = false;

    public override void EnterState()
    {
        _node = GetComponent<MineSweeperNode>();
        _spriteHandler = GetComponentInChildren<SpriteHandler>();
        _isActive = true;
    }

    public override void ExitState()
    {
        _isActive = false;
    }

    public override void Reason()
    {


    }

    private void OnMouseOver()
    {
        if (!_isActive)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            _node.OpenTile();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _node.SetIsFlagged(!_node.IsFlaggeed);
            GameManager.instance.ChangeFlag(_node.x, _node.y);
            if (_node.IsFlaggeed)
            {
                _spriteHandler.SetSprite("flag");
                return;
            }
            _spriteHandler.NullSprite();
        }

    }
}
