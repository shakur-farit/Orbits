using System.IO;
using UnityEngine;
using Zenject;

namespace Infrastructure.AssetsManagement
{
	public class Assets : IAssets
	{
		private readonly DiContainer _diContainer;

		public Assets(DiContainer diContainer) => 
			_diContainer = diContainer;

		public GameObject Instantiate(string path)
		{
			GameObject prefab = Resources.Load<GameObject>(path);
			return _diContainer.InstantiatePrefab(prefab);
		}

		public GameObject Instantiate(string path, Transform parentTransform)
		{
			GameObject prefab = Resources.Load<GameObject>(path);
			return _diContainer.InstantiatePrefab(prefab, parentTransform);
		}

		public GameObject Instantiate(string path, Vector2 position, Transform parentTransform)
		{
			GameObject prefab = Resources.Load<GameObject>(path);
			return _diContainer.InstantiatePrefab(prefab, position, Quaternion.identity, parentTransform);
		}
	}
}