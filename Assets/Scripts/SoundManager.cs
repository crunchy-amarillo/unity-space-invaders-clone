using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sounds")]
    public AudioClip enemyDestroySound;

    private AudioSource audioSource;

    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void PlayEnemyDestroySound()
    {
        this.audioSource.PlayOneShot(this.enemyDestroySound);
    }
}
