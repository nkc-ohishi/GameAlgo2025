using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector004 : MonoBehaviour
{
    public Text durationLabel;      // �o�ߎ��ԗpUI-TEXT
    public Text titleLabel;         // �^�C�g���pUI-TEXT
    public Text scoreLabel;         // �X�R�A�pUI-TEXT
    public static int gameFlg = 0;  // �Q�[���̏�ԃt���O
    public static int score   = 0;  // �X�R�A
    float duration;                 // �o�ߎ��Ԍv���p�ϐ�

    void Start()
    {
        Application.targetFrameRate = 60;
        gameFlg = 99;               // �Q�[���̏�ԁ@�����l99
        score   = 0;                // �X�R�A�̏�����
        duration = 0;               // �o�ߎ��Ԍv���p�ϐ�������

        // �^�C�g������
        titleLabel.text = "�T�C�h�r���[�Q�[���V�X�e��\r\n���E�ړ��AZ�W�����v\r\nEnter�L�[�ŃX�^�[�g";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //�Q�[���v���C�I��
        }

        // �Q�[���V�[�����Đ����ꂽ���̏��
        if (gameFlg == 99)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameFlg = 0;
                titleLabel.text = "";
            }
            return;
        }

        // �Q�[���I�[�o�[�ɂȂ������̏��
        if (gameFlg == 1)
        {
            titleLabel.text = "GAME OVER\nEnter�L�[�Ń^�C�g���֖߂�";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameFlg = 0;
                SceneManager.LoadScene(0);
            }
            return;
        }

        // �Q�[���N���A�[�ɂȂ������̏��
        if (gameFlg == 2)
        {
            titleLabel.text = "GAME CLEAR\nEnter�L�[�Ń^�C�g���֖߂�";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameFlg = 0;
                SceneManager.LoadScene(0);
            }
            return;
        }

        // �o�ߎ��ԕ\��
        duration += Time.deltaTime;
        durationLabel.text = "�o�ߎ��ԁF" + duration.ToString("0000.00") + "�b";

        // �X�R�A�\��
        scoreLabel.text = "SCORE " + score.ToString("000000");
    }
}
