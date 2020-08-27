using UnityEngine;
using Mirror;

public class CameraFollow : NetworkBehaviour {

	public Transform target;

	// public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void FixedUpdate ()
	{
		if (transform.parent.GetComponent<NetworkIdentity>().hasAuthority)
		{
			// Vector3 desiredPosition = target.position + offset;
			// Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = new Vector3(target.position.x, 20, target.position.z) + offset;
			// transform.LookAt(target);
		}
	}

}