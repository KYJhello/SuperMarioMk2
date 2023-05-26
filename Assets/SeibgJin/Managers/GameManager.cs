using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


 public class GameManager : MonoBehaviour
{
    public const string DefaultName = "Manager";

    private PlayerController playerController;
    private AudioSource audioSource;

    private static GameManager instance;
    private static DataManager dataManager;

    // 다른 클래스에서 GameManager에 접근하려면 GetInstance()를 사용하여 접근
    public static GameManager GetInstance { get { return instance; } }

    public static GameManager Instance { get { return instance; } }
    public static DataManager Data {  get { return dataManager; } }

    private GameManager gameManager;
    private PlayerState privatestate;

    private void Awake()
    {
        if (instance != null)   // 게임매니저 스크립트(this)를 하나만 제외하고 모두 삭제시킴
        {
            Destroy(this);
            return;
        }

        // 씬 전환상태에서도 게임오브젝트가 사라지지 않게 많들어주는 방식
        instance = this;
        InitManagers();
        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        if(instance == this)
            instance = null;
    }
     
   
    // GameManger가 없으면 만들어주는 함수 Init
    private void Init()
    {
        if (instance == null)
        {
            // GameManger가 있는지 확인
            GameObject dataObj = GameObject.Find("GameManager");
            
            // 없으면 생성
            if (dataObj == null)
            {
                dataObj = new GameObject { name = "GameManager" };
            }
            
            if (dataObj.GetComponent<GameManager>() == null)
            {
                dataObj.AddComponent<GameManager>();
            }
            
            //없어지지 않도록 해줌
            DontDestroyOnLoad(dataObj);

            //instance 할당
            instance = dataObj.GetComponent<GameManager>();
        }
    }
   

    // DataManger 관리
    private void InitManagers()
    {
        // DataManager Init
        GameObject dataObj = new GameObject() { name = "DataManager" };
       
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<DataManager>();
    }

    // 현재 플레이어의 상태를 저장하는 변수
    // PlayerState currentPlayerState = GameManager.Instance.GetCurrentPlayerState();
    
    // 현재 플레이어 상태를 반환하는 함수
    public PlayerState GetCurrentPlayerState()
    {
        return playerController.currentState; //현재 플레이어 상태 변환
    }
    public enum ItemList { mushroom, fire, star, coin }
    public enum State { SmallMario, BigMario, FireMario, StarMario, Dead, Size }


    private State state = State.SmallMario;
    private void GetItem(ItemList itemList)
    {
        switch (itemList)
        {
            case ItemList.mushroom:
                state = State.BigMario;
                break;
                
            case ItemList.fire:
                if(state == State.SmallMario)
                state = State.BigMario;
                else if(state == State.BigMario)
                    state = State.FireMario;
                break;

            case ItemList.star:
                state = State.StarMario;
                break;

            case ItemList.coin:
                Data.AddCoinCount(1);
                Data.AddScoreCount(100);
                break;
            
        }
    }
 

}
