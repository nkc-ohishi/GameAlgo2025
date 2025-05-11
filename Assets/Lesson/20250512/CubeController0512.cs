using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CubeController0512 : MonoBehaviour
{
    float speed;
    bool sw;
    Vector3 startPos;
    Vector2 mouseDownPos, mouseUpPos;
    public Text distanceLabel;
    public GameObject goal;

    void Start()
    {
        startPos = transform.position;
        distanceLabel.text = "";
        goal.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        switch(GameDirector0512.mode)
        {
            case 0:
                Update01();
                break;
            case 1:
                Update02();
                break;
            case 2:
                Update03();
                break;
        }

        // 右クリックでリセット
        if (Input.GetMouseButtonDown(1))
        {
            transform.position = startPos;
            speed = 0;
        }

    }

    void Update01()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = 0.1f;
        }

        transform.Translate(speed, 0, 0);
        speed *= 0.98f;
    }

    void Update02()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            mouseUpPos = Input.mousePosition;
            float length = mouseUpPos.x - mouseDownPos.x;

            speed = length / 1000.0f;
        }

        transform.Translate(speed, 0, 0);
        speed *= 0.98f;
    }

    void Update03()
    {
        goal.GetComponent<Renderer>().enabled = true;

        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseUpPos = Input.mousePosition;
            float length = mouseUpPos.x - mouseDownPos.x;

            speed = length / 1000.0f;
        }
        transform.Translate(speed, 0, 0);
        speed *= 0.98f;

        // 距離計算
        float distance = goal.transform.position.x - transform.position.x;

        distanceLabel.text = "Distance:" + distance.ToString("F2") + "m";
    }

}
