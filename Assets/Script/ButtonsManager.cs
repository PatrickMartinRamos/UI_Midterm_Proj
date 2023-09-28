using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{
    //Zoom Anim
    public Image imageToScale;
    private bool isZoomOut = false;
    //Fade Anim
    public Image imageToFade;
    private bool isFadeOut = false;
    //Flip Anim
    public Image imageToFlip;
    private bool isFlip = false;
    private Vector2 flip_targetRot;
    private Vector2 flip_origRot;
    //Browse Anim
    public Image imageToBrowse;
    private bool isBrowse = false;
    private Vector2 browse_targetPos;
    private Vector2 browse_origPos;
    private Vector2 targetScale;
    private Vector2 origScale;
    //Jiggle Anim
    public Image imageToJiggle;
    private Vector2 target_JiggleScale;
    private Vector2 orig_JiggleScale;
    //Shake Anim
    public Image imageToShake;
    private Vector2 target_ShakePos;
    private Vector2 orig_ShakePos;


    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void Fade()
    {
        float fadeVal = 0f;
        float targetFade = isFadeOut ? 1.0f : fadeVal;
        imageToFade.DOFade(targetFade, 0.25f);
        isFadeOut = !isFadeOut;
    }

    public void Flip()
    {
        flip_targetRot.y = 81f;
        flip_origRot.y = 0f;

        // is isFlip is true call the targetRotation and if the isFlip is false call the origROT;
        Vector3 fliptTargetRotation = isFlip ? flip_targetRot : flip_origRot;
        imageToFlip.transform.DORotate(fliptTargetRotation, 0.25f);
        isFlip = !isFlip;   
    }

    public void Browse()
    {
        browse_targetPos = new Vector2(500, 140f);
        browse_origPos = new Vector2(190f, 140f);
        targetScale = Vector3.zero;
        origScale = Vector3.one;

        if(isBrowse)
        {
            imageToBrowse.transform.DOScale(origScale, 0.2f).SetEase(Ease.OutBack);
         
        }
        else
        {
            imageToBrowse.transform.DOLocalMove(browse_targetPos, 1f).SetEase(Ease.InOutBack).OnComplete(() => { imageToBrowse.transform.DOScale(targetScale, 0f); imageToBrowse.transform.DOLocalMove(browse_origPos, 0f); });
        }
        isBrowse = !isBrowse;
    }

    public void Jiggle()
    {
        target_JiggleScale = new Vector2(1.5f, 1f);
        orig_JiggleScale = new Vector2(1f,1f);

        imageToJiggle.transform.DOScale(target_JiggleScale, .25f).SetEase(Ease.OutExpo).OnComplete(() => { imageToJiggle.transform.DOScale(orig_JiggleScale, .5f).SetEase(Ease.OutElastic); });
    }

    public void Shake()
    {
        imageToShake.transform.DOShakePosition(1f, new Vector2(20,0));
    }




}
