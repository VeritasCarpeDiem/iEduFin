using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowTextScreen : MonoBehaviour
{
    [SerializeField] private List<GameObject> etfButtons;
    [SerializeField] private List<GameObject> cryptoButtons;
    [SerializeField] private GameObject currentScreen;
    [SerializeField] private GameObject nextScreen;
    [SerializeField] private GameObject currentBg;
    [SerializeField] private GameObject nextBg;

    public string screenTitle = "Tip";

    private string[] etfContents =
    {
        //Index 0
        "Limit orders allow you to set the price at which you are willing to trade, " +
        "while market orders will be executed at the current market price as soon as shares are available. " +
        "Market orders present the risk of paying an undesirable price, as the market price can change due to events " +
        "that are out of your control. Limit orders provide investors with greater control over their execution price.",
        
        //Index 1
        "The market tends to be particularly volatile during the first and l" +
        "ast 15 minutes of the trading day so, generally speaking, it’s a good idea to avoid trading during that time. " +
        "In the morning, ETFs are going through a “price discovery” phase — comparing the previous day’s closing price with the " +
        "current net asset value price, and, at the same time, factoring in changes to the value of the underlying holdings. " +
        "At the end of the trading day, large investors may begin to hedge their positions, which can result in rapid price " +
        "changes and widening bid/ask spreads. Overall, trading ETFs during market volatility is best avoided because it " +
        "can cause the bid/ask spread to widen.",
        
        //Index 2
        "Most international markets close by the afternoon for investors " +
        "in the Toronto region. If the market is closed, then market makers are pricing based on estimates and assumptions, " +
        "as they cannot hedge until the following day. Market makers do not know exactly what the price is going to be when " +
        "those markets open, and whenever there is uncertainty, you can be sure that some measure of risk premium is attached to the price of the security.",
        
        //Index 3
        "At any given time, there are two prices for an ETF: " +
        "the price at which someone is willing to buy (the “bid”) and the price at which someone is willing to sell (the “ask”). " +
        "The difference between these two prices is called the “spread.” The spreads exists because, as in any open market, investors " +
        "try to negotiate the best price. Spreads widen and narrow for various reasons. Popular ETFs with strong trading volume may have narrower spreads, " +
        "while less popular, thinly traded ETFs may have wider spreads. However, the underlying market is typically the best determining factor or indicator of spreads. " +
        "It’s important to remember that your quote may not provide you with complete volume data (see below for more on this).",
        
        //Index 4
        "In Canada, the majority of investors and advisors do not have the ability to " +
        "see an ETF’s consolidated bid/ask spread or trading volume. This means that advisors are not seeing every available quote, all the trading volume or the " +
        "existing liquidity on various exchanges. One exchange could be posting more volume and a better price, but you may not be aware of that based on the available data. " +
        "This inability to see the complete picture can drastically affect how you view an ETF’s liquidity and trading volume.",

        //Index 5
        "Many ETFs that trade on Canadian stock exchanges hold U.S. " +
        "and other international securities. There may be days when the ETF will trade on a Canadian exchange even though it is a holiday in the country where " +
        "the underlying securities trade. This can cause bid/ask spreads to widen.",

        //Index 6
        "Macroeconomic news, political shifts or even tweets from the current U.S. " +
        "president can introduce greater market fluctuations, affect the price of securities and potentially widen bid/ask spreads for ETFs.",

        //Index 7
        "Behavioural finance is more than just a fancy term — it has a real effect on investor behaviour. " +
        "The key is to keep your emotions in check and focus on quantitative analysis and your long-term plan. When trading ETFs, it’s important to keep the bigger picture in mind. " +
        "Recognizing and understanding the various elements that could impact your trades can help you make the most of your trading practices. When in doubt, speak to the ETF provider, " +
        "as they will be happy to assist and answer any questions you may have."
    };

    private string[] cryptoContents =
    {
        "Use limit orders, not market orders",
        "Do not trade when the market is volatile",
        "",
        "",
        "",
        "",
        "",
        "",
        ""
    };

    
    public void DisplayText(GameObject button)
    {
        ChangeScreen();
        
        if (etfButtons.Contains(button))
        {
            int index = etfButtons.IndexOf(button);
            screenTitle = button.GetComponentInChildren<TextMeshProUGUI>().text;
            nextScreen.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = screenTitle;
            nextScreen.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                etfContents[index];

        }
        else
        {
            int index = cryptoButtons.IndexOf(button);
            screenTitle = button.GetComponent<TextMeshProUGUI>().text;
            nextScreen.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = screenTitle;
            nextScreen.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                cryptoContents[index];
        }
    }

    private void ChangeScreen()
    {
        currentBg.SetActive(false);
        nextBg.SetActive(true);
        
        currentScreen.SetActive(false);
        nextScreen.SetActive(true);
    }
}
