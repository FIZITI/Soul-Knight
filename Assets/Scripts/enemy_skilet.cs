using UnityEngine;

public class enemy_skilet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] internal static float _hp = 3;
    [SerializeField] private float _pushForce = 5;

    private GameObject Player;
    private SpriteRenderer EnemySprite;

    private Rigidbody2D _rb;
    private Transform target;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        EnemySprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        target = Player.transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (target.position.x < transform.position.x) 
        {
            EnemySprite.flipX = true;
        }
        else if(target.position.x > transform.position.x)
        {
            EnemySprite.flipX = false;
        }

        if (_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            _hp -= 1;
        }
        if (collision.gameObject.tag.Equals("Player"))
        {
            Push(collision);
        }

    }

/*    private void OnCollisionEnter(Collision collision)
    {
        Push(collision);
    }*/

    private void Push(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        Vector2 direction = (collision.transform.position - transform.position) * 1000;
        direction.Normalize();
        rb.AddForce(direction * _pushForce * 30, ForceMode2D.Impulse);
    }
}