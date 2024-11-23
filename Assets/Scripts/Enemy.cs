using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private const string TriggerRun = "Run";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(TriggerRun);
    }

    private void Update()
    {
        transform.localPosition += transform.forward * _speed * Time.deltaTime;
    }
}