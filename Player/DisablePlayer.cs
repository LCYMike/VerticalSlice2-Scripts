using UnityEngine;


public class DisablePlayer : MonoBehaviour {

    private PlayerMovement playerMovement;
    private PlayerAnimations playerAnimations;
    private PlayerAttack playerAttack;
    private Rigidbody2D rb;

    public CameraFollow cam;

    private float maxY = 15f;
    private float speed = 0.9f;

    public GameObject deathScreen;
    private AudioSystem audioSystem;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAnimations = GetComponent<PlayerAnimations>();
        rb = GetComponent<Rigidbody2D>();
        
        audioSystem = GameObject.FindWithTag("AudioSystem").GetComponent<AudioSystem>();
    }

    public void Ascend()
    {

        Invoke("MoveCorpse", 2f);
        DisableEnabled();
        //gameObject.tag = "Untagged";
        deathScreen.SetActive(true);
        audioSystem.Kill("player"); // string must be "player" or "boss"
    }

    void DisableEnabled()
    {
        playerAnimations.enabled = false;
        playerAttack.enabled = false;
        playerMovement.enabled = false;
        rb.simulated = false;
        cam.enabled = false;
    }

    void MoveCorpse()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));


        if (transform.position.y >= maxY)
            Destroy(gameObject);

        Invoke("MoveCorpse", 0.01f);
    }

}
