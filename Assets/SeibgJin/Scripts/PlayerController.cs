using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float maxSpeed;



    [SerializeField] Transform jumpBoxCheckPoint;


    [SerializeField] LayerMask groundLayer;

    public PlayerState currentState;
    private Rigidbody2D rb;
    private Vector2 inputDir;
    private bool isGround;

    private Transform target;

    public UnityEvent onPlayerDead;
    public UnityEvent onGetItem;


    private State state = State.SmallMario;
    public enum State { SmallMario, BigMario, FireMario, StarMario, Dead, Size }
    private bool takeDamage = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    /*
    private void OnRunPerformed(InputAction.CallbackContext context)
    {
        float runInput = context.ReadValue<float>();

        if (runInput != 0)
        {
            if (rb.velocity.x > runSpeed && runInput > 0)
                rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            else if (rb.velocity.x < -runSpeed && runInput < 0)
                rb.velocity = new Vector2(-runSpeed, rb.velocity.y);

            rb.AddForce(Vector2.right * runInput * runSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    */

    private void OnRunCanceled(InputAction.CallbackContext context)
    {
        // Run �׼� ��� �� ������ �ڵ� (���⼭�� �ƹ� �۾��� �������� ����)
    }

    private void Start()
    {

        currentState = new SmallMarioState(this);
    }

    private void Update()
    {
        Move();
        // currentState.Update();



    }

    private void FixedUpdate()
    {
        //GetCoin();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    public void Move()
    {
        if (rb.velocity.x > moveSpeed)
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (inputDir.x < 0 && rb.velocity.x > -moveSpeed)
            rb.AddForce(Vector2.right * inputDir.x * moveSpeed, ForceMode2D.Force);
        else if (inputDir.x > 0 && rb.velocity.x < moveSpeed)
            rb.AddForce(Vector2.right * inputDir.x * moveSpeed, ForceMode2D.Force);

    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    public void Run()
    {

    }

    private void OnMove(InputValue value)
    {
        inputDir = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        GroundCheck();
        if (!isGround)
            return;
        Jump();
    }

    /*
    private void OnRun(InputValue value)
    {
        float runInput = value.Get<float>();

        if (runInput != 0)
        {
            if (rb.velocity.x > runSpeed && runInput > 0)
                rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            else if (rb.velocity.x < -runSpeed && runInput < 0)
                rb.velocity = new Vector2(-runSpeed, rb.velocity.y);

            rb.AddForce(Vector2.right * runInput * runSpeed, ForceMode2D.Impulse);
        }
    
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    */

    private void GroundCheck()
    {

        Debug.DrawRay(jumpBoxCheckPoint.position, Vector2.down, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(jumpBoxCheckPoint.position, Vector2.down, 1.05f, groundLayer);
        if (hit.collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    /*
    private void GetCoin()
    {
        RaycastHit2D hit = Physics2D.Raycast(itemBoxPoint.position,Vector2.right, 1.05f, coinLayer);
        if (hit.collider != null)
        {
            isCoin = true;
            Debug.Log("����ȹ��");
            Debug.DrawRay(transform.position, new Vector3(hit.point.x, hit.point.y, 0) - transform.position, Color.red);
        }
        else
        {
            isCoin = false;
            Debug.Log("���ι�ȹ��");
            Debug.DrawRay(transform.position, Vector3.right * 1.05f, Color.green);
        }
    }
    */

    /*
    // �浹
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Coin")   // ����
        {

            // ������ 1 �����Ѵ�
            // Destroy(collision.gameObject);
            GameManager.Data.AddCoinCount(1);
            GameManager.Data.AddScoreCount(1000);
            Debug.Log("����ȹ��");
        }

        if (collision.collider.gameObject.name == "Mushroom")   // ����
        {
            // smallMario�� bigMario�� ���� ��ȯ
            // Destroy(collision.gameObject);
            Debug.Log("����ȹ��");
        }
        if (collision.collider.gameObject.name == "Flower")   // ��
        {
            // smallMario�� bigMario�� ���� ��ȯ
            // bigMario�� fireMario�� ���� ��ȯ
            // Destroy(collision.gameObject);
            Debug.Log("��ȹ��");
        }

    }
    */


    private void SmallMarioUpdate()
    {
        state = State.SmallMario;
        Debug.Log("�������۾���");
    }

    private void BigMarioUpdate()
    {
        state = State.BigMario;
        Debug.Log("������Ŀ��");
    }

    private void FireMarioUpdate()
    {
        state = State.FireMario;
        Debug.Log("���̾������");
    }

    private void StarMarioUpdate()
    {
        state = State.StarMario;
        Debug.Log("����������");
    }

    private void DeadUpdate()
    {
        state = State.Dead;
        Debug.Log("����������");
    }
}
