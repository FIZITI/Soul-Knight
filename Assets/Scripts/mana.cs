using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class mana : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = Weapon._Mana.ToString();
    }

    private void Update()
    {
        _text.text = Weapon._Mana.ToString();
    }

}
