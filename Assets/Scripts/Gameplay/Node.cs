using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public int _x { get; private set; }
    public int _y { get; private set; }

    public void SetGridPosition(int x, int y)
    {
        _x = x;
        _y = y;
    }

}
