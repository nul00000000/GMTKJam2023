using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardShootControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public GameObject wizard;
    private float time;
    private int count = 0;
    void Start() {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time > 1.5 && count == 3) {
            Destroy(gameObject);
        }
        else if (Time.time - time > 1.2 && count == 2) {
            count++;
            Instantiate(bulletPrefab, wizard.transform, false);
        } else if (Time.time - time > .8 && count == 1) {
            count++;
            Instantiate(bulletPrefab, wizard.transform, false);
        } else if (Time.time - time > .4 && count == 0) {
            count++;
            Instantiate(bulletPrefab, wizard.transform, false);
        }
    }
}
