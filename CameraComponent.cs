using UnityEngine;
using System.Collections;

public class CameraComponent : MonoBehaviour 
{
	public GameObject cameraTarget;
	// centers the camera at the camera target at startup
	public bool startCentered;
	// follows the camera target
	public bool followTarget;

	// Use this for initialization
	void Start () 
	{
		if (startCentered)
		{
			Debug.Assert(cameraTarget);
			Vector3 targetPos = cameraTarget.transform.position;
			transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (followTarget)
		{
			Debug.Assert(cameraTarget);

			Vector3 targetPos = cameraTarget.transform.position;
			transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
		}
	}
}
