using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
}