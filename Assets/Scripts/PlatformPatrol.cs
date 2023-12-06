using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour
{
    [SerializeField]private float speed; // Adjust the speed as needed
    private bool movingRight = true;
    [SerializeField]private float leftBound;
    [SerializeField]private float rightBound;

    void Update()
    {
        // Move the enemy horizontally
        transform.Translate(Vector2.right * speed * (movingRight ? 1 : -1) * Time.deltaTime);

        // Check if the enemy has reached the right bound
        if (transform.position.x > rightBound)
        {
            // Reverse the direction
            movingRight = false;
        }

        // Check if the enemy has reached the left bound
        if (transform.position.x < leftBound)
        {
            // Reverse the direction
            movingRight = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the collision is with a GameObject having PlayerController script
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            // Move the player along with the platform
            collision.transform.Translate(Vector2.right * speed * (movingRight ? 1 : -1) * Time.deltaTime);

        }
    }
}
