using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private const string TriggerRun = "Run";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {        
        _animator.SetTrigger(TriggerRun);
    }

    private void Update()
    {
        transform.localPosition += transform.forward * _speed * Time.deltaTime;
    }
}