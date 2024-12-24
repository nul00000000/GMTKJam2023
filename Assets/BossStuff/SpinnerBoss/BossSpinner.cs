using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpinner : MonoBehaviour {

    private bool defaultLeft;
    private bool attacking = false;
    private float armDiff;

    public float defaultStrength = 80;
    public float spinStrength = 300;
    public float armLength = 8;
    public float attackArmLength = 9;
    public float rampSpeed = 0.1f;
    public Spinner spinner;
    [SerializeField]
    public Transform[] arms;

    private float lengthRamp = 0;
    private float targetLength = 0;

    void Start() {
        Setup();
    }

    public void Setup() {
        defaultLeft = spinner.left;
        armDiff = attackArmLength - armLength;
        targetLength = armLength;
        lengthRamp = armLength;
    }

    [ExecuteInEditMode]
    void OnValidate() {
        armDiff = attackArmLength - armLength;
        for(int i = 0; i < arms.Length; i++) {
            arms[i].localScale = new Vector3(0.4f, armLength, 2);
        }
    }

    public void Attack(bool left) {
        if(!attacking) {
            targetLength = attackArmLength;
        }
        attacking = true;
        spinner.strength = spinStrength;
        spinner.left = left;
        spinner.codeOverride = true;
    }

    public void StopAttack() {
        if(attacking) {
            for(int i = 0; i < arms.Length; i++) {
                targetLength = armLength;
            }
        }
        spinner.strength = defaultStrength;
        spinner.left = defaultLeft;
        spinner.codeOverride = false;
        attacking = false;
    }

    void FixedUpdate() {
        lengthRamp = lengthRamp * (1 - rampSpeed) + targetLength * rampSpeed;
        for(int i = 0; i < arms.Length; i++) {
            arms[i].localScale = new Vector3(0.4f, lengthRamp, 2);
        }
    }
    
}
