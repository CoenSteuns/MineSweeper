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
    public UnityEvent OnWin;

    public List<Vector2> _flaggedTiles;



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
        _flaggedTiles = new List<Vector2>();
        _gridHandler.StartGame(_difficulty.Width, _difficulty.Height, _difficulty.Bombs, _tile);
    }

    public void ChangeFlag(int x, int y)
    {
        var newFlag = new Vector2(x, y);
        if (!_flaggedTiles.Contains(newFlag)) {
            _flaggedTiles.Add(newFlag);
            CheckWin();
            return;
        }

        _flaggedTiles.Remove(newFlag);
            
    }

    private void CheckWin()
    {
        if (_flaggedTiles.Count != _gridHandler.Bombs.Count)
            return;

        for (int i = 0; i < _flaggedTiles.Count; i++)
        {
            if (!_gridHandler.Bombs.Contains(_flaggedTiles[i]))
                return;
        }
        
        if(OnWin != null)
            OnWin.Invoke();

        
    }

}
