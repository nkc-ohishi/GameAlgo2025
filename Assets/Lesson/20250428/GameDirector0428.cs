using UnityEngine;
using UnityEngine.UI;

public class GameDirector0428 : MonoBehaviour
{
    public Text infoTextLabel;
    public static int mode;

    string[] infoText =
    {
        "���N���b�N�ŉ�]�A�E�N���b�N�Œ�~\nEnter�L�[�Ő؂�ւ�",
        "���N���b�N�ŉ�]�A���X�ɉ�]��x������\nEnter�L�[�Ő؂�ւ�",
        "���N���b�N�ŉ�]�A��~���J��Ԃ�\nEnter�L�[�Ő؂�ւ�"
    };

    void Start()
    {
        Application.targetFrameRate = 60;

        infoTextLabel.text = infoText[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            mode = (mode + 1) % 3;
            infoTextLabel.text = infoText[mode];
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //�Q�[���v���C�I��
        }
    }

}
