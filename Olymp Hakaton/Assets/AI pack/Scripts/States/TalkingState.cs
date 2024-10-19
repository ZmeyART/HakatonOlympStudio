using UnityEngine;
using UnityEngine.AI;

public class TalkingState : BaseState
{
    public TalkingState(NavMeshAgent _npc, IStationStateSwitcher stationSwitcher, GameObject[] points, Animator npcAnim) : base(_npc, stationSwitcher, points, npcAnim)
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
        Talking();
    }

    public override void Stop()
    {
        _npcAnim.SetBool("isTalking", false);
        _npc.isStopped = false;
    }

    public override void Talking()
    {
        _npc.isStopped = true;
        _npcAnim.SetBool("isTalking", true);
        _npcAnim.SetBool("isWalking", false);
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
