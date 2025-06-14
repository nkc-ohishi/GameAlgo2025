using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController004 : MonoBehaviour
{
    float speed = 5;            // 左右移動スピード
    float deadLine = -5f;       // 失敗ライン
    float jumpPower = 1000;     // ジャンプ力
    Rigidbody rb;               // Rigidbodyコンポーネント保存変数
    Vector3 inputDir = Vector3.zero; // キー入力方向
    private bool isGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbodyコンポーネントを保存
    }

    void Update()
    {
        inputDir.x = Input.GetAxisRaw("Horizontal");

        // 左右移動(ヴェロシティの値を直接変更して左右移動)
        Vector3 vel = rb.linearVelocity;
        vel.x = inputDir.x * speed;
        rb.linearVelocity = vel;

        // 下にRayを発射（現在位置から下方向に向けて）
        Vector3 rayPos = transform.position;
        Ray ray = new Ray(rayPos, Vector3.down);
        isGround = Physics.Raycast(ray, 0.5f);                  // Rayが地面に当たったかを判定
        Debug.DrawRay(rayPos, Vector3.down*0.5f, Color.red);    // SceneビューでRayを可視化

        // Zキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Z) && isGround)
        {
            rb.AddForce(transform.up * jumpPower);
        }

        // 落ちたらリプレイ
        if (transform.position.y <= deadLine)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //ゲームプレイ終了
        }

    }

}
