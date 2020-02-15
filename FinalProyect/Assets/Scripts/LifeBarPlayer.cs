using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBarPlayer : MonoBehaviour
{
    public Image LifeBarImage;
    public Image LifeBarImageDanger;
    public float animDuration;
    private float lifeEnemy;
    private float currentHealth;
    private float startTime;
    public static LifeBarPlayer instanceLife;

    void Awake()
    {
        instanceLife = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        LifeBarImage.fillAmount = 1;
        LifeBarImageDanger.fillAmount = 1;
        startTime = Time.time;


    }

    public void Damage()
    {
        this.LifeBarImage.fillAmount -= 0.01f;
        if (this.LifeBarImage.fillAmount == 0)
            this.LifeBarImageDanger.fillAmount -= 0.01f;
    }
}
