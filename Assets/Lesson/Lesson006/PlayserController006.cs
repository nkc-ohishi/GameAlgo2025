using UnityEngine;
using UnityEngine.UI;

public class PlayerController006 : MonoBehaviour
{
    float speed = 5;            // ���E�ړ��X�s�[�h
    float deadLine = -5f;       // ���s���C��
    float jumpPower = 1100;     // �W�����v��
    Rigidbody rb;               // Rigidbody�R���|�[�l���g�ۑ��ϐ�
    Vector3 inputDir = Vector3.zero; // �L�[���͕���
    private bool isGround = false;

    // HP�Q�[�W
    public Image img;
    const float MAX_HP = 1000;
    float now_hp = 1000;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbody�R���|�[�l���g��ۑ�
    }

    void Update()
    {

        inputDir.x = Input.GetAxisRaw("Horizontal");

        // ���E�ړ�(���F���V�e�B�̒l�𒼐ڕύX���č��E�ړ�)
        Vector3 vel = rb.linearVelocity;
        vel.x = inputDir.x * speed;
        rb.linearVelocity = vel;

        // ����Ray�𔭎ˁi���݈ʒu���牺�����Ɍ����āj
        Vector3 rayPos = transform.position;
        Ray ray = new Ray(rayPos, Vector3.down);
        isGround = Physics.Raycast(ray, 0.6f);                  // Ray���n�ʂɓ����������𔻒�
        Debug.DrawRay(rayPos, Vector3.down*0.5f, Color.red);    // Scene�r���[��Ray������

        // Z�L�[�ŃW�����v
        if (Input.GetKeyDown(KeyCode.Z) && isGround)
        {
            rb.AddForce(transform.up * jumpPower);
        }

        // HP���R��
        now_hp += 1;
        now_hp = Mathf.Min(now_hp, MAX_HP);
        img.fillAmount = now_hp / MAX_HP;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "DeadObject")
        {
            now_hp -= Random.Range(3, 10);
        }
    }


}
