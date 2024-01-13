using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = Player._hp.ToString();
    }

    private void Update()
    {
        _text.text = Player._hp.ToString();
    }

}
