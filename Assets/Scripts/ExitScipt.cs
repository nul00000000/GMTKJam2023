using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScipt : MonoBehaviour
{
    public BossScriptFinal bossScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision) {
        bossScript.OnExit(collision);
    }
}

