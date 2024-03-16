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
		GameObject Debuff { get; }

		void CreateHero();
		void CreateBigAsteroid();
		void CreateMiddleAsteroid();
		void CreateSmallAsteroid();
		void CreateHud();
		void CreateStar(Vector2 position, Transform parentTransform);
		void CreateDebuff(Vector2 position, Transform parentTransform);
		void CreateSpawner();
	}
}