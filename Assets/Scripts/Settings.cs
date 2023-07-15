using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings {
    public static class GameParams {
        public static float musicVolumeMultiplier = 1.0f;
        public static float soundVolumeMultiplier = 1.0f;
        public static bool level1SequenceFinished = false;

        public static void SaveUserData() {
            PlayerPrefs.SetInt("MusicVolume", (int) (GameParams.musicVolumeMultiplier * 100));
            PlayerPrefs.SetInt("SoundVolume", (int) (GameParams.soundVolumeMultiplier * 100));
        }

        public static void LoadUserData() {
            GameParams.musicVolumeMultiplier = PlayerPrefs.GetInt("MusicVolume", 100) / 100f;
            GameParams.soundVolumeMultiplier = PlayerPrefs.GetInt("SoundVolume", 100) / 100f;
        }
    }


}