using UnityEngine;

public class SwitchAction : MonoBehaviour
{
    public GameObject targetMoveBlock;
    public bool sw = false; // スイッチの状態(true:押されている false:押されていない)
    Material mat;           // マテリアル情報保存用（オブジェクトカラー変更に利用）
    MovingBlock moveBlock;  // 移動床スクリプト保存用

    void Start()
    {
        mat       = GetComponent<Renderer>().material;
        moveBlock = targetMoveBlock.GetComponent<MovingBlock>();
        if (sw)
        {
            mat.color = Color.yellow; // switchオンで黄色
        }
        else
        {
            mat.color = Color.blue; // switchオフで青色
        }
    }

    // 重なり判定
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (sw)
            {
                // スイッチオンの時に再度重なるとswitchオフで移動床停止
                sw = false;
                mat.color = Color.blue;
                moveBlock.Stop();
            }
            else
            {
                // スイッチオフの時に再度重なるとswitchオンで移動床動作
                sw = true;
                mat.color = Color.yellow;
                moveBlock.Move();
            }
        }
    }
}
