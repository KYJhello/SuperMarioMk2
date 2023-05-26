using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public enum ItemList { mushroom, fire, star, coin }
public abstract class Item : MonoBehaviour
{
    // ������ �ڵ�
    // 0 = ����
    // 1 = �Ҳ�      
    // 2 = ��        
    // 3 = ����  
    public ItemList itemInfo;
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
