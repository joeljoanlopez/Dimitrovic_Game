using UnityEngine;
using System.Collections;

public class TrailMover : MonoBehaviour
{
    public float moveDuration = 0.2f; 

    public void Move(Vector2 startPosition, Vector2 endPosition)
    {
        StartCoroutine(MoveTrail(startPosition, endPosition));
    }

    private IEnumerator MoveTrail(Vector2 startPosition, Vector2 endPosition)
    {
        float distance = Vector2.Distance(startPosition, endPosition);
        float duration = Mathf.Min(moveDuration, distance / 10f);
        float elapsedTime = 0f;
        if (duration > 1f) Debug.LogWarning("If you want the trail to work reliably, the duration should be less than 1 second");

        transform.position = startPosition;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.position = Vector2.Lerp(startPosition, endPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
        Destroy(gameObject);
    }
}