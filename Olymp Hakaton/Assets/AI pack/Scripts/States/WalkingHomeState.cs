using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class WalkingHomeState : BaseState
{
    private GameObject _nearestHomePoint;
    private GameObject[] _homePoints;

    public WalkingHomeState(NavMeshAgent _npc, IStationStateSwitcher stationSwitcher, GameObject[] points, Animator npcAnim, GameObject[] homePoints) : base(_npc, stationSwitcher, points, npcAnim)
    {
        _homePoints = homePoints;
        _nearestHomePoint = _homePoints.OrderBy(point => Vector3.Distance(_npc.gameObject.transform.position, point.transform.position)).First();
    }

    public override void AwakeFromSleep()
    {
        throw new System.NotImplementedException();
    }

    public override void Hide()
    {
        throw new System.NotImplementedException();
    }

    public override void Sleep()
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {        
        _npc.SetDestination(_npc.transform.position);
        WalkToHome();
    }

    public override void Stop()
    {

    }

    public override void Talking()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }

    public override void WaitingInShelter()
    {
        throw new System.NotImplementedException();
    }

    public override void Walk()
    {
        throw new System.NotImplementedException();
    }
    public void WalkToHome()
    {
        _npc.ResetPath();
        _nearestHomePoint = _homePoints.OrderBy(point => Vector3.Distance(_npc.gameObject.transform.position, point.transform.position)).First();
        _npc.isStopped = false;
        _npcAnim.SetBool("isWalking", true);
        _npc.SetDestination(_nearestHomePoint.transform.position);
    }
}
