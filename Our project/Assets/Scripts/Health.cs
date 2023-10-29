using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    private Animator anim;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool dead;
    public PlayerRespawn playerRespawn;
    public Transform respawnPoint; // Set this in the Inspector to the desired respawn point
    private Animator playerAnimator;


    private void Start()
    {
        anim = GetComponent<Animator>();
        playerRespawn = GetComponent<PlayerRespawn>();
    }

    private void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (health > 0)
            {
                health--;

                if (anim != null)
                {
                    anim.SetTrigger("hurt");
                }

                if (health == 0 && !dead)
                {
                    dead = true;

                    if (anim != null)
                    {
                        anim.SetTrigger("die");
                    }

                    // If you want to respawn immediately after the death animation,
                    // you can call the respawn logic here or use Invoke to delay it.
                    float respawnDelay = 2.0f;
                    Invoke("RespawnPlayer", respawnDelay);
                }
            }
        }
    }

    private void RespawnPlayer()
    {
        if (respawnPoint != null)
        {
            // Move the player to the respawn point
            transform.position = respawnPoint.position;

            // Reset player health and any other relevant parameters
            health = numOfHearts; // Corrected this line
            dead = false;

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