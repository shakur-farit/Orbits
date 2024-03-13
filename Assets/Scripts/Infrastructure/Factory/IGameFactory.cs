using UnityEngine;

namespace Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject Bubble { get; }
		GameObject Needle { get; }
		GameObject Debuff { get; }
		GameObject DebuffSpawner { get; }
		GameObject Buff { get; }

		void CreateBubble();
		void CreateNeedle();
		void CreateHud();
		void CreateDebuff(Vector2 position, Transform parentTransform);
		void CreateBuff(Vector2 position, Transform transform);
		void CreateDebuffSpawner();
	}
}