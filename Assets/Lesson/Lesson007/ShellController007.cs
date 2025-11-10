using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ShellController007 : MonoBehaviour
{
    float deleteTime = 3f;
    PlayerController007 pController;

    void Start()
    {
        pController = GameObject.Find("Player").GetComponent<PlayerController007>();
        Destroy(gameObject, deleteTime);        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);

        if(other.tag == "Player")
        {
            pController.Damage(Random.Range(200, 500));
            Destroy(gameObject);
        }
        if(other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
