using UnityEngine;

public class enemy_skilet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] internal static float _hp = 3;
    [SerializeField] private float _pushForce = 5;

    private GameObject Player;
    private SpriteRenderer EnemySprite;

    private Rigidbody2D _rb;
    private Rigidbody2D _rbPlayer;
    private Transform target;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        EnemySprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        _rbPlayer = Player.GetComponent<Rigidbody2D>();
        target = Player.transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        if (target.position.x < transform.position.x)
        {
            EnemySprite.flipX = true;
        }
        else if (target.position.x > transform.position.x)
        {
            EnemySprite.flipX = false;
        }

        if (_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(pushDirection * _pushForce, ForceMode2D.Impulse);

            /*            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

                        Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
                        playerRigidbody.velocity = pushDirection * _pushForce;*/
        }
    }





    /*    private void OnCollisionEnter(Collision collision)
        {
            Push(collision);
        }*/

    /*    private void Push(Collider2D collision)
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            Vector2 direction = (collision.transform.position - transform.position);
            direction.Normalize();
            rb.velocity = Vector2.Lerp(rb.velocity, direction * _pushForce * 30, Time.deltaTime);
        }*/
}