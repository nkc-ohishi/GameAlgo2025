//------------------------------------------------------------------------------------------
// 科目：ゲームアルゴリズム
// 概要：初めてのスクリプト
// 日付：2025.04.21 Ken.D.Ohishi
//------------------------------------------------------------------------------------------
using UnityEngine;

public class CubeController : MonoBehaviour
{
    float rotSpeed;

    void Start()
    {
        Debug.Log("CubeControllerスクリプトが実行されました。");

        Application.targetFrameRate = 60; // 60FPS 

        rotSpeed = 0;

    }

    void Update()
    {
        Debug.Log("UpDateメソッドを実行しました");

        // １フレームで１０度回転
        // transform.Rotate(0, 0, 10);

        // 左クリックされるごとに１０度回転
        //if(Input.GetMouseButtonDown(0))
        //{
        //    transform.Rotate(0, 0, 10);
        //}

        // 左クリックされたら回転スタート(変数を使用)
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 10;
        }
        // 右クリックで回転ストップ
        if (Input.GetMouseButtonDown(1))
        {
            rotSpeed = 0;
        }
        transform.Rotate(0, 0, rotSpeed);

    }
}
