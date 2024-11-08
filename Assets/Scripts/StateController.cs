using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController 
{
    public IState curentState;

    public void InstallState(IState curentState)
    {
        this.curentState = curentState;
        curentState.Start();
    }

    public void ChangeState(IState state)
    {
        curentState.Exit();
        curentState = state;
        curentState.Start();
    }
}
