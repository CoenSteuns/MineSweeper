using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    [SerializeField] private GameObject _tile;

    private Grid<MineSweeperNode> _grid;
    private List<Vector2> _bombs;
    private Difficulty _difficulty;

    public Grid<MineSweeperNode> Grid { get { return _grid; } }

    public UnityEvent OnLose;

    private void Awake()
    {
        if (GameManager.instance != null)
            Destroy(gameObject);

        instance = this;
        if (OnLose == null)
            OnLose = new UnityEvent();
    }

    void Start () {
        _difficulty = (Difficulty)GetComponent<DifficultyHandler>().Difficulty;
        _grid = new Grid<MineSweeperNode>(_difficulty.Width,_difficulty.Height);

        SetNewGrid();
    }

    public void GameLost()
    {
        OnLose.Invoke();
    }

    public void SetNewGrid()
    {
        DeletaAllTiles();
        _grid = new Grid<MineSweeperNode>(_difficulty.Width, _difficulty.Height);
        _grid.ForEachNode((node, x, y) => {


            node = CreateNewTile(x, y).GetComponent<MineSweeperNode>();
            node.SetGridPosition(x, y);

            return node;
        });

        _bombs = new List<Vector2>();
        for (int i = 0; i < _difficulty.Bombs; i++)
        {
            int x = (int)Random.Range(0, _difficulty.Width);
            int y = (int)Random.Range(0, _difficulty.Height);

            MineSweeperNode node = _grid.GetNode(x, y);
            if (node.IsBomb)
            {
                i--;
                continue;
            }
            _bombs.Add(new Vector2(x, y));
            node.SetIsBomb(true);
        }
    }

    private void DeletaAllTiles()
    {
        var children = GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].gameObject != this.gameObject)
                Destroy(children[i].gameObject);
        }
    }

    private GameObject CreateNewTile(int x, int y)
    {
        var tile = Instantiate(_tile);
        tile.transform.position = new Vector3(x * 0.2f, y * 0.2f, 0);
        tile.transform.parent = transform;
        return tile;
    }


}
