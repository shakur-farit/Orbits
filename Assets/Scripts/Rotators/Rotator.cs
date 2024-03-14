using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;

namespace Rotators
{
	public abstract class Rotator : MonoBehaviour
	{
		private const float Zero = 0;
		protected float RotateAngle;
		protected float RotateSpeed;

		protected IStaticDataService StaticDataService;


		private void OnEnable()
		{
			RotateAngle = Zero;
			RotateSpeed = Zero;

			StaticEventsHandler.OnStartedToPlay += StartRotate;
		}

		private void OnDisable() => 
			StaticEventsHandler.OnStartedToPlay -= StartRotate;


		protected virtual void Update() =>
			DoRotate();

		protected void DoRotate() =>
			transform.Rotate(0f, 0f, RotateAngle * RotateSpeed);

		protected abstract void StartRotate();
	}
}