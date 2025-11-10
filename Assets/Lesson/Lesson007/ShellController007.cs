using UnityEngine;

public class ShellController007 : MonoBehaviour
{
    float deleteTime = 3f;

    void Start()
    {
        Destroy(gameObject, deleteTime);        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
    }
}
