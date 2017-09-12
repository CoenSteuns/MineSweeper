using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public int x { get; private set; }
    public int y { get; private set; }

    public void SetGridPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

}
