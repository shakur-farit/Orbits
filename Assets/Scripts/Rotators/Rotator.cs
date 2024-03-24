using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Rotators
{
	public abstract class Rotator : MonoBehaviour
	{
		private const float Zero = 0;

		protected float RotateAngle;
		protected float RotateSpeed;

		protected StaticDataService StaticDataService;

		[Inject]
		public void Constructor(StaticDataService staticData) =>
			StaticDataService = staticData;

		private void OnEnable()
		{
			RotateAngle = Zero;
			RotateSpeed = Zero;

			StaticEventsHandler.OnStartedToPlay += StartRotate;
			StaticEventsHandler.OnHeroDied += StopRotate;
		}

		private void OnDisable()
		{
			StaticEventsHandler.OnStartedToPlay -= StartRotate;
			StaticEventsHandler.OnHeroDied -= StopRotate;
		}


		private void Update() =>
			DoRotate();

		private void DoRotate() =>
			transform.Rotate(0f, 0f, RotateAngle * RotateSpeed);

		private void StartRotate() => 
			SetupAngleAndSpeed();

		private void StopRotate() => 
			enabled = false;

		protected abstract void SetupAngleAndSpeed();
	}
}