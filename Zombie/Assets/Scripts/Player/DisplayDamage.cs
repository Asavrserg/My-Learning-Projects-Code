using System.Collections;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float impactTime = 0.3f;

    private void Start()
    {
        damageCanvas.enabled = false;
    }

    private IEnumerator ShowSplatter()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        damageCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }
}
