using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour {
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    [SerializeField] protected GameObject playerShield;
    public Material shieldMaterial;
    private const int maxOpacityValue = 255;

    private void Start()
    {
        playerShield.SetActive(false);
        shieldMaterial = playerShield.GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Shield triggered by player");
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            if (destroyComponent) {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent));        // co-routines
                    // NOTE: If you just call "StartCoroutine", then it will not work, 
                    //       since the present object is destroyed!
                // ShieldTemporarily(destroyComponent);                                      // async-await
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            }
        } else {
            Debug.Log("Shield triggered by "+other.name);
        }
    }

    private IEnumerator ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {   // co-routines
    // private async void ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {      // async-await
        destroyComponent.enabled = false;
        playerShield.SetActive(true);
        for (float i = duration; i > 0; i--) {

            // calculate the new alpha of the player shield
            float newAlpha = maxOpacityValue * (i / duration) / (maxOpacityValue);
            changeShieldAlpha(newAlpha);
            Debug.Log("Shield: " + i + " seconds remaining!, shield alpha is: " + newAlpha);
            yield return new WaitForSeconds(1);       // co-routines
            // await Task.Delay(1000);                // async-await
        }
        Debug.Log("Shield gone!");
        destroyComponent.enabled = true;
        playerShield.SetActive(false);
    }


    // Change player shield alpah
    void changeShieldAlpha(float alpha)
    {
        Material material = playerShield.GetComponent<MeshRenderer>().material;
        Color oldColor = material.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
        material.color = newColor;
        playerShield.GetComponent<MeshRenderer>().material = material;
    }
}
