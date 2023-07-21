using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2Script : MonoBehaviour
{
    // Start is called before the first frame update
    public BossScriptFinal bossScript;
    public GameObject cubePrefab;
    public GameObject shootPrefab;

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
                CubeAttack ca = Instantiate(cubePrefab, bossScript.gameObject.transform).GetComponent<CubeAttack>();
                ca.cooldown = 1;
                ca.timeToKill = 3;
            } else if (Time.time - time > 0 && count == 0) {
                count += 1;
                CubeShoot shoot = Instantiate(shootPrefab, new Vector3(bossScript.player.transform.position.x, bossScript.gameObject.transform.position.y, 0), new Quaternion(), bossScript.gameObject.transform).GetComponent<CubeShoot>();
                shoot.cooldown = 1.5f;
                shoot.timeToKill = 4.5f;
                Instantiate(cubePrefab, bossScript.gameObject.transform);
            }
        }
    } 
}
