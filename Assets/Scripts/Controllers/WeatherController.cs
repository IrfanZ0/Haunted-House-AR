using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class WeatherController : MonoBehaviour
{
    float lightThreshold;
    float lightThreshold2;
    float lightThreshold3;
    public Material nightSky1Mat;
    public Material nightSky2Mat;
    public Material daySky1Mat;
    public Material daySky2Mat;
    private Material[] skyBoxMat;
    public float pixel_intensity;
    public GameObject rainCloudGO;
    private GameObject rainCloud;
    Transform rainCloudStop;
    public GameObject lightningCloudGO;
    private GameObject lightningCloud;
    Transform lightningCloudStop;
    public GameObject snowCloudGO;
    private GameObject snowCloud;
    Transform snowCloudStop;
     

    // Start is called before the first frame update
    void Start()
    {
        lightThreshold = 0.3f;
        lightThreshold2 = 0.6f;
        lightThreshold3 = 0.9f;
        skyBoxMat = new Material[4];
        skyBoxMat[0] = nightSky1Mat;
        skyBoxMat[1] = nightSky2Mat;
        skyBoxMat[2] = daySky1Mat;
        skyBoxMat[3] = daySky2Mat;
        rainCloudStop = GameObject.Find("Rain Cloud Stop").transform;
        lightningCloudStop = GameObject.Find("Lightning Cloud Stop").transform;
        snowCloudStop = GameObject.Find("Snow Cloud Stop").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (pixel_intensity < lightThreshold)
        {
            StartCoroutine(NightMode(skyBoxMat[0]));

            if (GameObject.FindGameObjectWithTag("Rain Cloud") == null)
            {
                rainCloud = Instantiate(rainCloudGO, rainCloudStop.position, Quaternion.identity) as GameObject;

                AudioSource rainSound = rainCloud.GetComponent<AudioSource>();

                if (!rainSound.isPlaying)
                {
                    rainSound.Play();
                }

                ParticleSystem[] psRain = rainCloud.GetComponentsInChildren<ParticleSystem>();

                foreach (ParticleSystem rain in psRain)
                {
                    if (!rain.isPlaying)
                    {
                        rain.Play();
                    }
                }
            }
           
            
        }

        else if (pixel_intensity >= lightThreshold && pixel_intensity < lightThreshold2)
        {
            StartCoroutine(NightMode(skyBoxMat[1]));

            if (GameObject.FindGameObjectWithTag("Lightning Cloud") == null)
            {
                lightningCloud = Instantiate(lightningCloudGO, lightningCloudStop.position, Quaternion.identity) as GameObject;

                AudioSource lightningSound = lightningCloud.GetComponent<AudioSource>();

                if (!lightningSound.isPlaying)
                {
                    lightningSound.Play();
                }

                ParticleSystem[] psLightning = lightningCloud.GetComponentsInChildren<ParticleSystem>();

                foreach (ParticleSystem lightning in psLightning)
                {
                    if (!lightning.isPlaying)
                    {
                        lightning.Play();
                    }
                }
            }
            
            
        }

        else if (pixel_intensity >= lightThreshold2 && pixel_intensity < lightThreshold3)
        {
            StartCoroutine(DayMode(skyBoxMat[2]));

            if(GameObject.FindGameObjectWithTag("Snow Cloud") == null)
            {
                snowCloud = Instantiate(snowCloudGO, snowCloudStop.position, Quaternion.identity) as GameObject;
                                              
            }
        }

        else
        {
            StartCoroutine(DayMode(skyBoxMat[3]));
        }

    }

    IEnumerator NightMode(Material nightMat)
    {
        RenderSettings.skybox = nightMat;
        yield return new WaitForSeconds(0.5f);

    }

    IEnumerator DayMode(Material dayMat)
    {
        RenderSettings.skybox = dayMat;
        yield return new WaitForSeconds(0.5f);

    }
}
