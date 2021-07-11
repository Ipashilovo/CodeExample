using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TargetShower : MonoBehaviour, IActionTargetShower
{
    [SerializeField] private ImageForTarget _itemImage;
    [SerializeField] private ImageForTarget[] _actionImages;
    [SerializeField] private List<SOActionImage> _actionImagesSO;
    [SerializeField] private List<SOInteractibleItem> _itemImages;
    [SerializeField] private ParticleSystem _compliteParticle;
    [SerializeField] private UITimer _timer;
    [SerializeField] private UIFailColorChanger[] _failColorChangers;
    
    public void SetAction(ActionCommand actionCommand)
    {
        HideWhenChange();
        SetActionImages(actionCommand.Action);
        SetItemImage(actionCommand.CookingItem);
    }

    public void SetCooldown(float time)
    {
        _timer.SetTime(time);
    }

    public void ShowComplite()
    {
        _compliteParticle.Play();
    }

    public void ShowFail()
    {
        foreach (var changer in _failColorChangers)
        {
            changer.React();
        }
    }

    public void Hide()
    {
        _timer.gameObject.SetActive(false);
        _itemImage.gameObject.SetActive(false);

        foreach (var image in _actionImages)
        {
            image.gameObject.SetActive(false);
        }
    }

    private void SetActionImages(CookingAction cookingAction)
    {
        Sprite[] sprites = FindActionImage(cookingAction);
        for (int i = 0; i < sprites.Length || i < _actionImages.Length; i++)
        {
            _actionImages[i].SetSprite(sprites[i]); 
            _actionImages[i].gameObject.SetActive(true);
        }
    }

    private void SetItemImage(CookingItemType cookingItemType)
    {
        Sprite sprite = FindItemImage(cookingItemType);
        _itemImage.SetSprite(sprite);
        _itemImage.gameObject.SetActive(true);
    }

    private void HideWhenChange()
    {
        _timer.Hide();
        _itemImage.Hide();

        foreach (var image in _actionImages)
        {
            image.Hide();
        }
    }

    private Sprite[] FindActionImage(CookingAction action)
    {
        Sprite[] sprites = new Sprite[2];
        SOActionImage image = _actionImagesSO.Find(i => i.Action == action);
        sprites[0] = image.InteractibleWith;
        sprites[1] = image.ActionImage;
        return sprites;
    }

    private Sprite FindItemImage(CookingItemType cookingItemType)
    {
        SOInteractibleItem image = _itemImages.Find(f => f.CookingItemType == cookingItemType);
        return image.Sprite;
    }
}
