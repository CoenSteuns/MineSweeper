using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour {

    public virtual void EnterState()
    {

    }

    public virtual void Update()
    {

    }

    public abstract void Reason();

    public virtual void ExitState()
    {

    }
}
