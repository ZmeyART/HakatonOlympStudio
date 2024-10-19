using UnityEngine;
using UnityEngine.AI;

public class WaitingInShelterState : BaseState
{
    public WaitingInShelterState(NavMeshAgent _npc, IStationStateSwitcher stationSwitcher, GameObject[] points, Animator npcAnim) : base(_npc, stationSwitcher, points, npcAnim)
    {
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
        WaitingInShelter();
    }

    public override void Stop()
    {
        _npc.isStopped = false;
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
        _npcAnim.SetBool("isRunning", false);
        _npc.isStopped = true;
    }
    public override void Walk()
    {
        throw new System.NotImplementedException();
    }

}
