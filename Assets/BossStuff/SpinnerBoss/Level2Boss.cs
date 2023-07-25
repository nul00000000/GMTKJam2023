using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Settings;

public class Level2Boss : BaseBossScript {

    public BossSpinner mainWeapon;
    public GameObject hitbox;
    public AudioSource deathSound;
    public AudioSource jingle;
    public AudioSource normalMusic;
    public AudioSource bossMusic;

    private int stage = -1;
    private float stageStart = 0;
    private int health = 3;

    void Start() {
        
    }

    void OnEnable() {
        stage = -1;
        stageStart = Time.time;
        mainWeapon.Setup();
        mainWeapon.StopAttack();
        hitbox.SetActive(false);
        normalMusic.Stop();
        bossMusic.Play();
    }

    void OnDisable() {
        normalMusic.Play();
        bossMusic.Stop();
    }

    public override void OnHitbox(Collider collision) {
        if (collision.gameObject.tag == "Player" && stage == 2) {
            health--;

            if (health > 0) {
                deathSound.Play();
                stage = -1;
                stageStart = Time.time;
            } else {
                deathSound.Play();
                jingle.Play();
                bossMusic.Stop();
                stage = 3;
                stageStart = Time.time;
            }

            hitbox.SetActive(false);
        }
    }

    void Update() {
        bossMusic.volume = GameParams.musicVolumeMultiplier;
        jingle.volume = GameParams.musicVolumeMultiplier;
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
                hitbox.SetActive(true);
            }
        } else if(stage == 2) {
            if(stageStart + 10.0f < Time.time) {
                stage = 0;
                stageStart = Time.time;
                mainWeapon.Attack(true);
                hitbox.SetActive(false);
            }
        } else if(stage == 3) {
            if(stageStart + 4.0f < Time.time) {
                SceneManager.LoadScene(3);
            }
        }
    }

}
