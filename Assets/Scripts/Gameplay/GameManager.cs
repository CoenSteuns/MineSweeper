using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    [SerializeField] private GameObject _tile;

    private Difficulty _difficulty;
    private GameStarter _gridHandler;

    public Grid<MineSweeperNode> Grid { get { return _gridHandler.Grid; } }

    public UnityEvent OnLose;

    public int _flaggedTiles = 0;



    private void Awake()
    {
        if (GameManager.instance != null)
            Destroy(gameObject);

        instance = this;
        if (OnLose == null)
            OnLose = new UnityEvent();
    }

    void Start () {

        _gridHandler = GetComponent<GameStarter>();
        _difficulty = (Difficulty)GetComponent<DifficultySelector>().Difficulty;

        _gridHandler.StartGame(_difficulty.Width, _difficulty.Height, _difficulty.Bombs, _tile);
    }

    public void GameLost()
    {
        OnLose.Invoke();
    }

    public void StartGame()
    {
        _gridHandler.StartGame(_difficulty.Width, _difficulty.Height, _difficulty.Bombs, _tile);
    }



}
