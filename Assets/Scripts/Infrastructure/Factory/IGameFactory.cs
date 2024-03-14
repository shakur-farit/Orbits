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

		void CreateHero();
		void CreateBigAsteroid();
		void CreateMiddleAsteroid();
		void CreateSmallAsteroid();
		void CreateHud();
		void CreateStar(Vector2 position, Transform transform);
		void CreateSpawner();
	}
}