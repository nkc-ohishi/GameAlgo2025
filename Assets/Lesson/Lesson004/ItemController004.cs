using UnityEngine;

public class ItemController004 : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(0, 0, 90f);
    }

    void Update()
    {
        transform.Rotate(2.5f, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameDirector004.score += 100;
            Destroy(gameObject);
        }
    }
}
