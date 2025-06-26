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
        titleLabel.text = "サイドビューゲームシステム\n\nEnterキーでスタート";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //ゲームプレイ終了
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
            titleLabel.text = "GAME OVER\nEnterキーでタイトルへ戻る";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameFlg = 0;
                SceneManager.LoadScene(0);
            }
            return;
        }

        if (gameFlg == 2)
        {
            titleLabel.text = "GAME CLEAR\nEnterキーでタイトルへ戻る";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameFlg = 0;
                SceneManager.LoadScene(0);
            }
            return;
        }

        // 経過時間表示
        duration += Time.deltaTime;
        durationLabel.text = "経過時間：" + duration.ToString("0000.00") + "秒";
    }
}
