using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmtytiFx : MonoBehaviour
{   
    private SpriteRenderer sr;
    [Header("Flash FX")]
    [SerializeField] private Material HitMat;
    private Material originalMat;

    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
      
    }
    private IEnumerator FlashFx()
    {
        sr.material = HitMat;

        yield return new WaitForSeconds(0.2f);
            
        sr.material = originalMat;
        Debug.Log("i win");
    }
    private void RedcolorBlink()
    
    {
        if (sr.color!=Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red;
            
    }
    private void CancelReadblink()
    {
        CancelInvoke();
        sr.color = Color.white;
    }
}
