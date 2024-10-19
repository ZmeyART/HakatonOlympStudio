using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState
{
    protected readonly GameObject[] _points;
    protected readonly NavMeshAgent _npc;
    protected readonly IStationStateSwitcher _stationSwitcher;
    protected readonly Animator _npcAnim;

    protected BaseState(NavMeshAgent _npc, IStationStateSwitcher stationSwitcher, GameObject[] points, Animator npcAnim)
    {
        this._npc = _npc;
        _stationSwitcher = stationSwitcher;
        _points = points;
        _npcAnim = npcAnim;
    }

    public abstract void Start();

    public abstract void Stop();

    public abstract void Walk();

    public abstract void Hide();

    public abstract void WaitingInShelter();

    public abstract void Sleep();

    public abstract void AwakeFromSleep();

    public abstract void Talking();

    public abstract void Update();


}

public interface IStationStateSwitcher
{
    void SwitchState<T>() where T : BaseState;
}
