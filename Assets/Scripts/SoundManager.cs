using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sounds")]
    public AudioClip playerBulletSound;

    private AudioSource audioSource;

    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void PlayPlayerBulletSound()
    {
        this.audioSource.PlayOneShot(this.playerBulletSound);
    }
}
