using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void ChangeAnimation()
    {
        _anim.SetInteger("state", Random.Range(0, 3));
        _anim.SetTrigger("change");
    }
}