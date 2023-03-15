using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FlipMove : MonoBehaviour
{
    [SerializeField]private float spinSpeed, defaultSpinSpeed, FlipCount, thrust, lockPos;
    private Rigidbody rb;
    [SerializeField]
    private bool BottleMovement = true;
    public GameObject WinPanel;
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;
    public List<Texture> AlbedoTextures;
    public List<Mesh> Meshes;
    public int m_Skin;

    //public ParticleSystem ConfettiParticleEffect;


    // Start is called before the first frame update
    void Start()
    {
        spinSpeed = defaultSpinSpeed;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0f, -0.45f, 0f);
        MeshFilterUpdater();
        TextureUpdater();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) < 1f)
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
            //rb2D.freezeRotation = true;
        }
        if(BottleMovement)
        {
            BottleMove();
            BottleFlip();
        }
        //transform.rotation = Quaternion.Euler(lockPos, lockPos, transform.rotation.eulerAngles.z);
    }

    private void BottleFlip()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.5f)
        {
            spinSpeed += Mathf.Sqrt(Mathf.Abs(rb.velocity.x)) * spinSpeed * Time.deltaTime;
            spinSpeed = Mathf.Clamp(spinSpeed, defaultSpinSpeed, 360f);
            transform.Rotate(Vector3.back * Time.deltaTime * spinSpeed);
        }
        else
        {
            spinSpeed = defaultSpinSpeed;
        }
    }

    private void BottleMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (FlipCount < 2)
            {
                //rb2D.AddForceAtPosition(new Vector2(0.3f, 1) * thrust, Vector2.up * -thrust);
                rb.velocity = new Vector3(0.25f, 1f, 0f) * thrust;
                FlipCount++;
                rb.freezeRotation = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.freezeRotation = false;
        FlipCount = 0;
        if (collision.collider.name == "Ground")
        {
            UnityMonetization.instance.DisplayInterstitialAd();
            //GameManager.instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "FinishCube")
        {
            rb.isKinematic = true;
            BottleMovement = false;
            WinPanel.SetActive(true);
            //ConfettiParticleEffect.Play();
            //Time.timeScale = 0;
        }
    }

    public void TextureUpdater()
    {
        m_Skin = PlayerPrefs.GetInt("Skin");
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetTexture("_MainTex", AlbedoTextures[m_Skin]);
    }

    public void MeshFilterUpdater()
    {
        m_Skin = PlayerPrefs.GetInt("Skin");
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = Meshes[m_Skin];
    }
}
