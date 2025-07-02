using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector004 : MonoBehaviour
{
    public Text durationLabel;      // 経過時間用UI-TEXT
    public Text titleLabel;         // タイトル用UI-TEXT
    public Text scoreLabel;         // スコア用UI-TEXT
    public static int gameFlg = 0;  // ゲームの状態フラグ
    public static int score   = 0;  // スコア
    float duration;                 // 経過時間計測用変数

    void Start()
    {
        Application.targetFrameRate = 60;
        gameFlg = 99;               // ゲームの状態　初期値99
        score   = 0;                // スコアの初期化
        duration = 0;               // 経過時間計測用変数初期化

        // タイトル文字
        titleLabel.text = "サイドビューゲームシステム\r\n左右移動、Zジャンプ\r\nEnterキーでスタート";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //ゲームプレイ終了
        }

        // ゲームシーンが再生された時の状態
        if (gameFlg == 99)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameFlg = 0;
                titleLabel.text = "";
            }
            return;
        }

        // ゲームオーバーになった時の状態
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

        // ゲームクリアーになった時の状態
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

        // スコア表示
        scoreLabel.text = "SCORE " + score.ToString("000000");
    }
}
