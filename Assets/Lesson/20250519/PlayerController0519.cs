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

        // 1秒間に約【speed】m/s の速度で移動させる計算式
        transform.position += dir * speed * Time.deltaTime;
        Vector3 pos = transform.position;
        
        // 行動制限
        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f);
        transform.position = pos;
    }
}
