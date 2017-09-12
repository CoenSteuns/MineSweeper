using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    private int _selected = 0;

    [SerializeField] private List<ScriptableObject> _selectables;
    
    public void SetCurrentlySelected()
    {
        PlayerPrefs.SetString("Difficulty", _selectables[_selected].name);
    }

    public void SelectNext()
    {
        _selected++;
        if (_selected >= _selectables.Count)
            _selected = 0;
    }

    public void Selectpref()
    {
        _selected++;
        if (_selected >= _selectables.Count)
            _selected = 0;
    }

    public string GetSelectedName()
    {
        return _selectables[_selected].name;
    }
}
