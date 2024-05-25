using System.Collections;
using UnityEngine;

public class LoadingManager: Tab
{
    public RectTransform LoadingImageRect;
    
    private Coroutine _loadingCoroutine;

    public override void ShowAll()
    {
        base.ShowAll();
        _loadingCoroutine = StartCoroutine(LoadingAnimation());
        
    }
    
    public override void HideAll()
    {
        base.HideAll();
        if (_loadingCoroutine != null)
            StopCoroutine(_loadingCoroutine);
    }
    
    private IEnumerator LoadingAnimation()
    {
        while (true)
        {
            LoadingImageRect.Rotate(0, 0, 2.5f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
