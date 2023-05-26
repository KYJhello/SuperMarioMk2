using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;


public abstract class Item : MonoBehaviour
{
    protected enum Items { mushroom, fire, star, coin };
    // ������ �ڵ�
    // 0 = ����
    // 1 = �Ҳ�      
    // 2 = ��        
    // 3 = ����  
    [SerializeField] protected Items itemInfo;
    [SerializeField] protected Transform blockPos;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Animator animator;

    public abstract void Move();

    public abstract void Turn();


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player") // �÷��̾�� ����� ��
        {
            // ���ӸŴ������� GetItem �Լ� ������ �ڵ�� �Բ� ȣ��
        }
    }

}
