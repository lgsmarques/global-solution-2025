using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundScaler : MonoBehaviour
{
    void Start()
    {
        FitToScreen();
    }

    void FitToScreen()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 220f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 scale = transform.localScale;
        scale.x = worldScreenWidth / width;
        scale.y = worldScreenHeight / height;
        transform.localScale = scale;
    }
}
