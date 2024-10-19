using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CollisionDetection : MonoBehaviour
{
    private Collider _currentCollision;

    private bool _isOnCrosswalk;


    void Start()
    {
        _currentCollision = GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && _isOnCrosswalk)
        {
            GetComponentInParent<NavMeshAgent>().isStopped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Crosswalk"))
        {
            _currentCollision.transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponentInParent<NavMeshAgent>().speed = 10;
            _isOnCrosswalk = false;
            GetComponentInParent<NavMeshAgent>().isStopped = false;
            
        }
        if (other.gameObject.CompareTag("Car") && _isOnCrosswalk)
        {
            GetComponentInParent<NavMeshAgent>().isStopped = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") && !_isOnCrosswalk)
        {
            if(Random.value <= 0.2f)
            {                
                StartCoroutine(Dialogue(other.gameObject));
            }
        }
        if (other.gameObject.CompareTag("Car") && _isOnCrosswalk)
        {
            GetComponentInParent<NavMeshAgent>().isStopped = true;
        }
        if (other.gameObject.CompareTag("Crosswalk"))
        {
            _isOnCrosswalk = true;
            GetComponentInParent<NavMeshAgent>().speed = 15;
            _currentCollision.transform.localScale = new Vector3(15f, 1f, 2f);
        }
    }

    private IEnumerator Dialogue(GameObject otherNPC)
    {
        otherNPC.GetComponent<StationBehaviour>().SwitchState<TalkingState>();
        GetComponentInParent<StationBehaviour>().SwitchState<TalkingState>();
        yield return new WaitForSeconds(3f);
        otherNPC.GetComponent<StationBehaviour>().SwitchState<WalkingState>();
        GetComponentInParent<StationBehaviour>().SwitchState<WalkingState>();
    }

}
