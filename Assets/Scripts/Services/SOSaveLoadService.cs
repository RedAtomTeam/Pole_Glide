using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOSaveLoadService : MonoBehaviour
{
    public static SOSaveLoadService Instance;

    [SerializeField] private StatsConfig _statsConfig;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAll();
        }
        else
            Destroy(gameObject);
    }

    public void SaveAll()
    {
        PlayerPrefs.SetInt("Distance", _statsConfig.distance);
        foreach (var level in _statsConfig.levelConfigs)
            PlayerPrefs.SetInt($"{level.levelName}_status", level.status ? 1 : 0);
    }

    public void LoadAll()
    {
        _statsConfig.distance = PlayerPrefs.GetInt("Distance", 0);
        foreach (var level in _statsConfig.levelConfigs)
            level.status = PlayerPrefs.GetInt($"{level.levelName}_status", level.status ? 1 : 0) == 1 ? true : false;
    }


}
