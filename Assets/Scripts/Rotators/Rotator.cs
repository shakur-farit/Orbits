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

		protected IStaticDataService StaticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticData) =>
			StaticDataService = staticData;

		private void OnEnable()
		{
			RotateAngle = Zero;
			RotateSpeed = Zero;

			StaticEventsHandler.OnStartedToPlay += StartRotate;
		}

		private void OnDisable() => 
			StaticEventsHandler.OnStartedToPlay -= StartRotate;


		private void Update() =>
			DoRotate();

		private void DoRotate() =>
			transform.Rotate(0f, 0f, RotateAngle * RotateSpeed);

		private void StartRotate() => 
			SetupAngleAndSpeed();

		protected abstract void SetupAngleAndSpeed();
	}
}