using UnityEngine;
using System.Collections;

public class TrailMover : MonoBehaviour
{
    public float moveDuration = 0.8f; 

    public void Move(Vector2 startPosition, Vector2 endPosition)
    {
        StartCoroutine(MoveTrail(startPosition, endPosition));
    }

    private IEnumerator MoveTrail(Vector2 startPosition, Vector2 endPosition)
    {
        float elapsedTime = 0f;
        transform.position = startPosition;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector2.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
        Destroy(gameObject);
    }
}