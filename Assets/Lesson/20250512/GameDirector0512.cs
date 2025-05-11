using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector0512 : MonoBehaviour
{
    public Text infoTextLabel;
    public static int mode;

    string[] infoText =
    {
        "左クリックで右に移動、徐々に減速\nEnterキーで切り替え",
        "スワイプの長さに応じて速度を変更\nEnterキーで切り替え",
        "Goalまでの距離を計算して表示\nEnterキーで切り替え"
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
            Application.Quit(); //ゲームプレイ終了
        }
    }

}
