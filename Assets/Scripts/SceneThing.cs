using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneThing : MonoBehaviour
{
    public void LoadLevel(int level) {
        SceneManager.LoadScene(level);
    }
}
