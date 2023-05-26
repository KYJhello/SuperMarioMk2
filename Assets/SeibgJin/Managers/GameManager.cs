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

    // �ٸ� Ŭ�������� GameManager�� �����Ϸ��� GetInstance()�� ����Ͽ� ����
    public static GameManager GetInstance { get { return instance; } }

    public static GameManager Instance { get { return instance; } }
    public static DataManager Data {  get { return dataManager; } }

    private GameManager gameManager;
    private PlayerState privatestate;

    private void Awake()
    {
        if (instance != null)   // ���ӸŴ��� ��ũ��Ʈ(this)�� �ϳ��� �����ϰ� ��� ������Ŵ
        {
            Destroy(this);
            return;
        }

        // �� ��ȯ���¿����� ���ӿ�����Ʈ�� ������� �ʰ� ������ִ� ���
        instance = this;
        InitManagers();
        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        if(instance == this)
            instance = null;
    }
     
   
    // GameManger�� ������ ������ִ� �Լ� Init
    private void Init()
    {
        if (instance == null)
        {
            // GameManger�� �ִ��� Ȯ��
            GameObject dataObj = GameObject.Find("GameManager");
            
            // ������ ����
            if (dataObj == null)
            {
                dataObj = new GameObject { name = "GameManager" };
            }
            
            if (dataObj.GetComponent<GameManager>() == null)
            {
                dataObj.AddComponent<GameManager>();
            }
            
            //�������� �ʵ��� ����
            DontDestroyOnLoad(dataObj);

            //instance �Ҵ�
            instance = dataObj.GetComponent<GameManager>();
        }
    }
   

    // DataManger ����
    private void InitManagers()
    {
        // DataManager Init
        GameObject dataObj = new GameObject() { name = "DataManager" };
       
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<DataManager>();
    }

    // ���� �÷��̾��� ���¸� �����ϴ� ����
    // PlayerState currentPlayerState = GameManager.Instance.GetCurrentPlayerState();
    
    // ���� �÷��̾� ���¸� ��ȯ�ϴ� �Լ�
    public PlayerState GetCurrentPlayerState()
    {
        return playerController.currentState; //���� �÷��̾� ���� ��ȯ
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
