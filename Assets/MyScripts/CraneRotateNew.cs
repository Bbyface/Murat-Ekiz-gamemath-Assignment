using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMath.UI;

public class CraneRotateNew : MonoBehaviour
{
    public float rotationSpeed = 5f; // Slow turn to simulate real cranes
    public HoldableButton clockwiseButton;
    public HoldableButton counterclockwiseButton;

    public Transform concrete; // Reference to the Concrete GameObject
    private Vector3 lastConcretePosition;
    private float moveTimer = 0f;
    private float moveCooldown = 1f; // Time in seconds to wait after Concrete moves

    void Start()
    {
        if (concrete != null)
        {
            lastConcretePosition = concrete.position; // Initialize the last position
        }
    }

    void Update()
    {
        // Check if Concrete has moved
        if (concrete != null)
        {
            if (Vector3.Distance(lastConcretePosition, concrete.position) > 0.01f)
            {
                moveTimer = moveCooldown; // Reset the timer
                lastConcretePosition = concrete.position; // Update the last position
            }

            // Count down the timer
            if (moveTimer > 0)
            {
                moveTimer -= Time.deltaTime;
            }
            else
            {
                // Make the Crane face the Concrete GameObject with a 90-degree offset
                Vector3 directionToConcrete = concrete.position - transform.position;
                directionToConcrete.y = 0; // Keep the crane's rotation on the Y-axis

                // Calculate the desired rotation
                Quaternion targetRotation = Quaternion.LookRotation(directionToConcrete) * Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogWarning("Concrete GameObject is not assigned.");
        }

        // Manual rotation with buttons
        if (clockwiseButton != null && clockwiseButton.IsHeldDown)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        if (counterclockwiseButton != null && counterclockwiseButton.IsHeldDown)
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }
}
