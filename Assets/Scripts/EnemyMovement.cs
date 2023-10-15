using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 velocity;
    private Rigidbody2D objectRigidbody;

    private void Start()
    {
        this.objectRigidbody = GetComponent<Rigidbody2D>();
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
        this.objectRigidbody.velocity = velocity;
    }
}
