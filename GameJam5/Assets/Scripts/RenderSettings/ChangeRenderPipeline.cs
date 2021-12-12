using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ChangeRenderPipeline : MonoBehaviour
{
    public RenderPipelineAsset HighQuality;
    public RenderPipelineAsset LowQuality;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            GraphicsSettings.renderPipelineAsset = HighQuality;
        }
        else
        {
            GraphicsSettings.renderPipelineAsset = LowQuality;
        }

    }

}
