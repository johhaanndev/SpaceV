using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipAbility : MonoBehaviour
{
    private ScoreManager scoreManager;
    
    public GameObject notMineralEnough;
    public GameObject onCooldown;
    public GameObject destroyerArea;

    private ShipMovement ship;

    public GameObject cooldownText;

    public int cost;
    public float cooldown;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreCanvas").GetComponent<ScoreManager>();
        ship = gameObject.GetComponentInParent<ShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ship.GetAlive())
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 0f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (timer > 0f)
                {
                    onCooldown.SetActive(true);
                    Invoke(nameof(DeactivateCooldowntGameObject), 1f);
                }
                else
                {
                    if (scoreManager.GetMineralCount() >= cost)
                    {
                        var destroyer = (GameObject)Instantiate(destroyerArea, transform.position, transform.rotation);
                        scoreManager.SubstractMineral(cost);
                        timer = cooldown;
                    }
                    else
                    {
                        notMineralEnough.SetActive(true);
                        Invoke(nameof(DeactivateNotMineralEnoughtGameObject), 1f);
                    }
                }
            }
        }

        cooldownText.GetComponent<Text>().text = $"COOLDOWN: {(int)timer}";
    }

    private void DeactivateNotMineralEnoughtGameObject()
    {
        notMineralEnough.SetActive(false);
    }

    private void DeactivateCooldowntGameObject()
    {
        onCooldown.SetActive(false);
    }
}
