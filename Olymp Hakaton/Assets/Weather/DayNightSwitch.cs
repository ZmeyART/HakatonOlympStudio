using System.Resources;
using UnityEngine;

public class DayNightSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject _light;

    private GameObject[] _homePoints;

    private float _timer;
    private bool _isNight = false;

    private void Start()
    {
        _homePoints = GameObject.FindGameObjectsWithTag("HomePoint");
    }

    private void SetPointsActive(bool active)
    {
        foreach (var point in _homePoints)
        {
            point.GetComponent<Collider>().enabled = active;
        }
    }
    public void OnCLick()
    {
        SetPointsActive(true);
        _isNight = true;
        _light.SetActive(false);
        NPCController.Instance().SwitchStatesForAll<WalkingHomeState>();
        print("Walking Home");
    }

    private void Update()
    {
        if (_isNight)
            _timer += Time.deltaTime;
        if(_timer >= 15)
        {
            _isNight = false;
            _light.SetActive(true);
            SetPointsActive(false);
            _timer = 0;
            NPCController.Instance().SwitchStatesForAll<AwakeFromSleepState>();
        }
    }
}
