using UnityEngine;
using UnityEngine.AI;

public class WalkingState : BaseState
{
    private GameObject currentTargetPoint;

    public WalkingState(NavMeshAgent _npc, IStationStateSwitcher stationSwitcher, GameObject[] points, Animator npcAnim) : base(_npc, stationSwitcher, points, npcAnim)
    {
        
    }
    public override void AwakeFromSleep()
    {
        throw new System.NotImplementedException();
    }

    public override void Hide()
    {
        throw new System.Exception();
    }

    public override void Sleep()
    {
        throw new System.Exception();
    }

    public override void Start()
    {
        _npcAnim.SetBool("isWalking", true);
        _npc.isStopped = false;
        Walk();
    }

    public override void Stop()
    {
        _npc.ResetPath();
    }

    public override void Talking()
    {
        throw new System.Exception();
    }

    public override void Update()
    {
        
    }

    public override void WaitingInShelter()
    {
        throw new System.NotImplementedException();
    }

    public override void Walk()
    {
        currentTargetPoint = _points[Random.Range(0, _points.Length)];
        _npc.SetDestination(currentTargetPoint.transform.position);
    }

}
