using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Difficulty : ScriptableObject {

	[SerializeField] private int _width;
    [SerializeField] private int _height;
    [Space(10)]
    [SerializeField] private int _bombs;

    public int Width { get { return _width; } }
    public int Height { get { return _height; } }

    public int Bombs { get { return _bombs; } }

    

}
