using UnityEngine;

public class AudioScaleShader : AudioAffected
{
    [SerializeField] private Material material;
    const string property = "_HeightAmplitude";

    // Update is called once per frame
    void Update()
    {
        var targetSize = GetTargetValue();
        material.SetFloat(property, targetSize);
    }
}
