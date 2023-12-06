using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    public float speed = 5f;

    private bool movingRight = true;

    void Update()
    {
        // Calculate the direction based on whether the enemy is moving right or left
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;

        // Move the enemy
        transform.Translate(direction * speed * Time.deltaTime);

       // Check for obstacles using Raycast on the right side
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.2f);

        // Check for obstacles using Raycast on the left side
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.2f);

        Debug.DrawRay(transform.position, Vector2.right * 0.2f, Color.red);
        Debug.DrawRay(transform.position, Vector2.left * 0.2f, Color.blue);       


        // If an obstacle is hit on either side with the "Solver" tag, change direction
        if ((hitRight.collider != null && hitRight.collider.CompareTag("solver")) ||
            (hitLeft.collider != null && hitLeft.collider.CompareTag("solver")))
        {
            movingRight = !movingRight;

            Debug.Log("collided");
        }

        
    }

   
}
