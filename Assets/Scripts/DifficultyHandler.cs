using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHandler : MonoBehaviour {

    private DifficultySelector _selector;

    private GameManager _manager;
    private CenterGrid _center;

    public void Awake()
    {
        _selector = GetComponent<DifficultySelector>();
        var diff = (Difficulty)_selector.Difficulty;

        _center = GetComponent<CenterGrid>();

        _center.SetSize(diff.Width, diff.Height);

        _center.Center();
    }


}
