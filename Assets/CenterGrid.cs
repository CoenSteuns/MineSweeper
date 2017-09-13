using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterGrid : MonoBehaviour {

    [SerializeField] private GameObject _gridParent;
    [Space(10)]
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private float _margin;
    [SerializeField] private float _tilesize;

    void Awake()
    {
        Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
        var counter = new Vector3((_width * _tilesize) + (_width * _margin), (_height * _tilesize) + (_height * _margin), 0);
        _gridParent.transform.position = centerPos - (counter/4);
    }
}
