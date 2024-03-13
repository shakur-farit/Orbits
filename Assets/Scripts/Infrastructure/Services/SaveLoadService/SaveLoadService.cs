using Data;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Services.SaveLoadService
{
	public class SaveLoadService : ISaveService, ILoadService
	{
		public const string ProgressKey = "Progress";

		private readonly IPersistentProgressService _progressService;

		public SaveLoadService(IPersistentProgressService progressService) => 
			_progressService = progressService;

		public void SaveProgress() => 
			PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());

		public Progress LoadProgress()
		{
			if(PlayerPrefs.HasKey(ProgressKey))
				return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<Progress>();

			return default;
		}
	}
}