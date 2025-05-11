using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector0512 : MonoBehaviour
{
    public Text infoTextLabel;
    public static int mode;

    string[] infoText =
    {
        "���N���b�N�ŉE�Ɉړ��A���X�Ɍ���\nEnter�L�[�Ő؂�ւ�",
        "�X���C�v�̒����ɉ����đ��x��ύX\nEnter�L�[�Ő؂�ւ�",
        "Goal�܂ł̋������v�Z���ĕ\��\nEnter�L�[�Ő؂�ւ�"
    };

    void Start()
    {
        Application.targetFrameRate = 60; 

        infoTextLabel.text = infoText[mode];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            mode = (mode + 1) % 3;
            infoTextLabel.text = infoText[mode];
            SceneManager.LoadScene(0);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //�Q�[���v���C�I��
        }
    }

}
