using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings;
using UnityEngine.UI;


public class SettingsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Slider scrollbar1;
    public Scrollbar scrollbar2;
    public AudioSource gunShot;
    public AudioSource death;
    public AudioSource horror;
    
    void Start() {
        GameParams.LoadUserData();
        scrollbar1.value = GameParams.musicVolumeMultiplier;
        scrollbar2.value = GameParams.soundVolumeMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange1() {
        GameParams.musicVolumeMultiplier = scrollbar1.value;
        GameParams.SaveUserData();
    }

    public void OnValueChange2() {
        GameParams.soundVolumeMultiplier = scrollbar2.value;
        GameParams.SaveUserData();

    }



    public void LoadPrefs() {
        GameParams.LoadUserData();

        scrollbar1.value = GameParams.musicVolumeMultiplier;
        scrollbar2.value = GameParams.soundVolumeMultiplier;
    }
}
