using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(_bullet, transform.position, transform.rotation);
        }

        
    }
}