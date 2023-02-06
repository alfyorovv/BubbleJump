using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        player.playerAnimator.SetBool("isLeftWall", player.isLeftWall);
    }

    public void SetJumpTrigger()
    {
        player.playerAnimator.SetTrigger("jump");
    }
}
