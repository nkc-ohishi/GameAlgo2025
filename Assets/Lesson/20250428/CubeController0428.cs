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

    // ���N���b�N�ŉ�]�A�E�N���b�N�Œ�~
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

    // ���N���b�N�ŉ�]�A���X�ɉ�]��x������
    void Update02()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 10;
        }
        transform.Rotate(0, 0, rotSpeed);
        rotSpeed *= 0.98f;

    }

    // ���N���b�N�ŉ�]�A��~���J��Ԃ�
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
