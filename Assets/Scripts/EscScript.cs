using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

using Settings;

public class EscScript : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Slider musicSlider;
    public UnityEngine.UI.Slider soundSlider;
    public GameObject panel;
    public AudioSource gameMusic;
    public TMP_Text textElement;
    public AudioSource[] voiceLines;
    public GameObject voiceLineObject;
    public bool showing = false;
    public float timer;

    void Start()
    {
        musicSlider.value = GameParams.musicVolumeMultiplier;
        soundSlider.value = GameParams.soundVolumeMultiplier;
        panel.SetActive(false);
        musicSlider.gameObject.SetActive(false);
        soundSlider.gameObject.SetActive(false);
        
        if (voiceLineObject != null) {
            voiceLines = voiceLineObject.GetComponentsInChildren<AudioSource>();
        }
    }

    // Update is called once per frame
    public void MusicOnValueChange() {
        GameParams.musicVolumeMultiplier = musicSlider.value;
        GameParams.SaveUserData();
    }

    public void SoundOnValueChange() {
        GameParams.soundVolumeMultiplier = soundSlider.value;
        GameParams.SaveUserData();
    }
    
    void Update() {
        if (gameMusic != null) {
            gameMusic.volume = 1 * GameParams.musicVolumeMultiplier;
        }

        foreach (AudioSource voiceline in voiceLines) {
            voiceline.volume = 1 * GameParams.soundVolumeMultiplier;
        }
        
        timer += Time.deltaTime;

        textElement.text = !showing ? ((int) timer + "") : ((Mathf.Round(timer * 100f) / 100f) + "");

        if (Input.GetKeyDown(KeyCode.Escape)) {
            showing = !showing;

            if (showing) {
                panel.SetActive(true);
                musicSlider.gameObject.SetActive(true);
                soundSlider.gameObject.SetActive(true);

            } else {
                panel.SetActive(false);
                musicSlider.gameObject.SetActive(false);
                soundSlider.gameObject.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
