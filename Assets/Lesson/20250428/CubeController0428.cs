using System.Collections;
using UnityEngine;

public class CubeController0428 : MonoBehaviour
{
    float rotSpeed;
    bool sw;

    void Start()
    {
        
    }

    void Update()
    {
        switch(GameDirector0428.mode)
        {
            case 0:
                Update01();
                break;
            case 1:
                Update02();
                break;
            case 2:
                Update03();
                break;
        }

    }

    // 左クリックで回転、右クリックで停止
    void Update01()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 10;
        }
        if (Input.GetMouseButtonDown(1))
        {
            rotSpeed = 0;
        }

        transform.Rotate(0, 0, rotSpeed);
    }

    // 左クリックで回転、徐々に回転を遅くする
    void Update02()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 10;
        }
        transform.Rotate(0, 0, rotSpeed);
        rotSpeed *= 0.98f;

    }

    // 左クリックで回転、停止を繰り返す
    void Update03()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sw = !sw;
            rotSpeed = (sw) ? 10 : 0;
        }

        if (Input.GetMouseButtonDown(1))
        {
            transform.localEulerAngles = Vector3.zero;
        }

        transform.Rotate(0, 0, rotSpeed);

    }

}
