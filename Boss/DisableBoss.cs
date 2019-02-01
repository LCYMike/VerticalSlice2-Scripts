using UnityEngine;


public class DisableBoss : MonoBehaviour {

    public BossAI bossAi;
    private BossAnimations bossAnimations;
    private BossAttack bossAttack;
    
    private float maxY = -10f;
    private float speed = -0.9f;

    private AudioSystem audioSystem;
    private ScoreSystem scoreSystem;

    private void Start()
    {
        bossAttack = GetComponent<BossAttack>();
        bossAnimations = GetComponent<BossAnimations>();

        audioSystem = GameObject.FindWithTag("AudioSystem").GetComponent<AudioSystem>();
        scoreSystem = GameObject.FindWithTag("ScoreSystem").GetComponent<ScoreSystem>();
    }

    public void Descend()
    {
        audioSystem.Kill("boss"); // string must be "player" or "boss"
        scoreSystem.AddScore(Random.Range(0, 1000)); // add X amount to the score
        DisableEnabled();
        Invoke("MoveCorpse", 2f);

    }

    void DisableEnabled()
    {
        bossAnimations.enabled = false;
        bossAttack.enabled = false;
        bossAi.enabled = false;
    }

    void MoveCorpse()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));


        if (transform.position.y <= maxY)
            Destroy(gameObject);

        Invoke("MoveCorpse", 0.01f);
    }

}
