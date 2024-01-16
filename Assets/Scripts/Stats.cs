using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    
    private enum PlayerStats
    {
        HealsPoint,
        Shild,
        Mana
    }

    private Text _text;

    [SerializeField] private PlayerStats playerStats;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = Player._hp.ToString();
    }

    private void Update()
    {
        switch (playerStats)
        {
            case PlayerStats.HealsPoint:

                if(Player._shild <= 0)
                {
                    _text.text = Player._hp.ToString();
                }
                
                break;

            case PlayerStats.Shild:

                _text.text = Player._shild.ToString();

                break;

            case PlayerStats.Mana:

                _text.text = Bows._mana.ToString();

                break;
        }
    }

}
