using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {

    private Grid<MineSweeperNode> _grid;
    private List<Vector2> _bombs;

    public Grid<MineSweeperNode> Grid { get { return _grid; } }
    public List<Vector2> Bombs { get { return _bombs; } }


    public void StartGame(int width, int height, int bombs, GameObject tile)
    {
        DeletaAllTiles();
        _grid = new Grid<MineSweeperNode>(width, height);
        _grid.ForEachNode((node, x, y) => {

            node = CreateNewTile(x, y, tile).GetComponent<MineSweeperNode>();
            node.SetGridPosition(x, y);

            return node;
        });
        CreateBomb(width, height, bombs);

    }

    private void CreateBomb(int width, int height, int bombs)
    {
        _bombs = new List<Vector2>();
        for (int i = 0; i < bombs; i++)
        {
            int x = (int)Random.Range(0, width);
            int y = (int)Random.Range(0, height);

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

    private GameObject CreateNewTile(int x, int y, GameObject tile)
    {
        var CurrentTile = Instantiate(tile);
        CurrentTile.transform.parent = transform;
        CurrentTile.transform.localPosition = new Vector3(x * 0.2f, y * 0.2f, 0);
        return CurrentTile;
    }
}
