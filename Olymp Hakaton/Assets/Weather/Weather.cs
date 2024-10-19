using UnityEngine;

public class Weather : MonoBehaviour
{
    
    private bool weather;
    private float timer = 0f;

    private void Start()
    {
        Application.targetFrameRate = -1;
    }
    public void OnClick()
    {
        weather = true;
        gameObject.SetActive(true);
        NPCController.Instance().SwitchStatesForAll<HideState>();
    }
    void Update()
    {
        if (weather)
        {
            timer += Time.deltaTime;       
        }
        if(timer >= 10f)
        {
            timer = 0f;
            weather = false;
            gameObject.SetActive(false);
        }
    }
}
