using System;
using UnityEngine;

namespace DefaultNamespace
{
	public class CameraController : MonoBehaviour
	{
		public Transform target;
		public float smoothSpeed = 0.125f;
		
		private void Start()
		{
			if (target == null)
			{
				throw new Exception("Target is not set");
			}
		}
		
		private void LateUpdate()
		{
			Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;
		}
		
		public void SetTarget(Transform newTarget)
		{
			target = newTarget;
		}
	}
}