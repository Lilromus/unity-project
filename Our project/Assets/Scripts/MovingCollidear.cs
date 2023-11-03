using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCollidear : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    public float duration = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        startPosition = boxCollider.offset;
        targetPosition = new Vector2(0.002064699f, -0.2435028f);

        StartCoroutine(MoveColliderAfterDelay());
    }

    private IEnumerator MoveColliderAfterDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                boxCollider.offset = Vector2.Lerp(startPosition, targetPosition, elapsedTime / duration);

                elapsedTime += Time.deltaTime;

                yield return null;

            }

            boxCollider.offset = targetPosition;

            Vector2 temp = startPosition;
            startPosition = targetPosition;
            targetPosition = temp;

            // Update is called once per frame
        }

    }
}
