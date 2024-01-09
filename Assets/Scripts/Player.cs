using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float _speed;
    
    private Rigidbody2D _rigidbody;
    private float _horizontal;
    private float _vertical;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _rigidbody.velocity = new Vector2(_horizontal * _speed, _vertical * _speed);
    }
}