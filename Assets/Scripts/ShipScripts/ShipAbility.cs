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

    public GameObject pulseWarning;
    private Animator pulseAnim;
    public GameObject pulseIcon;
    private Animator pulseIconAnim;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        ship = gameObject.GetComponentInParent<ShipMovement>();
        pulseAnim = pulseWarning.GetComponent<Animator>();
        pulseIconAnim = pulseIcon.GetComponent<Animator>();
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
                if (scoreManager.GetMineralCount() >= cost)
                {
                    pulseAnim.SetBool("isFull", true);
                    pulseIconAnim.SetBool("isAvailable", true);
                }
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
                        pulseAnim.SetBool("isFull", false);
                        pulseIconAnim.SetBool("isAvailable", false);
                    }
                    else
                    {
                        notMineralEnough.SetActive(true);
                        Invoke(nameof(DeactivateNotMineralEnoughtGameObject), 1f);
                    }
                }
            }
        }

        if ((int)timer > 0)
        {
            cooldownText.GetComponent<Text>().text = $"{(int)timer}";
        }
        else if ((int)timer == 0)
        {
            cooldownText.GetComponent<Text>().text = string.Empty;
        }
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
