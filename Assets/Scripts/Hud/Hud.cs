using TMPro;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class Hud : MonoBehaviour
	{
		public TextMeshProUGUI ScoreText;


		//[Inject]
		//private void Constructor(ICountUpTimerService countUpTimer) => 
		//	_countUpTimer = countUpTimer;

		private void Update() => 
			UpdateScoreText();

		private void UpdateScoreText()
		{
			
		}
	}
}