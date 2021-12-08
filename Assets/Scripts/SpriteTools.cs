using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTools : MonoBehaviour
{
    public Camera Camera;

    

    // returns an angle in degrees between a world point and the mouse cursor
    // 0 degrees is to the right of the world point, 90 degrees is straight up
    // from the world point

    public float GetAngleBetweenWorldPointAndMouse(Vector3 point1)
    {
        Vector2 point1Screen = Camera.main.WorldToScreenPoint(new Vector3(
            point1.x, point1.y, 0f));
        return DegreesBetweenPoints(point1Screen, Input.mousePosition);
    }

    public float GetAngleBetweenWorldPoints(Vector3 point1, Vector3 point2)
    {
        Vector2 point1Screen = Camera.main.WorldToScreenPoint(new Vector3(
            point1.x, point1.y, 0f));
        Vector2 point2Screen = Camera.main.WorldToScreenPoint(new Vector3(
            point2.x, point2.y, 0f));
        return DegreesBetweenPoints(point1Screen, point2Screen);
    }

    private float DegreesBetweenPoints(Vector2 point1, Vector2 point2)
    {
        float angle = Mathf.Atan2(point2.y - point1.y,
            point2.x - point1.x);
        angle = angle * Mathf.Rad2Deg;

        if (angle < 0)
            angle = 360 - (-1 * angle);

        return angle;
    }

    public Vector3 ConstrainToScreen(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.WorldToScreenPoint(spriteRenderer.transform.position);

        // if we're offscreen to the right
        if (SpriteRight(spriteRenderer) > Screen.width)
            screenPosition.x = Screen.width - SpriteHalfWidth(spriteRenderer);

        // if we're offscreen to the left
        if (SpriteLeft(spriteRenderer) < 0)
            screenPosition.x = SpriteHalfWidth(spriteRenderer);

        // if we're offscreen to the top
        if (SpriteTop(spriteRenderer) > Screen.height)
            screenPosition.y = Screen.height - SpriteHalfHeight(spriteRenderer);

        // if we're offscreen to the bottom
        if (SpriteBottom(spriteRenderer) < 0)
            screenPosition.y = SpriteHalfHeight(spriteRenderer);

        return Camera.ScreenToWorldPoint(screenPosition);
    }

    public Vector3 ConstrainToScreenLame(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.WorldToScreenPoint(spriteRenderer.transform.position);

        // if we're offscreen to the right
        if (screenPosition.x > Screen.width)
            screenPosition.x = Screen.width;

        // if we're offscreen to the left
        if (screenPosition.x < 0)
            screenPosition.x = 0;

        // if we're offscreen to the top
        if (screenPosition.y > Screen.height)
            screenPosition.y = Screen.height;

        // if we're offscreen to the bottom
        if (screenPosition.y < 0)
            screenPosition.y = 0;

        return Camera.ScreenToWorldPoint(screenPosition);
    }

    private float SpriteRight(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.WorldToScreenPoint(spriteRenderer.transform.position);
        return screenPosition.x + SpriteHalfWidth(spriteRenderer);
    }

    private float SpriteLeft(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.WorldToScreenPoint(spriteRenderer.transform.position);
        return screenPosition.x - SpriteHalfWidth(spriteRenderer);
    }

    private float SpriteTop(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.WorldToScreenPoint(spriteRenderer.transform.position);
        return screenPosition.y + SpriteHalfHeight(spriteRenderer);
    }

    private float SpriteBottom(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.WorldToScreenPoint(spriteRenderer.transform.position);
        return screenPosition.y - SpriteHalfHeight(spriteRenderer);
    }

    private float SpriteHalfWidth(SpriteRenderer spriteRenderer)
    {
        return spriteRenderer.sprite.rect.width / 4;
    }

    private float SpriteHalfHeight(SpriteRenderer spriteRenderer)
    {
        return spriteRenderer.sprite.rect.height / 4;
    }
}
