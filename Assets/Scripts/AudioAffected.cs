using UnityEngine;

public class AudioAffected : MonoBehaviour
{
    [SerializeField] private AudioAnalyzer analyzer;
    [SerializeField] private float minValue = 0f;
    [SerializeField] private float maxValue = 1f;
    [SerializeField] protected float smoothing = .9f;

    protected float GetTargetValue()
    {
        return minValue + ((maxValue - minValue) * analyzer.SpectrumValue);
    }
}
