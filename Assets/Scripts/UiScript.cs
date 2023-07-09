using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform buttonTransform;
    public bool pressed = false;
    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        if (!pressed) {
            buttonTransform.localScale = new Vector3(.5f * Mathf.Sin(Time.time) + 2f, .5f * Mathf.Sin(Time.time) + 2f, 1);
        } else {
            buttonTransform.localScale *= .6f;
        }


    }

    public void OnClick() {
        pressed = true;
    }

}
