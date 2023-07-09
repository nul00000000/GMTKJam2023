using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3Script : MonoBehaviour
{
    // Start is called before the first frame update
    public BossScriptFinal bossScript;
    public GameObject cubePrefab;
    public GameObject shootPrefab;
    public GameObject wizardPrefab;
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
            if (Time.time - time > 2 && count == 2) {
                bossScript.wizardStanding.SetActive(true);
                bossScript.tired = true;
                bossScript.doingAttack = false;
                active = false;
            }
            else if (Time.time - time > .3 && count == 1) {
                count += 1;
                Instantiate(wizardPrefab, bossScript.gameObject.transform);

            }
            if (Time.time - time > 0 && count == 0) {
                bossScript.wizardStanding.SetActive(false);
                count += 1;

            }
        }
    } 
}
