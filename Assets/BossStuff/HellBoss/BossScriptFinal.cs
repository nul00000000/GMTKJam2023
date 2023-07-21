using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Settings;

public class BossScriptFinal : BaseBossScript
{
    // Start is called before the first frame update
    public bool bossStarted = false;
    public GameObject sliderPrefab;
    public AudioSource battleMusic;
    public AudioSource music;
    public AudioSource jingle;
    public GameObject wizardStanding;
    public GameObject wizardTired;
    public GameObject player;
    public GameObject hitbox;
    public Rigidbody[] rigidbodies;
    public Attack1Script att1Script;
    public Attack2Script att2Script;
    public Attack3Script att3Script;
    public AudioSource deathSound;

    public AudioSource w1;
    public AudioSource w2;
    public AudioSource w3;
    public AudioSource w4;

    public float wizardHealth = 3;
    public float timer = 0;
    public bool doingAttack = false;
    public bool tired = false;
    public bool bossFinished = false;
    private GameObject slider;
    void Start()
    {
        rigidbodies = wizardTired.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigidBody in rigidbodies) {
            rigidBody.isKinematic = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        w1.volume = 1 * GameParams.soundVolumeMultiplier;
        w2.volume = 1 * GameParams.soundVolumeMultiplier;
        w3.volume = 1 * GameParams.soundVolumeMultiplier;
        w4.volume = 1 * GameParams.soundVolumeMultiplier;

        music.volume = GameParams.musicVolumeMultiplier;
        jingle.volume = GameParams.musicVolumeMultiplier;
        if (bossStarted) {
            timer += Time.deltaTime;
            // Debug.Log(timer + " " + tired + " " + doingAttack);
            if (tired) {
                wizardStanding.SetActive(false);
                wizardTired.SetActive(true);
                hitbox.SetActive(true);
            }
            else if (timer > 4 && !doingAttack) {
                int voiceLine = Random.Range(1, 5);
                int attack = Random.Range(1, 4);

                if (voiceLine == 1) {
                    w1.Play();
                } else if (voiceLine == 2) {
                    w2.Play();
                } else if (voiceLine == 3) {
                    w3.Play();
                } else {
                    w4.Play();
                }

                if (attack == 1) {
                    att1Script.Activate();
                } else if (attack == 2) {
                    att2Script.Activate();
                } else if (attack == 3) {
                    att3Script.Activate();
                } 
                doingAttack = true;
            }
            
        } 
        if (bossFinished) {
            timer += Time.deltaTime;

            if (timer > 3) {
                SceneManager.LoadScene(2);
            }
        }

    }

    public void OnTriggerEnter(Collider collision) {
        if (!bossStarted && !bossFinished) {
            music.Stop();
            battleMusic.Play();
            timer = -2;
            bossStarted = true;
            player = collision.gameObject;
            slider = Instantiate(sliderPrefab, gameObject.transform, false);

        }
    }

    public override void OnHitbox(Collider collision) {
        if (collision.gameObject.tag == "Player" && tired) {
            wizardHealth -= 1;

            if (wizardHealth > 0) {
                wizardStanding.SetActive(true);
                wizardTired.SetActive(false);
                hitbox.SetActive(false);
                deathSound.Play();
                timer = 2;
                tired = false;
            } else {
                foreach(Rigidbody rigidBody in rigidbodies) {
                    rigidBody.isKinematic = false;
                }
                deathSound.Play();
                hitbox.SetActive(false);
                bossFinished = true;
                bossStarted = false;
                timer = 0;
                jingle.Play();
                battleMusic.Stop();
            }
        }
    }

    public void OnExit(Collider collision) {
        if (collision.gameObject.tag == "Player" && bossStarted) {
            wizardHealth = 3;
            wizardStanding.SetActive(true);
            wizardTired.SetActive(false);
            hitbox.SetActive(false);
            bossStarted = false;
            Destroy(slider);
            battleMusic.Stop();
            music.Play();
            tired = false;            
        }
    }
}
