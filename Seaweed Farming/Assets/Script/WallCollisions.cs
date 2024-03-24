using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WallCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is a player's hand or controller
        if (collision.gameObject.CompareTag("PlayerHand"))
        {
            // Prevent further movement
            // You can also provide feedback to the player
        }
    }
}

