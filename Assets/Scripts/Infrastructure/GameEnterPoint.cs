using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using UI.Services.Factory;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class GameEnterPoint : MonoBehaviour
	{
		private Game _game;

		private StaticDataService _staticDataService;
		private PersistentProgressService _progressService;
		private ILoadService _loadService;

		private GameFactory _gameFactory;
		private UIFactory _uiFactory;
		private WindowService _windowService;


		[Inject]
		public void Constructor(StaticDataService staticDataService, PersistentProgressService progressService,
			ILoadService loadService, GameFactory gameFactory, UIFactory uiFactory, WindowService windowService)
		{
			_staticDataService = staticDataService;
			_progressService = progressService;
			_loadService = loadService;
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_windowService = windowService;
		}

		private void Awake()
		{
			_game = new Game(_staticDataService, _progressService, _loadService, 
				_gameFactory, _uiFactory, _windowService);
			_game.StateMachine.Enter<LoadStaticDataState>();
		}
	}
}