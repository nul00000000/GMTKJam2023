using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAxisLock : MonoBehaviour
{
    [Header("Freeze Local Position")]
	[SerializeField]
	bool x;
	[SerializeField]
	bool y;
	[SerializeField]
	bool z;

	Vector3 localRotation0;	//original local position

	private void Start()
	{
		SetOriginalLocalPosition();
	}
	
	private void Update ()
	{
		float x, y, z;


		if (this.x)
			x = localRotation0.x;
		else
			x = transform.localRotation.eulerAngles.x;

		if (this.y)
			y = localRotation0.y;
		else
			y = transform.localRotation.eulerAngles.y;

		if (this.z)
			z = localRotation0.z;
		else
			z = transform.localRotation.eulerAngles.z;


		transform.eulerAngles = new Vector3(x, y, z);

	}

	public void SetOriginalLocalPosition()
	{
		localRotation0 = transform.localRotation.eulerAngles;
	}
}
