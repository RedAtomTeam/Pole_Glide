using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetStats : MonoBehaviour
{
    [SerializeField] private StatsConfig _statsConfig;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ResetStatsConfig);
    }

    private void ResetStatsConfig()
    {
        _statsConfig.distance = 0;
        foreach (var levelConfig in _statsConfig.levelConfigs)
            levelConfig.status = false;
        SOSaveLoadService.Instance.SaveAll();
    }
}
