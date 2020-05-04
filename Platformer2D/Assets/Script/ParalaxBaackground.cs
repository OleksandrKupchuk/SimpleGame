using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBaackground : MonoBehaviour
{
    [SerializeField] bool infiniteHorizontal;
    [SerializeField] bool infiniteVertical;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    [SerializeField] Vector2 parallaxEffectMultiplier;

    private float textureUnitSizeX;
    private float textureUnitSizeY;
    private float offsetPositionX;
    private float offsetPositionY;

    private float length;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        //textureUnitSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
        //Debug.Log("pixelPerUnit = " + sprite.pixelsPerUnit);
        //Debug.Log("width = " + texture.width);
        //Debug.Log("length = " + length);
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;
        //Debug.Log("delta = " + deltaMovement);
        if (infiniteHorizontal)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                //offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                offsetPositionX = (cameraTransform.position.x - transform.position.x);
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
            }
        }

        //Debug.Log("cameraT = " + cameraTransform.position.x);
        //Debug.Log("transfP = " + transform.position.x);
        //Debug.Log("differentP = " + (cameraTransform.position.x - transform.position.x));
        //Debug.Log("offsetX = " + offsetPositionX);

        if (infiniteVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY);
            }
        }
    }
}
