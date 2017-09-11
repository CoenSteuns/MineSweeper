using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    [SerializeField] private GameObject _tile;
    [SerializeField] private Difficulty[] _difficulties;

    private Grid<MineSweeperNode> _grid;
    private Difficulty _difficulty;

    
    private void Awake()
    {
        if (GameManager.instance != null)
            Destroy(gameObject);

        instance = this;

                
    }

    void Start () {
        _difficulty = (Difficulty)GetComponent<DifficultyHandler>().Difficulty;
        _grid = new Grid<MineSweeperNode>(_difficulty.Width,_difficulty.Height);
        SetNewGrid();
    }

    public void SetNewGrid()
    {
        _grid.ForEachNode((node, x, y) => {
            //creating the gameobject
            _tile = Instantiate(_tile);
            _tile.transform.position = new Vector3(x * 0.2f, y * 0.2f, 0);
            _tile.transform.parent = transform;

            //setting the node
            node = _tile.GetComponent<MineSweeperNode>();
            node.SetGridPosition(x, y);

            return node;
        });

        for (int i = 0; i < _difficulty.Bombs; i++)
        {
            int x = (int)Random.Range(0, _difficulty.Width);
            int y = (int)Random.Range(0, _difficulty.Height);
            print(i);
            MineSweeperNode node = _grid.GetNode(x, y);
            if (node.isMine)
            {
                i--;
            }
            node.isMine = true;
            node.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
