using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Sprite hoverImage;
    public Sprite outImage;

    Button _button;

    public RadioTower _radioTower;

    public SignalCommand signal;

    void Start()
    {
        _button = GetComponent<Button>();
        //_button.enabled = false;
        _button.image.color = new Color(1, 1, 1, 0.0f);

        _button.onClick.AddListener(OnClick);

        Invoke("Activate", 3.9f); // Same as radio tower
    }

    void Activate()
    {
        _button.enabled = true;
    }

    void Update()
    {
        if(!_radioTower.canSendSignal)
        {
            _button.interactable = false;
            _button.image.color = new Color(1, 1, 1, 0.7f);
        }

        else
        {
            _button.enabled = true;
            _button.interactable = true;
            _button.image.color = new Color(1, 1, 1, 1.0f);
        }
    }

    void OnClick()
    {
        _radioTower.LaunchSignal(signal);
        _button.interactable = false;
        _button.image.color = new Color(1, 1, 1, 0.5f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _button.image.sprite = hoverImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _button.image.sprite = outImage;
    }
}
