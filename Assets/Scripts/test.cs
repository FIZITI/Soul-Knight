using UnityEngine;

public class test : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 2f;
    public float trackingRange = 50f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 patrolDirection;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        patrolDirection = GetRandomDirection();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);
        if (distanceToPlayer < trackingRange)
        {
            Vector2 direction = Player.position - transform.position;
            direction.Normalize();
            movement = direction;
        }
        else
        {
            movement = patrolDirection;
            if (IsBlocked())
            {
                patrolDirection = GetRandomDirection();
            }
        }
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    bool IsBlocked()
    {
        float distanceToObstacle = 1.0f; // Вы можете настроить это значение
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, distanceToObstacle);
        if (hit.collider.gameObject.tag == "Walls")
        {
            // Обнаружено препятствие
            Debug.Log(hit.collider.gameObject.name);
            return true;
        }
        else
        {
            // Препятствий нет
            return false;
        }
    }
}