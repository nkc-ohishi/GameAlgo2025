using UnityEngine;

public class BallGenerator0519 : MonoBehaviour
{
    public GameObject ballPre;
    float span = 1f;
    float delta = 0;

    void Start()
    {
        span = 1f;
        delta = 0;
    }

    void Update()
    {
        if (GameDirector0519.gameFlg != 0) return;

        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            GameObject obj = Instantiate(ballPre);
            float px = Random.Range(-8, 9);
            obj.transform.position = new Vector3(px, 7, 0);
        }

        if(Time.frameCount % 150 == 0)
        {
            span -= 0.05f;
            span = Mathf.Max(span, 0.1f);
        }
        
    }
}
