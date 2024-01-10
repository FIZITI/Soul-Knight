using UnityEngine;

public class enemy_skilet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _hp = 3;
    [SerializeField] private float _pushForce = 5;

    private GameObject Player;
    private SpriteRenderer EnemySprite;

    private Rigidbody2D Player_rb;
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
        Player_rb = GetComponent<Rigidbody2D>();
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
        /*else if (collision.gameObject.tag.Equals("Player"))
        {
            Push(collision);
        }*/

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Push(collision);
    }

    private void Push(Collision collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Collider>().GetComponent<Rigidbody2D>();

        Vector3 direction = collision.transform.position - transform.position;
        direction.Normalize();

        Player_rb.AddForce(direction * _pushForce, ForceMode2D.Impulse);*//*
    }*/

}
