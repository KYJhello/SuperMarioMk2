using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting
{
    // 0. static 함수 바로 앞에 선언해주면 static함수를 게임이 실행되자 마자 실행해줌.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    // 1. 초기화 게임을 시작하기전 필요한 설정들을 Init함수에서 실시해줌.
    private static void Init()
    {
        // 현 게임 내에 GameManager가 없으면 GameManager 컴포넌트를 가진 게임 오브젝트 추가
        if (GameManager.Instance == null)
        {
            GameObject gameManager = new GameObject() { name = "GameManager" };
            gameManager.AddComponent<GameManager>();
        }
    }
}

