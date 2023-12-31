using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        float horizontalInput = 0;
        float verticalInput = 0;

        if (SystemInfo.supportsAccelerometer) {
            horizontalInput = Input.acceleration.x;
            verticalInput = Input.acceleration.y;
        }

        if (!SystemInfo.supportsAccelerometer || Input.anyKey)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }

        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        this.playerRigidbody.velocity = direction.normalized * speed;
        this.playerAnimator.SetBool("isMovingLeft", horizontalInput < 0);
        this.playerAnimator.SetBool("isMovingRight", horizontalInput > 0);
        this.playerAnimator.SetBool("isMovingForward", verticalInput > 0);
    }

    private void OnDisable()
    {
        SceneManager.LoadScene(0);
    }
}
