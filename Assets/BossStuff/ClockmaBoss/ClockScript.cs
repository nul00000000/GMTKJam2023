using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{

    public DiscreteSpinner minuteHand;
    
    public SlimeScript[] shellSegments;
    public Rigidbody[] shellBodies;
    public Vector3[] originalPos;

    private int numSegments;

    // Start is called before the first frame update
    void Start()
    {
        numSegments = shellSegments.Length;
        shellBodies = new Rigidbody[numSegments];
        originalPos = new Vector3[numSegments];
        for(int i = 0; i < numSegments; i++) {
            shellBodies[i] = shellSegments[i].GetComponent<Rigidbody>();
            originalPos[i] = shellSegments[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < numSegments; i++) {
            shellBodies[i].MovePosition(originalPos[i] + shellBodies[i].transform.up * Mathf.Max(Vector3.Dot(shellBodies[i].transform.up, minuteHand.transform.right), 0) * 3);
        }
    }
}
