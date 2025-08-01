using UnityEngine;
using UnityEngine.U2D.Animation;

public class coat : MonoBehaviour
{
    [SerializeField] private GameObject leftPad, rightPad;

    private bool _coat_open;
    private SpriteResolver _sr;

    void Start()
    {
        _sr = GetComponent<SpriteResolver>();
    }
    public void ToggleCoat()
    {
        _coat_open = !_coat_open;
        _sr.SetCategoryAndLabel("sprites", _coat_open ? "open" : "closed");
        leftPad.SetActive(_coat_open);
        rightPad.SetActive(_coat_open);
    }

}
