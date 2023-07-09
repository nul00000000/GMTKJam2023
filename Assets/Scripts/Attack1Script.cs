using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1Script : MonoBehaviour
{
    // Start is called before the first frame update
    public BossScriptFinal bossScript;
    public GameObject cubePrefab;

    private float time = 0;
    private bool active = false;
    private int count = 0;
    public void Activate() {
        time = Time.time;
        active = true;
        count = 0;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            GameObject player = bossScript.player;
            if (Time.time - time > 5 && count == 2) {
                count += 1;
                bossScript.tired = true;
                bossScript.doingAttack = false;
                active = false;
            } else if (Time.time - time > 2 && count == 1) {
                count += 1;
                Instantiate(cubePrefab, bossScript.gameObject.transform);
            } else if (Time.time - time > 0 && count == 0) {
                count += 1;
                CubeAttack cube = Instantiate(cubePrefab, bossScript.gameObject.transform.position + Vector3.up * 1.5f + Vector3.left * -7, new Quaternion(), bossScript.gameObject.transform).GetComponent<CubeAttack>();
                cube.cooldown = 3f;
                cube.timeToKill = 4;
                Instantiate(cubePrefab, bossScript.gameObject.transform);
            }
        }
    } 
}
