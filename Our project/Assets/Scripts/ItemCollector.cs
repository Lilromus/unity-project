using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int apples = 0;

    [SerializeField] private AudioSource CollectSFX;

    [SerializeField] private TextMeshProUGUI appleText;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            CollectSFX.Play();
            apples++;
            appleText.text = "Apples: " + apples + "/9";
        }
    }
}
