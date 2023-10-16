using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public BulletMovementType movementType;
    public Vector2 velocity;
    public float speed = 1f;

    private Rigidbody2D bulletRigidbody;

    void Start()
    {
        this.bulletRigidbody = GetComponent<Rigidbody2D>();        

        if (movementType.Equals(BulletMovementType.TO_PLAYER))
        {
            MoveToPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall" && collision.transform.name == "BottomWall")
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
       switch (this.movementType) {
            case BulletMovementType.STRAIGHT:
                MoveStraight();
                break;
       }
    }

    private void MoveStraight()
    {
        this.bulletRigidbody.velocity = this.velocity * this.speed;
    }

    private void MoveToPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (null == playerObject)
        {
            return;
        }

        Vector3 direction2d = (playerObject.transform.position - transform.position).normalized;
        Vector2 direction = new Vector2(direction2d.x, direction2d.y);
        GetComponent<Rigidbody2D>().velocity = direction * this.speed;
    }
}
