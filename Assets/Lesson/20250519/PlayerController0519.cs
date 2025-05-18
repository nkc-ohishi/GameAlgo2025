using UnityEngine;

public class PlayerController0519 : MonoBehaviour
{
    float speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameDirector0519.gameFlg == 1) return;

        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxisRaw("Horizontal");

        transform.position += dir * speed * Time.deltaTime;
        Vector3 pos = transform.position;
        
        // çsìÆêßå¿
        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f);
        transform.position = pos;
    }
}
