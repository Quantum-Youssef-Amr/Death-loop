using UnityEngine;

public class Creditsscript : MonoBehaviour
{
    public float scrollSpeed = 50f;

    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0f, scrollSpeed * Time.deltaTime);
    }
}
