using UnityEngine;
using UnityEngine.UI;

public class VolumeSoundSlider : MonoBehaviour
{
    [SerializeField] private string _propertyName;

    private AudioService _audioService;
    private Slider _slider;

    private void Awake()
    {
        _audioService = AudioService.Instance;
        _slider = GetComponent<Slider>();
        _audioService.ChangeVolumeSoundEffects(PlayerPrefs.GetFloat(_propertyName, 1f));
        _slider.onValueChanged.AddListener((value) =>
        {
            PlayerPrefs.SetFloat(_propertyName, value);
            _audioService.ChangeVolumeSoundEffects(value);
        });
    }

    private void OnEnable()
    {
        _slider.value = PlayerPrefs.GetFloat(_propertyName, 1f);
    }

}
