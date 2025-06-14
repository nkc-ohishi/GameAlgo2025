using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController004 : MonoBehaviour
{
    float speed = 5;            // ���E�ړ��X�s�[�h
    float deadLine = -5f;       // ���s���C��
    float jumpPower = 1000;     // �W�����v��
    Rigidbody rb;               // Rigidbody�R���|�[�l���g�ۑ��ϐ�
    Vector3 inputDir = Vector3.zero; // �L�[���͕���
    private bool isGround = false;

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
        isGround = Physics.Raycast(ray, 0.5f);                  // Ray���n�ʂɓ����������𔻒�
        Debug.DrawRay(rayPos, Vector3.down*0.5f, Color.red);    // Scene�r���[��Ray������

        // Z�L�[�ŃW�����v
        if (Input.GetKeyDown(KeyCode.Z) && isGround)
        {
            rb.AddForce(transform.up * jumpPower);
        }

        // �������烊�v���C
        if (transform.position.y <= deadLine)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //�Q�[���v���C�I��
        }

    }

}
