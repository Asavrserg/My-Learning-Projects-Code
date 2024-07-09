using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    string State {get; set;}

    void Initialize();
}

// public abstract class BaseManager
// {
//     protected string _state;
//     public abstract string state {get; set;}

//     public abstract void Initialize();
// }