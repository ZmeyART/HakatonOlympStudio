using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class HideState : BaseState
{
    private GameObject _nearestHidePoint;
    private GameObject[] _hidePoints;

    public HideState(NavMeshAgent _npc, IStationStateSwitcher stationSwitcher, GameObject[] points, Animator npcAnim, GameObject[] hidePoints) : base(_npc, stationSwitcher, points, npcAnim)
    {
        _hidePoints = hidePoints;
        _nearestHidePoint = _hidePoints.OrderBy(point => Vector3.Distance(_npc.gameObject.transform.position, point.transform.position)).First();
    }

    public override void AwakeFromSleep()
    {
        throw new System.NotImplementedException();
    }

    public override void Hide()
    {
        _npcAnim.SetBool("isRunning", true);
        _npc.speed = 20;
        _npc.SetDestination(_nearestHidePoint.transform.position);
        _npc.isStopped = false;
    }

    public override void Sleep()
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {
        _npc.ResetPath();
        _npcAnim.SetBool("isRunning", true);
        _npcAnim.SetBool("isWalking", false);
        _nearestHidePoint = _hidePoints.OrderBy(point => Vector3.Distance(_npc.gameObject.transform.position, point.transform.position)).First();
        Hide();
    }

    public override void Stop()
    {
        _npcAnim.SetBool("isRunning", false);
        _npcAnim.SetBool("isWalking", true);
        _npc.speed = 10;
        _npc.isStopped = true;
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
