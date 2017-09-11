using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour {

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void SetImage(Sprite image)
    {
        _image.sprite = image;
    }

}
