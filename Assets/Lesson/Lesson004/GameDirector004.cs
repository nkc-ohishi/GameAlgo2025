using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector004 : MonoBehaviour
{
    public Text durationLabel;
    public Text titleLabel;
    public static int gameFlg = 0;
    float duration;

    void Start()
    {
        Application.targetFrameRate = 60;

        gameFlg = 99;
        duration = 0;
        titleLabel.text = "�T�C�h�r���[�Q�[���V�X�e��\n\nEnter�L�[�ŃX�^�[�g";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //�Q�[���v���C�I��
        }


        if (gameFlg == 99)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameFlg = 0;
                titleLabel.text = "";
            }
            return;
        }

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
    }
}
