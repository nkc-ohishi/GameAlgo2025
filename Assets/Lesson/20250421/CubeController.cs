//------------------------------------------------------------------------------------------
// �ȖځF�Q�[���A���S���Y��
// �T�v�F���߂ẴX�N���v�g
// ���t�F2025.04.21 Ken.D.Ohishi
//------------------------------------------------------------------------------------------
using UnityEngine;

public class CubeController : MonoBehaviour
{
    float rotSpeed;

    void Start()
    {
        Debug.Log("CubeController�X�N���v�g�����s����܂����B");

        Application.targetFrameRate = 60; // 60FPS 

        rotSpeed = 0;

    }

    void Update()
    {
        Debug.Log("UpDate���\�b�h�����s���܂���");

        // �P�t���[���łP�O�x��]
        // transform.Rotate(0, 0, 10);

        // ���N���b�N����邲�ƂɂP�O�x��]
        //if(Input.GetMouseButtonDown(0))
        //{
        //    transform.Rotate(0, 0, 10);
        //}

        // ���N���b�N���ꂽ���]�X�^�[�g(�ϐ����g�p)
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 10;
        }
        // �E�N���b�N�ŉ�]�X�g�b�v
        if (Input.GetMouseButtonDown(1))
        {
            rotSpeed = 0;
        }
        transform.Rotate(0, 0, rotSpeed);

    }
}
