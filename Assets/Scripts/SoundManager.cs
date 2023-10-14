using UnityEngine;

public class SoundManager : MonoBehaviour
{
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
