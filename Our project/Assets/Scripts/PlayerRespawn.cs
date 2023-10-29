using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; // Set this in the Inspector to the desired respawn point
    private Animator playerAnimator;

    public void RespawnPlayer()
    {
        if (respawnPoint != null)
        {
            // Move the player to the respawn point
            transform.position = respawnPoint.position;

            // Reset player health and any other relevant parameters
            Health playerHealth = GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.health = playerHealth.numOfHearts;
                playerHealth.dead = false;
            }
            else
            {
                Debug.LogError("Health script not found on the player!");
            }

            // If your player uses an Animator, set the "Respawn" trigger
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("Respawn");
            }

            // Enable player movement and combat scripts
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<PlayerCombat>().enabled = true;
        }
    }
}

