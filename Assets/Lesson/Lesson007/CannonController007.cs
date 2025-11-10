using UnityEngine;
using UnityEngine.Rendering;

public class CannonController007 : MonoBehaviour
{
    public GameObject objPre;
    float delayTime = 3f;
    float fireSpeed = 30f;
    float length = 5f;

    Transform player;
    Transform gateTrans;
    float passedTimes = 0;

    bool CheckLength(Vector3 targetPos)
    {
        float d = Vector3.Distance(transform.position, targetPos);
        return (length >= d);
    }

    void Start()
    {
        gateTrans = transform.Find("Gate");
        player    = GameObject.Find("Player").transform;
    }

    void Update()
    {
        passedTimes += Time.deltaTime;
        if(CheckLength(player.position))
        {
            if(passedTimes > delayTime)
            {
                passedTimes = 0;
                Vector3 pos = gateTrans.position;
                GameObject obj = Instantiate(objPre, pos, Quaternion.identity);
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                float angleZ = transform.localEulerAngles.z + 90;
                float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                fireSpeed = Random.Range(20f, 40f);
                Vector3 v = new Vector3(x, y, 0) * fireSpeed;
                rb.AddForce(v, ForceMode.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, length);
    }
}
