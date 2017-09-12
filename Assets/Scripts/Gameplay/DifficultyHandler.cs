using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHandler : MonoBehaviour {

    [SerializeField]
    private string _difficultyKey = "Difficulty";
    [SerializeField]
    private ScriptableObject[] _difficulties;

    public ScriptableObject Difficulty { get; private set; }

    private void Awake()
    {
        var difficultyName = PlayerPrefs.GetString(_difficultyKey);
        for (int i = 0; i < _difficulties.Length; i++)
        {
            Difficulty = _difficulties[i];
            if (_difficulties[i].name == difficultyName)
                break;
        }

        print(Difficulty.name);
    }
}
