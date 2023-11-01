using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public Animator anim;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool dead;


    private void Start()
    {
        anim = GetComponent<Animator>();
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            if (health > 0)
            {
                health--;

                if (anim != null)
                {
                    anim.SetTrigger("hurt");
                }

                if (health == 0)
                {
                    dead = true;
                    GetComponent<PlayerMovement>().enabled = false;
                    GetComponent<PlayerCombat>().enabled = false;

                    if (anim != null)
                    {
                        anim.SetTrigger("die");
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            if (health > 0)
            {
                health--;

                if (anim != null)
                {
                    anim.SetTrigger("hurt");
                }

                if (health == 0)
                {
                    dead = true;
                    GetComponent<PlayerMovement>().enabled = false;
                    GetComponent<PlayerCombat>().enabled = false;

                    if (anim != null)
                    {
                        anim.SetTrigger("die");
                    }
                }
            }
        }
    }



    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}