using UnityEngine;
using System.Collections;

public class SimpleCarController : MonoBehaviour
{
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float pauseDuration = 1f;

    private void Start()
    {
        StartCoroutine(MoveCar());
    }

    private IEnumerator MoveCar()
    {
        while (true)
        {
            // ƒвижение от точки A к B
            yield return StartCoroutine(MoveToTarget(pointA.position, pointB.position));
            yield return new WaitForSeconds(pauseDuration);

            // ƒвижение от точки B к A
            yield return StartCoroutine(MoveToTarget(pointB.position, pointA.position));
            yield return new WaitForSeconds(pauseDuration);
        }
    }

    private IEnumerator MoveToTarget(Vector3 from, Vector3 to)
    {
        float journeyLength = Vector3.Distance(from, to);
        float startTime = Time.time;

        while (Vector3.Distance(transform.position, to) > 0.1f)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(from, to, fractionOfJourney);
            yield return null; // ∆дать следующего кадра
        }

        // ”бедитесь, что объект точно на месте
        transform.position = to;
    }
}