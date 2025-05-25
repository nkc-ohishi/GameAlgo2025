using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector0519 : MonoBehaviour
{
    public Text hpLabel;
    public Text titleLabel;
    public static int hp = 100;
    public static int gameFlg = 0;

    void Start()
    {
        Application.targetFrameRate = 60;

        gameFlg = 99;
        hp = 100;
        titleLabel.text = "左右キーで動かしてボールをよけるゲーム\nEnterキーでスタート";
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
            titleLabel.text = "GAME OVER";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameFlg = 0;
                SceneManager.LoadScene(0);
            }
            return;
        }

        if(hp < 0)
        {
            gameFlg = 1;
            hp = 0;
        }

        hpLabel.text = "HP = " + hp.ToString("D5");
    }
}
