using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class AOCardData : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI nameText;
        [SerializeField] public TextMeshProUGUI  priceText;
        //[SerializeField] public TextMeshProUGUI  changeText;
        [SerializeField] public TextMeshProUGUI  changePercentText;
        [SerializeField] public TextMeshProUGUI  portfolioPercentText;
        [SerializeField] public TextMeshProUGUI  pieChart;
        [SerializeField] public TextMeshProUGUI numShares;
        [SerializeField] public Image p;
        
    }
}