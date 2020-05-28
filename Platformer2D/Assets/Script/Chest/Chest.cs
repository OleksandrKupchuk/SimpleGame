using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IUsable
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] Animator animatorChest;

    [SerializeField] public AudioSource audioSource;

    [SerializeField] int forceForSpawnCoinY;
    private int forceForSpawnCoinX;
    [SerializeField] int forceMinForSpawnCoinX;
    [SerializeField] int forceMaxForSpawnCoinX;

    [SerializeField] float delaySpawnCoin;

    private int randomAmountCoin;

    GameObject coinObject;
    Rigidbody2D cointRigidbody;

    public IEnumerator SpawnCoins(int maxAmountCoin)
    {
        randomAmountCoin = Random.Range(1, maxAmountCoin);// amount coin from 1 to maxAmountCoin, if int[number1, number2), if float[number1, number2]
        //Debug.Log("randomAmountCoin = " + randomAmountCoin);

        for (int countSpawnCoin = 0; countSpawnCoin < randomAmountCoin; countSpawnCoin++)
        {
            forceForSpawnCoinX = Random.Range(forceMinForSpawnCoinX, forceMaxForSpawnCoinX);
            //Debug.Log("forceX = " + forceForSpawnCoinX);
            coinObject = Instantiate(coinPrefab, transform.position, transform.rotation);
            cointRigidbody = coinObject.GetComponent<Rigidbody2D>();
            cointRigidbody.AddForce(new Vector2(forceForSpawnCoinX, forceForSpawnCoinY));
            yield return new WaitForSeconds(delaySpawnCoin);
        }
    }

    public void Interaction()
    {
        animatorChest.SetTrigger("animatorChestOpen");
    }
}
