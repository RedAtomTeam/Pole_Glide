using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private StatsConfig _statsConfig; 
    [SerializeField] private LevelConfig _levelConfig;

    [SerializeField] private Player _player;
    [SerializeField] private DistanceConrtoller _distanceController;

    [SerializeField] private GameObject _loseWindow;

    [SerializeField] private GameObject _winWindow;

    [SerializeField] private GameObject _gameWindow;
    [SerializeField] private GameObject _gameField;


    private void Start()
    {
        _player.loseEvent += Lose;
        _distanceController.winEvent += Win;
        _distanceController.End = _levelConfig.distance;
        Time.timeScale = 1f;
    }

    private void Lose()
    {
        _statsConfig.distance += _distanceController.Distance;

        SOSaveLoadService.Instance.SaveAll();
        _loseWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Win()
    {
        _player.Deactivate();
        _levelConfig.status = true;
        _statsConfig.distance += _distanceController.Distance;

        SOSaveLoadService.Instance.SaveAll();
        _winWindow.SetActive(true);
        Time.timeScale = 0f;
    }
}
