using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _damage;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _damage = Bows._BowsDamage;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = transform.up * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls") 
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            enemy_skilet enemy = collision.gameObject.GetComponent<enemy_skilet>();
            enemy._hp -= _damage;
            Destroy(gameObject);
        }
    }
}