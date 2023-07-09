using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    public BossScriptFinal bossScript; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision) {
        bossScript.OnTriggerEnter(collision);
    }
}
