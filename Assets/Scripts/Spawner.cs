using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _pointsSpawn;
    [SerializeField] private bool _isSpawn = true;
    [SerializeField] float _timeBetweenSpawns = 2f;
    [SerializeField, Range(0, 1f)] float _delayAfterParticle = 0.5f;

    private const float MinimumAngle = 0;
    private const float MaximumAngle = 360;

    private WaitForSeconds _waitBetweenSpawns;
    private WaitForSeconds _waitAfterParticle;

    private Quaternion RandomRotation => Quaternion.Euler(0, Random.Range(MinimumAngle, MaximumAngle), 0);

    private void OnValidate()
    {
        _waitAfterParticle = new WaitForSeconds(_delayAfterParticle);
        _waitBetweenSpawns = new WaitForSeconds(Mathf.Abs(_timeBetweenSpawns - _delayAfterParticle));
    }

    private void Start()
    {
        StartCoroutine(Coroutine());
    }    

    private IEnumerator Coroutine()
    {
        OnValidate();

        while (_isSpawn)
        {
            yield return _waitBetweenSpawns;

            Transform spawnTransform = GetPointSpawn();
            spawnTransform.GetComponent<ParticlePoint>().ShowSpawn();

            yield return _waitAfterParticle;

            Instantiate(_enemyPrefab, spawnTransform.position, RandomRotation);
        }
    }

    private Transform GetPointSpawn()
    {
        int randomIndex = Random.Range(0, _pointsSpawn.Length);
        Transform spawnTransform = _pointsSpawn[randomIndex];

        return spawnTransform;
    }
}