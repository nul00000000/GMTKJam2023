using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBossScript : MonoBehaviour
{
    public abstract void OnHitbox(Collider collider);
}
