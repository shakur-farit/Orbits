using UnityEngine;

namespace Infrastructure.AssetsManagement
{
	public interface IAssets
	{
		GameObject Instantiate(string path);
		GameObject Instantiate(string path, Transform parentTransform);
		GameObject Instantiate(string debuffPath, Vector2 position, Transform parentTransform);
	}
}