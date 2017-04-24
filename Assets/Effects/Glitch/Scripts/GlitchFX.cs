using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GlitchFX : MonoBehaviour
{
    [SerializeField]
    private float _glitchAmount = 0.0f;

    [SerializeField]
    private Texture2D _blockTexture = null;

    [SerializeField]
    private Material _glitchMat = null;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        RenderTexture t = RenderTexture.GetTemporary(source.width, source.height);
        Graphics.Blit(source, destination, _glitchMat);
        RenderTexture.ReleaseTemporary(t);
    }

    private void Start()
    {
        _glitchMat.SetTexture("_GlitchMap", _blockTexture);

        Invoke("UpdateRandom", 0.25f);
    }

    private void UpdateRandom()
    {
        _glitchMat.SetFloat("_GlitchAmount", _glitchAmount);
        _glitchMat.SetFloat("_GlitchRandom", Random.Range(-1.0f, 1.0f));
        Invoke("UpdateRandom", Random.Range(0.01f, 0.15f));
    }
}