using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RagdollScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody[] rigidBodies;
    public Renderer cube;
    
    public bool pressed = false;
    public float time = 0;

    void Start() {
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();

        cube.material.SetColor("_Color", new Color(cube.material.color.r, cube.material.color.g, cube.material.color.b, 0));
    }


    void EnableRagdoll() {
        foreach (Rigidbody rigidBody in rigidBodies) {
            rigidBody.isKinematic = false;
        }
    }

    void DisableRagdoll() {
        foreach (Rigidbody rigidBody in rigidBodies) {
            rigidBody.isKinematic = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (pressed) {
            if (Time.time - time > 3) {
            SceneManager.LoadScene(1);
            } else if (Time.time - time > 1) {
                cube.material.SetColor("_Color", new Color(cube.material.color.r, cube.material.color.g, cube.material.color.b, Mathf.Min(Time.time - time - 1, 204f / 255f)));
            } 
        }
        
    }

    public void OnClick() {
        pressed = true;
        time = Time.time;
        EnableRagdoll();
    }
}
