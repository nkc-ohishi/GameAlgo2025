using UnityEngine;
using UnityEngine.UI;

public class GameDirector0428 : MonoBehaviour
{
    public Text infoTextLabel;
    public static int mode;

    string[] infoText =
    {
        "左クリックで回転、右クリックで停止\nEnterキーで切り替え",
        "左クリックで回転、徐々に回転を遅くする\nEnterキーで切り替え",
        "左クリックで回転、停止を繰り返す\nEnterキーで切り替え"
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
            Application.Quit(); //ゲームプレイ終了
        }
    }

}
