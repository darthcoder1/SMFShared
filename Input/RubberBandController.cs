using UnityEngine;
using System.Collections;

namespace SMF
{
	// Controlls the object by attaching an imaginary rubber-band between the owning gameobject and the
	// target touch (or click) position
	[DisallowMultipleComponent]
	public class RubberBandController : MonoBehaviour
	{
		private SMF.TouchHandler touchHandler;
		private Vector3 currentSmoothVelocity;
		private Touch[] activeTouches;
		
		public float maxSmoothSpeed = 3.0f;
		public float smoothTime = 0.15f;

		// Indicates whether the controller should orient the object towards the target position or if the
		// rotation should be untouched
		public bool orientTowardsTarget = false;

		public int numActiveTouches
		{
			get { return activeTouches == null ? 0 : activeTouches.Length; }
		}

		public Vector3 currentVelocity
		{
			get { return currentSmoothVelocity; }
		}

		// Use this for initialization
		void Start()
		{
			touchHandler = new SMF.TouchHandler();
		}

		// Update is called once per frame
		void Update()
		{
			activeTouches = touchHandler.GetTouches();

			if (activeTouches.Length > 0)
			{
				Touch touch = activeTouches[0];
				Vector3 screenPos = new Vector3(touch.position.x, touch.position.y, 0.0f);
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
				worldPos.z = transform.position.z;
				
				transform.position = Vector3.SmoothDamp(transform.position, worldPos, ref currentSmoothVelocity, smoothTime, maxSmoothSpeed, Time.deltaTime);
			}
			else
			{
				currentSmoothVelocity = Vector3.zero;
			}
		}
	}
}