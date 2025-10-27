
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    // エディタでパラメータを設定する変数(public指定)
    public float moveX;         // X移動距離
    public float moveY;         // Y移動距離
    public float times;         // 時間
    public float wait;          // 停止時間
    public bool isMoveWhenOn;   // 乗った時に動くフラグ
    public bool isCanMove;      // 動くフラグ

    Vector3 startPos;           // 初期位置
    Vector3 endPos;             // 移動位置
    bool isReverse = false;     // 反転フラグ
    float movep = 0;            // 移動補完値

    void Start()
    {
        startPos = transform.position;                                 // 初期位置
        endPos = new Vector2(startPos.x + moveX, startPos.y + moveY);  // 移動位置
        if (isMoveWhenOn)
        {
            isCanMove = false;  // 乗った時に動くので最初は動かさない
        }
    }

    void Update()
    {
        if (isCanMove)
        {
            float distance = Vector2.Distance(startPos, endPos);        // 移動距離
            float ds = distance / times;                                // １秒の移動距離
            float df = ds * Time.deltaTime;                             // １フレームの移動距離
            movep += df / distance;                                     // 移動補完値
            if (isReverse)
            {
                transform.position = Vector2.Lerp(endPos, startPos, movep);  // 逆移動
            }
            else
            {
                transform.position = Vector2.Lerp(startPos, endPos, movep);  // 正移動
            }
            if (movep >= 1.0f)
            {
                movep = 0.0f;                   // 移動補完値リセット
                isReverse = !isReverse;         // 移動を逆転
                isCanMove = false;              // 移動停止
                if (isMoveWhenOn == false)
                {
                    // 乗った時に動くフラグOFF
                    Invoke("Move", wait);   // 移動フラグを立てる遅延実行
                }
            }
        }
    }

    // 移動フラグを立てる
    public void Move()
    {
        isCanMove = true;
    }

    // 移動フラグを下ろす
    public void Stop()
    {
        isCanMove = false;
    }

    // 接触開始
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //接触したのがプレイヤーなら移動床の子にする
            collision.transform.SetParent(transform);
            if (isMoveWhenOn)
            {
                // 乗った時に動くフラグON
                isCanMove = true;   // 移動フラグを立てる
            }
        }
    }
    // 接触終了
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 接触終了したのがプレイヤーなら移動床の子から外す
            collision.transform.SetParent(null);
        }
    }

    // デバッグ用移動範囲表示（シーンビューで表示）
    void OnDrawGizmosSelected()
    {
        Vector2 fromPos;
        if (startPos == Vector3.zero)
        {
            fromPos = transform.position;
        }
        else
        {
            fromPos = startPos;
        }
        // 移動線
        Gizmos.DrawLine(fromPos, new Vector2(fromPos.x + moveX, fromPos.y + moveY));
        // 移動床のサイズ
        Vector2 size = new Vector2(3, 0.5f);
        // 初期位置
        Gizmos.DrawWireCube(fromPos, size);
        // 移動位置
        Vector2 toPos = new Vector3(fromPos.x + moveX, fromPos.y + moveY);
        Gizmos.DrawWireCube(toPos, size);
    }
}
