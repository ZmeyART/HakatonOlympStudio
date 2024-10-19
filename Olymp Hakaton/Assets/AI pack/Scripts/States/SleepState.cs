using UnityEngine;
using UnityEngine.AI;

public class SleepState : BaseState
{

    public SleepState(NavMeshAgent _npc, IStationStateSwitcher stationSwitcher, GameObject[] points, Animator npcAnim) : base(_npc, stationSwitcher, points, npcAnim)
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
        _npc.gameObject.SetActive(false);
    }

    public override void Start()
    {
        Sleep();
    }

    public override void Stop()
    {
        _npc.gameObject.SetActive(true);
    }

    public override void Talking()
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }

}
