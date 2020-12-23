using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressOnPlatform : MonoBehaviour
{
    [SerializeField] int weightForPress;
    [SerializeField] public int massItems;
    [SerializeField] public bool press;
    [SerializeField] int countBox;
    [SerializeField] Animator animatorPressPlatform;

    [SerializeField] BoxCollider2D platformBoxCollider2D;
    Vector2 defaultPlatformCollider2DSize = new Vector2(0.16f, 0.1631193f);
    Vector2 defaultPlatformCollider2DOffset = new Vector2(0f, -0.00177088f);
    Vector2 preesPlatformCollider2DSize = new Vector2(0.16f, 0.1482385f);
    Vector2 preesPlatformCollider2DOffset = new Vector2(0f, -0.009211291f);

    [SerializeField] private BoxCollider2D platformTrigger;
    Vector2 defaultTriggerOffset = new Vector2(-0.0007943511f, 0.083f);
    Vector2 pressTriggerOffset = new Vector2(-0.0007943511f, 0.064f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player"))
        {
            countBox++;
            massItems += (int)collision.gameObject.GetComponent<Rigidbody2D>().mass;

            CheckWeightBoxes();

            animatorPressPlatform.SetBool("animatorPressPlatformerDown", true);
            //Debug.Log("mass " + massItems);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player"))
        {
            countBox--;
            //massItems = 0;
            //Debug.Log("mass " + massItems);
            massItems -= (int)collision.gameObject.GetComponent<Rigidbody2D>().mass;
            animatorPressPlatform.SetBool("animatorPressPlatformerDown", false);
            CheckWeightBoxes();
        }
    }

    private void CheckWeightBoxes()
    {
        if (massItems >= weightForPress)
        {
            press = true;
        }

        else
        {
            press = false;
        }
    }

    public void PlatformDown()
    {
        platformBoxCollider2D.size = preesPlatformCollider2DSize;
        platformBoxCollider2D.offset = preesPlatformCollider2DOffset;
        //platformTrigger.offset = pressTriggerOffset;
    }

    public void PlatformUp()
    {
        platformBoxCollider2D.size = defaultPlatformCollider2DSize;
        platformBoxCollider2D.offset = defaultPlatformCollider2DOffset;
        //platformTrigger.offset = defaultTriggerOffset;
    }

    public void PlatformPush()
    {
        SoundManager.soundManagerInstance.PlaySound("Platform_Push");
    }
}
