using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Button YürüButton;
    [SerializeField] private Button DurButton;
    [SerializeField] private Hand hand;
    
    bool mesgul = false;
    bool kutuElde = false;
    float yurumeHizi = 2f;

    private void Start()
    {
        Dur();
    }

    private void Update()
    {
        if (_animator.GetBool("KutuÝleYürü"))
        {
            transform.position += -transform.forward * yurumeHizi * Time.deltaTime;
        }
        if (_animator.GetBool("Yürü"))
        {
            transform.position += transform.forward * yurumeHizi * Time.deltaTime;
        }
    }

    public void KutuAl()
    {
        if (!mesgul)
        {
            mesgul = true;
            kutuElde = true;
            _animator.SetBool("Idle", false);
            _animator.SetBool("Yürü", false);
            _animator.SetBool("KutuÝleYürü", false);
            _animator.SetBool("KutuAl", true);
            _animator.SetBool("KutuÝleIdle", false);
            _animator.SetBool("KutuBýrak", false);
            _animator.SetBool("ArkanýDön", false);
            StartCoroutine(bekle());
        }
    }

    IEnumerator bekle()
    {
        yield return new WaitForSeconds(2f);
        mesgul = false;
    }

    public void Yürü()
    {
        if(!kutuElde)
        {
            _animator.SetBool("Idle", false);
            _animator.SetBool("Yürü", true);
            _animator.SetBool("KutuÝleYürü", false);
            _animator.SetBool("KutuAl", false);
            _animator.SetBool("KutuÝleIdle", false);
            _animator.SetBool("KutuBýrak", false);
            _animator.SetBool("ArkanýDön", false);
        }

    }


    public void Dur()
    {
        if (!kutuElde)
        {
            mesgul = false;
            _animator.SetBool("Idle", true);
            _animator.SetBool("Yürü", false);
            _animator.SetBool("KutuÝleYürü", false);
            _animator.SetBool("KutuAl", false);
            _animator.SetBool("KutuÝleIdle", false);
            _animator.SetBool("KutuBýrak", false);
            _animator.SetBool("ArkanýDön", false);
        }
    }

    public void KutuIleYürü()
    {
        if (kutuElde)
        {
            _animator.SetBool("Idle", false);
            _animator.SetBool("Yürü", false);
            _animator.SetBool("KutuÝleYürü", true);
            _animator.SetBool("KutuAl", false);
            _animator.SetBool("KutuÝleIdle", false);
            _animator.SetBool("KutuBýrak", false);
            _animator.SetBool("ArkanýDön", false);
        }
    }

    public void KutuIleDur()
    {
        kutuElde = true;
        _animator.SetBool("Idle", false);
        _animator.SetBool("Yürü", false);
        _animator.SetBool("KutuÝleYürü", false);
        _animator.SetBool("KutuAl", false);
        _animator.SetBool("KutuÝleIdle", true);
        _animator.SetBool("KutuBýrak", false);
        _animator.SetBool("ArkanýDön", false);
    }

    public void KutuBýrak()
    {
        if (!mesgul)
        {
            mesgul = true;
            _animator.SetBool("Idle", false);
            _animator.SetBool("Yürü", false);
            _animator.SetBool("KutuÝleYürü", false);
            _animator.SetBool("KutuAl", false);
            _animator.SetBool("KutuÝleIdle", false);
            _animator.SetBool("KutuBýrak", true);
            _animator.SetBool("ArkanýDön", false);

            StartCoroutine(bekle2());
            kutuElde = false;

        }
    }

    IEnumerator bekle2()
    {
        yield return new WaitForSeconds(1f);
        hand.Birak();
        mesgul = false;
    }

    public void ArkanýDön()
    {
        if (!mesgul)
        {
            mesgul = true;
            _animator.SetBool("Idle", false);
            _animator.SetBool("Yürü", false);
            _animator.SetBool("KutuÝleYürü", false);
            _animator.SetBool("KutuAl", false);
            _animator.SetBool("KutuÝleIdle", false);
            _animator.SetBool("KutuBýrak", false);
            _animator.SetBool("ArkanýDön", true);

            StartCoroutine(bekle());
        }
    }

}
