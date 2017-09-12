using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour {

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private List<Sprite> _sprites;

    private void Start()
    {
        if (_renderer == null)
            _renderer = GetComponent<SpriteRenderer>();
    }

    public Sprite GetSprite(int number)
    {
        return _sprites[number];
    }
    public Sprite GetSprite(string name)
    {
        for (int i = 0; i < _sprites.Count; i++)
        {
            if (name == _sprites[i].name)
                return _sprites[i];
        }
        return null;
    }

    public void AddSprite(Sprite sprite)
    {
        _sprites.Add(sprite);
    }

    public void SetSprite(int number)
    {
        _renderer.sprite = GetSprite(number);
    }
    public void SetSprite(string name)
    {
        _renderer.sprite = GetSprite(name);
    }

    public void NullSprite()
    {
        _renderer.sprite = null;
    }

}
