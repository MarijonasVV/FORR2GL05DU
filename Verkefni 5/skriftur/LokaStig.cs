using TMPro;
using UnityEngine;

public class LokaStig : MonoBehaviour
{
    // fær texta
    public TextMeshProUGUI countText;

    void Start()
    {
        // Sýnir lokastig
        countText.text = "Stig: " + PlayerController.count.ToString();
    }
}
