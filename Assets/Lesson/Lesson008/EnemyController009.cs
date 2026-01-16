// 進級試験問題用の敵のスクリプト
using UnityEngine;

public class EnemyController009 : MonoBehaviour
{
    float walkSpeed = 5f;
    float shellSpeed = 20f;
    Rigidbody rb;
    float passedTimes = 0;
    float delayTime   = 5;

    private enum State
    {
        Walking,   
        Shell,     
        MovingShell
    }
    private State currentState = State.Walking;
    private Vector3 moveDir = Vector3.right;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case State.Walking:
                Walk();
                break;
            case State.Shell:
                rb.linearVelocity = Vector3.zero;
                break;
            case State.MovingShell:
                rb.linearVelocity = moveDir * shellSpeed;
                break;
        }
    }

    void Walk()
    {
        rb.linearVelocity = new Vector3(moveDir.x * walkSpeed, rb.linearVelocity.y, 0);
    }

    void FlipDirection()
    {
        moveDir = -moveDir;
    }

    void ChangeToShell()
    {
        passedTimes = 0;
        currentState = State.Shell;
        rb.linearVelocity = Vector3.zero;
    }

    void KickShell(Vector3 hitterPos)
    {
        Vector3 dir = Vector3.zero;
        dir.x = transform.position.x - hitterPos.x;
        dir.Normalize();
        moveDir = dir;
        currentState = State.MovingShell;
    }

}