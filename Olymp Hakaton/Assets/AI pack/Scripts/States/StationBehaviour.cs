using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class StationBehaviour : MonoBehaviour, IStationStateSwitcher
{
    private NavMeshAgent _agent;
    private GameObject[] _points;
    private GameObject[] _hidePoints;

    private Animator _npcAnim;

    private BaseState _currentState;
    private List<BaseState> _allStates;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _hidePoints = GameObject.FindGameObjectsWithTag("HidePoint");
        _points = GameObject.FindGameObjectsWithTag("WalkingPoint");
        _npcAnim = GetComponent<Animator>();
        _allStates = new List<BaseState>()
        {
            new TalkingState(_agent, this, _points, _npcAnim),
            new AwakeFromSleepState(_agent, this, _points, _npcAnim),
            new WaitingInShelterState(_agent, this, _points, _npcAnim),
            new HideState(_agent, this, _points, _npcAnim,_hidePoints ),
            new SleepState(_agent, this, _points, _npcAnim),
            new WalkingState(_agent, this, _points, _npcAnim),
            new WalkingHomeState(_agent, this, _points, _npcAnim, GameObject.FindGameObjectsWithTag("HomePoint")),
        };
        _currentState = _allStates[5];
        Action();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HidePoint"))
        {
            print("isInShelter");
            SwitchState<WaitingInShelterState>();
            Invoke("WalkFromShelter", 5f);
        }
        if (other.CompareTag("HomePoint"))
        {
            print("is in House");
            SwitchState<SleepState>();
            Invoke("AwakeFromHome", 15f);
        }
    }

    private void AwakeFromHome()
    {
        print("walk out of house");
        SwitchState<AwakeFromSleepState>();
        Invoke("WalkOutOfHouse", 0.1f);
    }

    private void WalkOutOfHouse()
    {
        SwitchState<WalkingState>();
    }

    private void WalkFromShelter()
    {
        print("need to walk");
        SwitchState<WalkingState>();
    }

    public void Action()
    {
        _currentState.Start();
    }
    private void Update()
    {                     
        if (_agent.remainingDistance <= 1)
            Action();
    }
    public void SwitchState<T>() where T : BaseState
    {
        var state = _allStates.FirstOrDefault(s => s is T);
        _currentState.Stop();
        state.Start();
        _currentState = state;   
        Invoke("Action", 1f);
    }
}
