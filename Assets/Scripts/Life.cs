using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private static readonly int Death = Animator.StringToHash("Death");
    [SerializeField] private AudioSource _deathAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag($"Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _animator.SetTrigger(Death);
        _deathAudioSource.Play();

        // DestroyBody();
    }

    private void DestroyBody()
    {
        Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
