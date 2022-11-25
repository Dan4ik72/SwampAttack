using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;

    private readonly float _pushForce = 5f;
    private readonly float _maxLeftCoinPushForce = 1f;
    private readonly Vector3 _upSpawnOffset = new Vector3(0,1,0);

    public void SpawnCoin(int count, Vector3 spawnPosition)
    {
        spawnPosition += _upSpawnOffset;

        StartCoroutine(SpanwCoint(count, spawnPosition));
    }
    
    private IEnumerator SpanwCoint(int count, Vector3 spawnPosition)
    {
        var delayBetweenSpawn = new WaitForSeconds(0.2f);

        for (int i = 0; i < count; i++)
        {
            var createdCoin = Instantiate(_coinTemplate, spawnPosition, Quaternion.identity);

            PushCoin(createdCoin);

            yield return delayBetweenSpawn;
        }
    }

    private void PushCoin(Coin coin)
    {
        coin.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _pushForce, ForceMode2D.Impulse);
        coin.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(0, _maxLeftCoinPushForce), ForceMode2D.Impulse);
    }
}
