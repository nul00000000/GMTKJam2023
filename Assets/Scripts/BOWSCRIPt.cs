using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOWSCRIPt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObj;
    public Rigidbody cubeBody;

    private float time;
    void Start()
    {
        time = Time.time;
        cubeBody.AddForce(new Vector3(5000, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time > 1) {
            Destroy(gameObj);
        }
    }
}
