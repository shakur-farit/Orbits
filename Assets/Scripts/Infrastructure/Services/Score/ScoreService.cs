using Infrastructure.Services.PersistentProgress;

namespace Infrastructure.Services.Score
{
	public class ScoreService : IScoreService
	{
		private readonly IPersistentProgressService _progressService;

		public ScoreService(IPersistentProgressService progressService) => 
			_progressService = progressService;

		public void IncreaseScore(int score) => 
			_progressService.Progress.ScoreData.CurrentScore += score;
	}
}