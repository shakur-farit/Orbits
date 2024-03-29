using Drops;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using StaticEvents;
using UI.Services.Factory;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class GameEnterPoint : MonoBehaviour
	{
		private Game _game;

		private IStaticDataService _staticDataService;
		private IPersistentProgressService _progressService;
		private ILoadService _loadService;

		private IGameFactory _gameFactory;
		private IUIFactory _uiFactory;
		private IWindowService _windowService;


		[Inject]
		private void Constructor(IStaticDataService staticDataService, IPersistentProgressService progressService,
			ILoadService loadService, IGameFactory gameFactory, IUIFactory uiFactory, IWindowService windowService)
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