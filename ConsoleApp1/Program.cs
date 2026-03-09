public Text goldText;
public Text crystalText;
public Text foodText;

void UpdateResourceText(Text resourceText, int amount) {
    resourceText.text = "Amount: " + amount.ToString();
}



AudioSource audioSource;

void PlaySound(AudioClip clip) {
    if (audioSource == null) audioSource = GetComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
}

void Jump() {
    PlaySound(jumpSound);
    rb.velocity = Vector2.up * jumpForce;
}

void Shoot() {
    PlaySound(shootSound);
    Instantiate(bullet);
}



void TakeDamage(int amount) {
    health -= amount;
    if (health < 0) health = 0;
    Debug.Log("Health: " + health);
}


void SpawnEnemy(GameObject enemyPrefab) {
    Vector3 spawnPos = transform.position + new Vector3(0, 1, 0);
    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    PlaySpawnParticle(spawnPos);
}



float mapBoundary = 100f;

void Move(Vector3 direction) {
    transform.Translate(direction * speed * Time.deltaTime);
    
    float clampedX = Mathf.Clamp(transform.position.x, -mapBoundary, mapBoundary);
    transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
}

public class HealthPotion {
    [cite_start]public int healAmount = 10; [cite: 83]
    
    [cite_start]public void Consume(Player player) { [cite: 88]
        [cite_start]player.Heal(healAmount); [cite: 90]
    }
}

public class CollectibleDot {
    [cite_start]public int pointValue = 10; [cite: 100]
    
    [cite_start]public void Collect(Player player) { [cite: 101]
        [cite_start]player.AddScore(pointValue); [cite: 103]
    }
}

public class Spaceship {
    [cite_start]public float moveSpeed = 5f; [cite: 112]
    
    [cite_start]public void MoveHorizontal(float input) { [cite: 116]
        [cite_start]transform.Translate(Vector3.right * input * moveSpeed * Time.deltaTime); [cite: 117]
    }
}

public class PlayerStats {
    [cite_start]public float jumpForce = 5f; [cite: 131]
}

public interface IWeaponSystem {
    [cite_start]void Fire(); [cite: 138]
}

[cite_start]public class Pistol : IWeaponSystem { [cite: 144]
    public void Fire() {      
    }
}

public bool IsPlayerDead() {
    return health <= 0;
}

List<int> startingLevels = new List<int> { 1, 2, 3 };

void Start() {
}

void CheckEnemy(string enemyType) {
    if (enemyType == "Goblin" || enemyType == "Orc" || enemyType == "Troll") {
        Attack();
    } else {
        RunAway();
    }
}


float timer = 0f;
bool isCooldown = true;

void Update() {
    if (!isCooldown) return; 

    timer += Time.deltaTime;
    if (timer >= 5f) {
        isCooldown = false;
        timer = 0f;
    }
}


int GetHighestScore(int score1, int score2) {
    return Mathf.Max(score1, score2); 
}