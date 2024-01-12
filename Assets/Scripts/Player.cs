using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] internal float _speed;
    [SerializeField] internal static float _hp = 5;

    private Rigidbody2D _rigidbody;
    
    private bool _flipRight = true;
    internal static float _horizontal;
    private float _vertical;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0; 
        Application.targetFrameRate = 240;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _rigidbody.velocity = new Vector2(_horizontal * _speed, _vertical * _speed);

        if (_hp <= 0)
        {
            Death();
        }

        /*if ((!_flipRight && _horizontal > 0) || (_flipRight && _horizontal < 0))
        {
            transform.localScale *= new Vector2(-1, 1);
            _flipRight = !_flipRight;
        }*/
    }

    private void flip()
    {
        transform.localScale *= new Vector2(-1, 1);
    }


    internal void Death()
    {
        gameObject.SetActive(false);
    }
}