using UnityEngine;

public class AudioAffected : MonoBehaviour
{
    [SerializeField] private AudioAnalyzer analyzer;
    [SerializeField] private float minValue = 0f;
    [SerializeField] private float maxValue = 1f;
    [SerializeField] protected float smoothing = .9f;
    private float previousValue = 0f;

    protected float GetTargetValue()
    {
        var newValue = Mathf.Lerp(previousValue, minValue + ((maxValue - minValue) * analyzer.SpectrumValue), smoothing);
        return previousValue = newValue;
    }
}
