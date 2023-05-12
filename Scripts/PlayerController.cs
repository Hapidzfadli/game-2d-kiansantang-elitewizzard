using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float smoothing = 0.1f;

    private Vector2 velocity = Vector2.zero;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Ambil animator component dari game object
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 targetVelocity = new Vector2(horizontalInput * speed, verticalInput * speed);
        velocity = Vector2.Lerp(velocity, targetVelocity, smoothing);

        Vector2 position = transform.position;
        position += velocity * Time.deltaTime;
        transform.position = position;

        if (Mathf.Abs(horizontalInput) > 0) // Cek jika player sedang bergerak
        {
            animator.SetFloat("speed", 1f); // Set animasi menjadi player_run
        }
        else
        {
            animator.SetFloat("speed", 0f); // Set animasi menjadi player_idle
        }
    }
}
