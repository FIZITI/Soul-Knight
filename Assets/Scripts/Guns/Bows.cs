using System.Collections;
using UnityEngine;

public class Bows : MonoBehaviour
{   
    [SerializeField] GameObject _bullet;
    [SerializeField] internal static float _BowsDamage = 1f;
    [SerializeField] private float _delayShots = 0.3f;
    [SerializeField] internal static float _mana = 100f; 

    private bool _isShooting = false;

    private void Update()
    {
        if (!_isShooting)
        {
            StartCoroutine(DelayBetweenShots());
        }
    }

    IEnumerator DelayBetweenShots()
    {
        _isShooting = true;

        if (Input.GetKey(KeyCode.Mouse0) && _mana > 0)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
            _mana -= 5f;
            yield return new WaitForSeconds(_delayShots);
        }
        _isShooting = false;
    }
}