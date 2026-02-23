using UnityEngine;

public class Carheadlight : MonoBehaviour
{
    public Light headlightLeft;
    public Light headlightRight;
    private bool lightsOn = true;

    void Update()
    {
        // Press L to toggle headlights
        if (Input.GetKeyDown(KeyCode.L))
        {
            lightsOn = !lightsOn;
            headlightLeft.enabled = lightsOn;
            headlightRight.enabled = lightsOn;
        }
    }
}