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
    
    void Start() {

        // scrollbar1 = GetComponent<UnityEngine.UI.Slider>();
        // scrollbar2 = gameObject2.GetComponent<UnityEngine.UI.Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange1() {
        Debug.Log(GameParams.musicVolumeMultiplier);
        GameParams.musicVolumeMultiplier = scrollbar1.value;
    }

    public void OnValueChange2() {
        GameParams.soundVolumeMultiplier = scrollbar2.value;
    }
}
