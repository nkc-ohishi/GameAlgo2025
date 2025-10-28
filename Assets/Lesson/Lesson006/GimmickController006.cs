using UnityEngine;
public class GimmickController006 : MonoBehaviour
{
    Rigidbody rb;
    public Transform player;
    public float length;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        // プレーヤーとギミックの距離を計算
        float d = Vector3.Distance(transform.position, player.position);
        if(length > d)
        {
            rb.isKinematic = false;
        }
        
    }
}
