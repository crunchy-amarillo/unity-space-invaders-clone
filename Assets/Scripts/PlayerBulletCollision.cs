using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{   
    private GameManager gameManager;
    private SoundManager soundManager;

    private void Awake()
    {
        this.gameManager = FindObjectOfType<GameManager>();
        this.soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Wall")
        {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            return;
        }

        // Destroy Bullet
        Destroy(gameObject);

        if (collision.gameObject.tag == "Enemy")
        {
            EnemyDestroy(collision.gameObject);
        }
    }

    private void EnemyDestroy(GameObject enemy)
    {
        this.gameManager.IncreaseScore(1);
        Animator enemyAnimator = enemy.GetComponent<Animator>();
        enemyAnimator.SetTrigger("HitTrigger");
        Destroy(enemy, 0.1f);
        this.soundManager.PlayEnemyDestroySound();
    }
}
