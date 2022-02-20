using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdate
{
    void OnFixedUpdate(float dt);
    void OnUpdate(float dt);
    void OnLateUpdate(float dt);
}
