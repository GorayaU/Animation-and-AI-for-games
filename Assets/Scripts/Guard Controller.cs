using UnityEngine;

public class GuardController : MonoBehaviour
{
    private static readonly int WeaponsBlend = Animator.StringToHash("WeaponsBlend");
    private static readonly int MovementBlend = Animator.StringToHash("MovementBlend");
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            _animator.SetFloat(WeaponsBlend, 0f);
        }else if (Input.GetKeyDown("2"))
        {
            _animator.SetFloat(WeaponsBlend, 1f);
        }else if (Input.GetKeyDown("3"))
        {
            _animator.SetFloat(WeaponsBlend, 2f);
        }else if (Input.GetKeyDown("4"))
        {
            _animator.SetFloat(WeaponsBlend, 3f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _animator.SetFloat(MovementBlend, 0f);
        }else if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetFloat(MovementBlend, 1f);
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetFloat(MovementBlend, 2f);
        }else if (Input.GetKeyDown(KeyCode.R))
        {
            _animator.SetFloat(MovementBlend, 3f);
        }
    }
}
