using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterGrid : MonoBehaviour {

    [SerializeField] private GameObject _gridParent;
    [Space(10)]
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private float _tileDistance;


    public void SetParent(GameObject parent)
    {
        _gridParent = parent;
    }

    public void SetSize(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public void Center()
    {
        Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
        var counter = new Vector3((_width-1) * _tileDistance, (_height-1) * _tileDistance, 0);
        _gridParent.transform.position = centerPos - (counter / 2);
    }
}
