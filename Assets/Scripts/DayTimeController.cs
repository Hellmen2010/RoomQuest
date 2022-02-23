using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeController : MonoBehaviour
{
    [SerializeField, Min(0.12f)] private float exposureMinBorder = 0.12f;
    [SerializeField] private float exposureStart = 1;
    [SerializeField] private float exposureStep = 0.01f;


    private float skyboxExposure;

    public float SkyboxExposure => skyboxExposure;

    public void SetTimeFromSave(DayTimeSave dayTimeSave)
    {
        skyboxExposure = dayTimeSave.skyboxExposure;
        RenderSettings.skybox.SetFloat("_Exposure", skyboxExposure);
        StartCoroutine(DayNight());
    }

    public void SetDefaultTime()
    {
        skyboxExposure = exposureStart;
        StartCoroutine(DayNight());
    }

    private IEnumerator DayNight()
    {
        while (skyboxExposure > exposureMinBorder)
        {
            skyboxExposure -= exposureStep;
            RenderSettings.skybox.SetFloat("_Exposure", skyboxExposure);
            yield return new WaitForSeconds(1);
        }
    }
}
