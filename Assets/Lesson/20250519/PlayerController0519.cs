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

        // 1•bŠÔ‚É–ñyspeedzm/s ‚Ì‘¬“x‚ÅˆÚ“®‚³‚¹‚éŒvZ®
        transform.position += dir * speed * Time.deltaTime;
        Vector3 pos = transform.position;
        
        // s“®§ŒÀ
        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f);
        transform.position = pos;
    }
}
