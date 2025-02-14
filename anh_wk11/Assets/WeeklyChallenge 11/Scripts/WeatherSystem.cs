using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using Unity.VisualScripting;

public class WeatherSystem : MonoBehaviour
{
    [Header("Global")]
    public Material globalMaterial;
    public Light sunLight;
    public Material skyboxMaterial;
    public TMP_Text weatherText;

    [Header("Winter Assets")]
    public ParticleSystem winterParticleSystem;
    public Volume winterVolume;

    [Header("Rain Assets")]
    public ParticleSystem rainParticleSystem;
    public Volume rainVolume;

    [Header("Autumn Assets")]
    public ParticleSystem autumnParticleSystem;
    public Volume autumnVolume;

    [Header("Summer Assets")]
    public ParticleSystem summerParticleSystem;
    public Volume summerVolume;

    private void Start()
    {
        Summer();
    }

    public void Winter()
    {
        winterVolume.gameObject.SetActive(true);
        ResetConditions("winter");

        // set snow in shader
        globalMaterial.SetFloat("_SnowFade", 1);
        globalMaterial.SetColor("_SnowColor", new Color(1f, 1f, 1f, 1.0f));       

    }

    public void Rain()
    {
        rainVolume.gameObject.SetActive(true);
        ResetConditions("rain");
        Debug.Log("Rain system");
        if(!rainParticleSystem.isPlaying) rainParticleSystem.Play();

        globalMaterial.SetFloat("_SnowFade", 0); 
        
    }

    public void Autumn()
    {
        autumnVolume.gameObject.SetActive(true);
        ResetConditions("autumn");

        globalMaterial.SetFloat("_SnowFade", 0.3f); 
        globalMaterial.SetColor("_SnowColor", new Color(1.0f, 0.2f, 0.0f, 1.0f));
    }

    public void Summer()
    {
        summerVolume.gameObject.SetActive(true);
        ResetConditions("summer");

        globalMaterial.SetFloat("_SnowFade", 0);       
    }

    void ResetConditions(string season)
    {
        if(season != "winter") winterVolume.gameObject.SetActive(false);
        if(season != "autumn") autumnVolume.gameObject.SetActive(false);
        if(season != "summer") summerVolume.gameObject.SetActive(false);
        if(season != "rain") rainVolume.gameObject.SetActive(false);

        rainParticleSystem.Stop();
        winterParticleSystem.Stop();
        summerParticleSystem.Stop();
        autumnParticleSystem.Stop();
    }

}
