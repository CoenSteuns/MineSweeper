using System;
using System.Collections.Generic;
using UnityEngine;

public class Grid<T>
{
    private int _x;
    private int _y;

    private T[,] _grid;

    public T[,] GridObject
    {
        get { return _grid; }
    }
    public int X
    {
        get { return _x; }
    }
    public int Y
    {
        get { return _y; }
    }

    public Grid(int x, int y)
    {
        _x = x;
        _y = y;
        _grid = new T[x, y];
        ResetGrid();
    }

    public T GetNode(Vector2 node)
    {
        return GetNode((int)node.x, (int)node.y);
    }
    public T GetNode(int x, int y)
    {
        if (x > _x || y > _y) { return default(T); }
        return _grid[x, y];
    }

    public void SetNode(T newNode, Vector2 node)
    {
        SetNode(newNode, (int)node.x, (int)node.y);
    }
    public void SetNode(T newNode, int x, int y)
    {
        if (x > _x || y > _y) { return; }
        _grid[x, y] = newNode;
    }

    public void ForEachNode(Func<T,int, int, T> test)
    {
        for (int x = 0; x < _x; x++)
        {
            for (int y = 0; y < _y; y++)
            {
                _grid[x, y] = test(_grid[x, y], x, y);

            }
        }
    }

    public void ResetGrid(T node = default(T))
    {
        _grid = ResetGrid(_grid, node);
    }

    public void ResizeGrid(int x, int y, T newNodes = default(T), bool keepOldValues = true)
    {
        var grid = new T[x, y];
        grid = ResetGrid(grid, newNodes);
        if (!keepOldValues)
        {
            _grid = grid;
            return;
        }

        var resetX = x > _grid.GetLength(0) ? _grid.GetLength(0) : x;
        var resetY = y > _grid.GetLength(1) ? _grid.GetLength(1) : y;

        for (int fx = 0; fx < resetX; fx++)
        {
            for (int fy = 0; fy < resetY; fy++)
            {
                grid[fx, fy] = _grid[fx, fy];
            }
        }
        _grid = grid;
    }

    public T[] GetNeighbours(Vector2 nodePosition, bool cross = true)
    {
        List<T> neighbours = new List<T>();
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {

                if ((!cross && (y == 1 || y == -1) && (x == 1 || x == -1)) ||
                    x == 0 && y == 0)
                    continue;

                var position = new Vector2(x, y) + nodePosition;

                if (position.x > _x-1 || position.y > _y-1 || position.x < 0 || position.y < 0)
                    continue;

                neighbours.Add(GetNode(position));


            }
        }
        return neighbours.ToArray();

    }

    public T[] GetReletives(Vector2 nodePosition, Vector2[] reletivesPosition)
    {
        var nodeX = (int)nodePosition.x;
        var nodeY = (int)nodePosition.y;

        var reletives = new List<T>();

        for (int i = 0; i < reletivesPosition.Length; i++)
        {
            reletives.Add(GetNode(nodeX + (int)reletivesPosition[i].x, nodeY + (int)reletivesPosition[i].y));
        }

        return reletives.ToArray();
    }

    private T[,] ResetGrid(T[,] grid, T node = default(T))
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                grid[x, y] = node;
            }
        }
        return grid;
    }

}