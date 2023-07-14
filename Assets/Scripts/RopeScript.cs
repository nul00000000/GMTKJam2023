using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.PhysicsModule;

public class RopeScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody playerBody;
    public Transform anchor;
    private GameObject playerCubeObject;
    public Transform fanTransform;
    public GameObject renderer;
    private Material sensorMaterial;
    public float aoeHeight = 4;
    public float fanHeight = 0.2f;
    public bool colliding = false;
    public float flashTimer = 0;
    private ConfigurableJoint joint;

    void Start() {
        sensorMaterial = GetComponent<Renderer>().material;
        gameObject.transform.localScale = new Vector3(2, aoeHeight, 2);
        gameObject.transform.localPosition = new Vector3(0, aoeHeight / 2 + fanHeight / 2, 0);
    }

    [ExecuteInEditMode]
    void OnValidate() {
        gameObject.transform.localScale = new Vector3(2, aoeHeight, 2);
        gameObject.transform.localPosition = new Vector3(0, aoeHeight / 2 + fanHeight / 2, 0);
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            playerBody = collision.gameObject.GetComponentInParent<Rigidbody>();
            playerCubeObject = collision.gameObject;
            sensorMaterial.color = new Color(0, 188, 0, sensorMaterial.color.a);
            colliding = true;
        }
    }

    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            sensorMaterial.color = new Color(188, 0, 0, sensorMaterial.color.a);
            playerCubeObject = collision.gameObject;
            playerBody = collision.gameObject.GetComponentInParent<Rigidbody>();
            colliding = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            if (joint != null) {
                Destroy(joint);
                joint = null;
                renderer.SetActive(false);

            } else if (colliding) {
                renderer.SetActive(true);

                joint = playerBody.gameObject.AddComponent<ConfigurableJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = anchor.position;
                joint.zMotion = ConfigurableJointMotion.Locked;
                joint.yMotion = ConfigurableJointMotion.Limited;
                joint.xMotion = ConfigurableJointMotion.Limited;
                SoftJointLimit jointLimit = new SoftJointLimit();
                jointLimit.limit = (playerBody.gameObject.transform.position - anchor.position).magnitude;
                joint.linearLimit = jointLimit;                
            } else {
                flashTimer = 1;
            }
        }

        if (joint != null) {
            Vector3 position = (anchor.position - playerBody.gameObject.transform.position);
            float angle = Vector3.Angle(transform.up, position);
            Vector3 cross = Vector3.Cross(transform.up, position);
            if (cross.z < 0) {
                angle *= -1;
            }
            Debug.Log(cross + " " + angle);
            renderer.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            renderer.transform.localScale = new Vector3(renderer.transform.localScale.x, position.magnitude, renderer.transform.localScale.z);
            renderer.transform.position = Vector3.Lerp(anchor.position, playerBody.gameObject.transform.position, 0.5f);
        }

        if (flashTimer > 0 && !colliding) {
            flashTimer = Mathf.Max(0, flashTimer - Time.deltaTime);
            sensorMaterial.color = new Color((188 + 68 * Mathf.Sin(flashTimer * 10)) / 255, 0, 0, sensorMaterial.color.a);
        }
    }
}
