using UnityEngine;

public class BallController0519 : MonoBehaviour
{
    float dropSpeed = -0.1f;
    float deadLine  = -5f;

    void Start()
    {
    
    }

    void Update()
    {
        // �t���[�����Ƃɓ����ŗ�������
        transform.Translate(0, dropSpeed, 0);

        // ��ʊO�ɏo����{�[�����폜����
        if(transform.position.y <= deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameDirector0519.hp -= Random.Range(10,31);
            Destroy(gameObject);
        }
        
    }
}
