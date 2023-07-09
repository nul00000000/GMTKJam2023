using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{

    public GameObject recreate;
    public LockRotation mainCamera;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.R)) {
            GameObject obj = Instantiate(recreate, new Vector3(0, 1.36f, 0), new Quaternion());
            obj.GetComponent<ResetButton>().mainCamera = mainCamera;
            mainCamera.follow = obj.GetComponentInChildren<Rigidbody>();
            Destroy(gameObject);
        }
    }
}
