using UnityEngine;

public class GimmickController : MonoBehaviour
{
    Rigidbody rb;
    Transform player;
    public float length;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���[���[�ƃM�~�b�N�̋������v�Z
        float d = Vector3.Distance(transform.position, player.position);
        if(length > d)
        {
            rb.isKinematic = false;
        }
        
    }
}
