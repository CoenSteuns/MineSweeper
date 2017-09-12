using UnityEngine;
using UnityEngine.UI;


public class TextSetter : MonoBehaviour {

    private Selector _selector;
    [SerializeField]
    private Text _text;


    private void Start()
    {
        _selector = GetComponent<Selector>();
        SetText();
    }

    public void SetText()
    {
        _text.text = _selector.GetSelectedName();
    }

}
