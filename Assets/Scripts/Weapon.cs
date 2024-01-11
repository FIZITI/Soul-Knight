using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] private float _delayShots = 0.3f;

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

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(_bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(_delayShots);
        }
        _isShooting = false;
    }
}