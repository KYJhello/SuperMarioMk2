using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public enum ItemList { mushroom, fire, star, coin }
public abstract class Item : MonoBehaviour
{
    // 아이템 코드
    // 0 = 버섯
    // 1 = 불꽃      
    // 2 = 별        
    // 3 = 코인  
    public ItemList itemInfo;
    [SerializeField] protected Transform blockPos;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Animator animator;

    public abstract void Move();

    public abstract void Turn();


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player") // 플레이어에게 닿았을 때
        {
            // 게임매니저에서 GetItem 함수 아이템 코드와 함께 호출
        }
    }

}
