using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerController player;

    public PlayerState(PlayerController player)
    {
        this.player = player;
    }

    public virtual void Enter() 
    {

    }
    public virtual void Update() 
    {

    }

    public virtual void Exit() 
    {

    }
}

public class SmallMarioState : PlayerState
{
    public SmallMarioState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        // SmallMario�� ��ȯ
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        // SmallMario���� Ǯ����
        // �����ǰ�
    }
}

public class BigMarioState : PlayerState
{
    public BigMarioState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        // BigMario�� ��ȯ
    }

    public override void Update()
    {
 
    }

    public override void Exit()
    {
        // BigMario���� Ǯ����
        // �����ǰ�, ������(����) ȹ��
    }
}



public class FireMarioState : PlayerState
{
    public FireMarioState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        // FireMario�� ��ȯ
    }

    public override void Update()
    {
        // FireMario
    }

    public override void Exit()
    {
        // FireMario���� Ǯ����
    }
}

public class DeadState : PlayerState
{
    public DeadState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        // ����
    }
    public override void Update()
    {
        
    }

    public override void Exit()
    {
         
    }
}

