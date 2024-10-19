using UnityEngine;
using UnityEngine.AI;

public class AwakeFromSleepState : BaseState
{
    public AwakeFromSleepState(NavMeshAgent _npc, IStationStateSwitcher stationSwitcher, GameObject[] points, Animator npcAnim) : base(_npc, stationSwitcher, points, npcAnim)
    {
    }

    public override void AwakeFromSleep()
    {
        _npcAnim.SetBool("isWalking", true);
        _npc.isStopped = false;
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
        AwakeFromSleep();
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
}
