using UnityEngine;

public class RedLightning : MonoBehaviour
{
    Light stormLight;

    void Start()
    {
        stormLight = GetComponent<Light>();
        InvokeRepeating("Flash", 2f, Random.Range(4f, 8f));
    }

    void Flash()
    {
        StartCoroutine(LightningFlash());
    }

    System.Collections.IEnumerator LightningFlash()
    {
        stormLight.intensity = 5f;
        yield return new WaitForSeconds(0.1f);
        stormLight.intensity = 0f;

        yield return new WaitForSeconds(0.05f);

        stormLight.intensity = 3f;
        yield return new WaitForSeconds(0.1f);
        stormLight.intensity = 0f;
    }
}