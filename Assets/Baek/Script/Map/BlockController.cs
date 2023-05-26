using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockController : MonoBehaviour
{
    [SerializeField] private GameObject _particleSystem;
    [SerializeField] private bool isRepeat;
    [SerializeField] private GameObject coins;
    public UnityEvent onHit;
    private Animator anim;

    private void Awake()
    {
        if (isRepeat)
        {
            anim = GetComponent<Animator>();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;
        if (!isRepeat)
        {
            Particle_Play();
        }
        else
        {
            AnimationPlay();
        }
    }

    private void AnimationPlay()
    {
        if (anim.GetInteger("BlockLife") <= 0) return;
        anim.SetBool("Up",true);
        anim.SetInteger("BlockLife",(anim.GetInteger("BlockLife") - 1));
        onHit?.Invoke();
    }

    public void AnimationStop()
    {
        anim.SetBool("Up", false);
    }

    private void Particle_Play()
    {
        Instantiate(_particleSystem, transform.position, transform.rotation);
            Destroy(gameObject, 0.15f);
    }

    public void InVoki()
    {
        Debug.Log("ÇìÀÌ");
    }

}
