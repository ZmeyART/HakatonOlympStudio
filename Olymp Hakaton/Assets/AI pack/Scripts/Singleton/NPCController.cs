using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    private static NPCController enemyController;

    private GameObject[] _NPCs;

    public static NPCController Instance()
    {
        return enemyController;
    }

    public void SwitchStatesForAll<T>() where T : BaseState
    {
        foreach (var npc in _NPCs)
        {
            npc.GetComponent<NavMeshAgent>().ResetPath();
            npc.GetComponent<StationBehaviour>().SwitchState<T>();           
        }
    }

    private void Awake()
    {
        _NPCs = GameObject.FindGameObjectsWithTag("NPC");
        if (enemyController == null)
        {
            enemyController = this;
        }           
    }
   
}
