using UnityEngine;

namespace Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject Bubble { get; }
		GameObject BigAsteroid { get; }
		GameObject Spawner { get; }
		GameObject Buff { get; }
		GameObject MiddleAsteroid { get; set; }
		GameObject SmallAsteroid { get; set; }

		void CreateBubble();
		void CreateBigAsteroid();
		void CreateHud();
		void CreateBuff(Vector2 position, Transform transform);
		void CreateSpawner();
		void CreateMiddleAsteroid();
		void CreateSmallAsteroid();
	}
}