using UnityEngine;

public class AudioLight : AudioAffected
{
    private Light light;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        light.intensity = Mathf.Lerp(light.intensity, GetTargetValue(), smoothing);
    }
}
