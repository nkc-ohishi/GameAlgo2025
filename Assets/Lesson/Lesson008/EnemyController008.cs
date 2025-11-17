using UnityEngine;

public class EnemyController008 : MonoBehaviour
{
    float walkSpeed = 5f;            // 歩行スピード
    float shellSpeed = 20f;          // 殻が転がるスピード
    Rigidbody rb;                    // リジッドボディコンポーネント
    PlayerController008 pController; // プレーヤーコントローラー取得
    float passedTimes = 0;
    float delayTime   = 5;

    private enum State
    {
        Walking,    // 通常（歩き）
        Shell,      // 殻（静止）
        MovingShell // 殻すべり（高速移動）
    }
    private State currentState = State.Walking; // 初期状態は通常（歩き）
    private Vector3 moveDir = Vector3.right;    // 最初の移動方向は右

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // リジッドボディコンポーネント保存

        pController = GameObject.Find("Player").GetComponent<PlayerController008>();
    }

    void Update()
    {
        // 殻状態になってから５秒で歩き状態に戻る
        if (currentState == State.Shell)
        {
            passedTimes += Time.deltaTime;
            if (passedTimes > delayTime)
            {
                currentState = State.Walking;
                GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case State.Walking:                     // 通常（歩き）
                Walk();
                break;
            case State.Shell:                       // 殻（静止）
                rb.linearVelocity = Vector3.zero;
                break;
            case State.MovingShell:                 // 殻滑り（高速移動）
                rb.linearVelocity = moveDir * shellSpeed;
                break;
        }
    }

    // 通常（歩き）
    void Walk()
    {
        rb.linearVelocity = new Vector3(moveDir.x * walkSpeed, rb.linearVelocity.y, 0);
    }

    // 方向転換
    void FlipDirection()
    {
        // 移動方向を反転
        moveDir = -moveDir;
    }

    // 殻状態に変化
    void ChangeToShell()
    {
        passedTimes = 0;                                        // 経過時間を０クリア
        currentState = State.Shell;                             // 状態を殻にする
        rb.linearVelocity = Vector3.zero;                       // 動きを止める
        GetComponent<Renderer>().material.color = Color.blue;   // 青色にする
    }

    // 殻を蹴る
    void KickShell(Vector3 hitterPos)
    {
        // 左右どちらから押されたかを計算
        Vector3 dir = Vector3.zero;
        dir.x = transform.position.x - hitterPos.x;
        dir.Normalize();

        // 押された方向を移動方向に設定
        moveDir = dir;

        // 状態を殻すべり（高速移動）に変更
        currentState = State.MovingShell;

        // 色を赤にする
        GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // プレーヤーと衝突
        if (collision.collider.tag == "Player")
        {
            // 接触方向を取得
            Vector3 contactDir = collision.contacts[0].point - transform.position;

            // 上から衝突
            if (contactDir.y > 0.51f)
            {
                // 歩き or 殻すべり状態なら殻状態にする
                if (currentState == State.Walking || currentState == State.MovingShell)
                {
                    ChangeToShell();
                }
            }
            else if (currentState == State.Shell)
            {
                // 殻状態＆横から接触
                KickShell(collision.transform.position);
            }
        }

        // 壁に当たったら反転
        if (collision.collider.tag == "Wall")
        {
            FlipDirection();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 contactDir = collision.contacts[0].point - transform.position;

        // 歩き or 殻すべり状態の時に横から当たるとHPを減らし続ける
        if (collision.collider.tag == "Player" && contactDir.y < 0.51f)
        {
            if (currentState == State.Walking)
            {
                pController.Damage(10);
            }
            else if (currentState == State.MovingShell)
            {
                pController.Damage(100);
            }
        }
    }
}