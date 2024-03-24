using Infrastructure.Services.PersistentProgress;

namespace Infrastructure.Services.Score
{
	public class ScoreService
	{
		private readonly PersistentProgressService _progressService;

		public ScoreService(PersistentProgressService progressService) => 
			_progressService = progressService;

		public void IncreaseScore(int score) => 
			_progressService.Progress.ScoreData.CurrentScore += score;
	}
}