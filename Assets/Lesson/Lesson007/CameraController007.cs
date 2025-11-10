using UnityEngine;

public class CameraController007 : MonoBehaviour
{
    Transform player;
    Vector3 cameraPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").transform;
        cameraPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos.x = player.position.x;
        transform.position = cameraPos;        
    }
}
