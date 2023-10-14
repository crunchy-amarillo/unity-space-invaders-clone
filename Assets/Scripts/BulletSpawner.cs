using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;

    [Header("Spawn dynamics")]
    public KeyCode spawnKeyCode;
    public bool spawnAutomatically = false;
    public float spawnInterval = 0.5f;
    public float automaticSpawnDelay = 2f;

    private float spawnElapsedTime = 0f;

    void Start()
    {
        if(this.spawnAutomatically)
        {
            InvokeRepeating("SpawnBullet", this.automaticSpawnDelay, this.spawnInterval);
        }
    }

    void Update()
    {
        if (this.spawnAutomatically)
        {
            return;
        }

        this.spawnElapsedTime += Time.deltaTime;

        if (Input.GetKey(this.spawnKeyCode) && this.spawnElapsedTime >= this.spawnInterval)
        {
            this.spawnElapsedTime = 0f;
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
