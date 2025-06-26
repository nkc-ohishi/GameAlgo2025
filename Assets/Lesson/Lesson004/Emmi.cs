using UnityEngine;

public class EmissionAnimator : MonoBehaviour
{
    Color baseColor;
    float emissionStrength = 2.0f;
    float animationSpeed = 2.0f;

    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
        baseColor = mat.GetColor("_EmissionColor");
    }

    void Update()
    {
        // 0Å`emissionStrengthÇèzä¬Ç∑ÇÈíl
        float intensity = Mathf.PingPong(Time.time * animationSpeed, emissionStrength);

        mat.SetColor("_EmissionColor", baseColor * intensity);
    }
}