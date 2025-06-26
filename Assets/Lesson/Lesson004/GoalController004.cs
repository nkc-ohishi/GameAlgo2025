using UnityEngine;

public class GoalController004 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameDirector004.gameFlg = 2;
        }
    }
}
