using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ShellController008 : MonoBehaviour
{
    float deleteTime = 3f;
    PlayerController008 pController;

    void Start()
    {
        pController = GameObject.Find("Player").GetComponent<PlayerController008>();
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
