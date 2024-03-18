using UnityEngine;

namespace Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject Hero { get; }
		GameObject BigAsteroid { get; }
		GameObject MiddleAsteroid { get; set; }
		GameObject SmallAsteroid { get; set; }
		GameObject Spawner { get; }
		GameObject Star { get; }
		GameObject SpeedUpper { get; }
		GameObject AngleSwitcher { get; }

		void CreateHero();
		void CreateBigAsteroid();
		void CreateMiddleAsteroid();
		void CreateSmallAsteroid();
		void CreateHud();
		void CreateStar(Vector2 position, Transform parentTransform);
		void CreateSpeedUpper(Vector2 position, Transform parentTransform);
		void CreateSpawner();
		void CreateAngleSwitcher(Vector2 position, Transform parentTransform);
	}
}