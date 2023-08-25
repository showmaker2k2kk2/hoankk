using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public Enemystate currenState { get; private set; }
    public void Inlitialize(Enemystate _starState)
    {
        currenState = _starState;
        currenState.Enter();

    }
    public void changerState(Enemystate _newstate)
    {   
        currenState.Exit();
        currenState = _newstate;
        currenState.Enter();

    }

}
