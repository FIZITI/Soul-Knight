using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] internal float _speed;
    [SerializeField] internal static float _hp = 5;

    private Rigidbody2D _rigidbody;
    internal static float _horizontal;
    internal float _vertical;
    private bool _isTouchingEnemy = false;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0; 
        Application.targetFrameRate = 240;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Death();  
    }

    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        Vector2 inputDirection = new Vector2(_horizontal, _vertical).normalized;

        if (inputDirection != Vector2.zero)
        {
            _rigidbody.velocity = inputDirection * _speed;
        }
    }

    internal void Death()
    {
        if (_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _isTouchingEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _isTouchingEnemy = false;
        }
    }*/
}