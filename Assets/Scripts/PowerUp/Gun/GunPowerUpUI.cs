using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GunPowerUpUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Transform _player;
    private RectTransform _position;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _position  = gameObject.GetComponent<RectTransform>();
        _image = gameObject.GetComponent<Image>();


        _image.type = Image.Type.Filled;
        SetFillAmount(0f);

    }

    // Update is called once per frame
    void Update()
    {
        _position.position = Camera.main.WorldToScreenPoint(_player.position);
    }

    public void SetFillAmount(float percentage)
    {
        _image.fillAmount = percentage;
    }


}
