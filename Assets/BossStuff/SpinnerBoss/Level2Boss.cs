using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Boss : MonoBehaviour {

    public BossSpinner mainWeapon;

    private int stage = -1;
    private float stageStart = 0;

    void Start() {
        
    }

    void OnEnable() {
        stage = -1;
        stageStart = Time.time;
        mainWeapon.Setup();
        mainWeapon.StopAttack();
    }

    void Update() {
        if(stage == -1) {
            if(stageStart + 2.0f < Time.time) {
                stage = 0;
                stageStart = Time.time;
                mainWeapon.Attack(true);
            }
        } else if(stage == 0) {
            if(stageStart + 2.0f < Time.time) {
                stage = 1;
                stageStart = Time.time;
                mainWeapon.Attack(false);
            }
        } else if(stage == 1) {
            if(stageStart + 2.0f < Time.time) {
                stage = 2;
                stageStart = Time.time;
                mainWeapon.StopAttack();
            }
        }
    }

}
