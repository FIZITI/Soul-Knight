using UnityEngine;

public class enemy_skilet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] internal float _hp = 3;
    [SerializeField] private float _pushForce = 5;
    [SerializeField] private float _changeTime = 1f;
    [SerializeField] private float _sightRange = 3f;
    [SerializeField] private float _angleRange = 45f;

    private GameObject _player;
    private SpriteRenderer _enemySprite;
    private Rigidbody2D _rb;
    private Transform _target;

    private enum AIState { Wander, Chase };
    private AIState _state;
    private Vector2 _direction;

    private float _timer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemySprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _target = _player.transform;

        _state = AIState.Wander;
        _direction = Random.insideUnitCircle.normalized;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, _target.position);

        if (distance < _sightRange)
        {
            _state = AIState.Chase;
        }
        else
        {
            _state = AIState.Wander;
        }

        switch (_state)
        {
            case AIState.Wander:
                Wander();
                break;
            case AIState.Chase:
                Chase();
                break;
        }
    }

    private void LookAtTarget(Transform target)
    {
        if (target.position.x < transform.position.x)
        {
            _enemySprite.flipX = true;
        }
        else if (target.position.x > transform.position.x)
        {
            _enemySprite.flipX = false;
        }

        if (_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void Wander()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            Vector2 toTarget = (_target.position - transform.position).normalized;
            float randomAngle = Random.Range(-_angleRange, _angleRange);
            _direction = Quaternion.Euler(0, 0, randomAngle) * toTarget;

            _timer = _changeTime;
        }
        _rb.velocity = _direction * _speed;
        LookAtTarget(_target);
    }

    void Chase()
    {
        _direction = (_target.position - transform.position).normalized;
        _rb.velocity = _direction * _speed;

        LookAtTarget(_target);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Push(collision);
    }

    internal void Push(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(pushDirection * _pushForce, ForceMode2D.Impulse);
        }
    }
}