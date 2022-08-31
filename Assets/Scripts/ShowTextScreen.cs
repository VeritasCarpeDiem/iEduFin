using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowTextScreen : MonoBehaviour
{
    [SerializeField] private List<GameObject> etfButtons;
    [SerializeField] private List<GameObject> cryptoButtons;
    [SerializeField] private GameObject etfChoiceScreen;
    [SerializeField] private GameObject cryptoChoiceScreen;
    [SerializeField] private GameObject newScreen;
    [SerializeField] private GameObject currentBg;
    [SerializeField] private GameObject newBg;

    private string screenTitle = "Tip";
    private GameObject currentScreen;

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
        //Index 0
        "The purchased cryptocurrency needs to be stored somewhere. " +
        "First, you need to know about two types: light and heavy purses. If you are going to buy a “souvenir” amount of currency (where you're not going to worry about it's safety " +
        ", the light purse (available from your phone) is a great option. It's best to choose a proven solution with a good rating and reviews (like FoPay). " +
        "Important — before making the final choice we advise you to make sure that the wallet allows you to transfer the account or wallet to another device, and you are satisfied with the rate of inputting or outputting the currency. " +
        "If you have a significant amount on hand, that has been accumulated over several years and want to transfer it to digital coins, here we advise you to spend time reading the instructions and allocate " +
        "space on your hard drive for the installation of a full (heavy) wallet for the selected cryptocurrency. This is the most secure option, as in fact, you download all your coins to your PC, where they are stored " +
        "and regularly communicate with the server for verification.",
        
        //Index 1
        "Hearing from a friend or your favorite crypto magazine that bitcoin has set a " +
        "new growth record, do not hurry to register a wallet and look for an exchange office. Any cryptocurrency after a sharp rise either going through a correction or a strong enough fall. " +
        "But in any case, the chance that you will have time to run into a rushing train is always less than the chance that the idea will end in failure and disappointment. It is much more reasonable to wait for the " +
        "moment of decline in your chosen currency and buy it at the lowest price.",
        
        //Index 2
        "For you, there are still available exchanges — Bitfinex, WEX, (the same BTC-e), YoBit and others. If you are going to trade currency, the exchange suits you the most." +
        " Choose the platform that supports convenient payment methods, and after the purchase, you can choose any other for trading, at least the same Hotbit." +
        "\nIf you just want to convert the accumulated fiat currency into cryptocurrency, we can advise you to use the LocalBitcoins website. Here you can choose a seller geographically close to you and arrange a personal meeting. " +
        "This option provides safety and is so popular because of the ability to pay in any way you have agreed (even in cash)." + 
        " And as a result, despite the commission, it is often still more profitable than throwing money to third-party payment systems, especially foreign.",

        //Index 3
        "This is a very important piece of advice that we recommend you to listen to. Often, after spending large sums of money to buy cryptocurrency, the beginner and excited owner of the digital hoarding wealth pours adrenaline into committing rash acts. " + 
        "The slightest changes in the rate in the direction of recession terrify all newly-minted cryptocurrency investors, which is bad for their nerves and a rational understanding of the situation. " + 
        "Bitcoin has repeatedly experienced major falls — with the first major hacker robberies, with the ban on ICO in China and even with the negative mention of the coin by any serious investor. " + 
        "But it took not even months, and often weeks and the rate has stabilized and we saw growth again. Therefore, our advice to you is just to buy bitcoins (and FOINs) and do nothing else, at least for some time.",

        //Index 4
        "No one can say for sure what will happen to Bitcoin in a year, " +
        "five years or a quarter of a century. However, only the Bitcoin (cryptocurrency) has the highest credibility today. Dubious rumors are pushing the new traders to risky actions for the sale " +
        "of Bitcoin and the purchase of other coins with the hope of a sharp enrichment, which does not always end this way. If you are in this category recently, we strongly recommend that you " +
        "keep most of the investment (at least 50%) in it."
    };

    
    public void DisplayText(GameObject button)
    {
        if (etfButtons.Contains(button))
        {
            currentScreen = etfChoiceScreen;
            nextScreen();
            
            int index = etfButtons.IndexOf(button);
            screenTitle = button.GetComponentInChildren<TextMeshProUGUI>().text;
            newScreen.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = screenTitle;
            newScreen.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                etfContents[index];
        }
        else
        {
            currentScreen = cryptoChoiceScreen;
            nextScreen();
            
            int index = cryptoButtons.IndexOf(button);
            screenTitle = button.GetComponentInChildren<TextMeshProUGUI>().text;
            newScreen.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = screenTitle;
            newScreen.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                cryptoContents[index];
        }
    }

    private void nextScreen()
    {
        currentBg.SetActive(false);
        newBg.SetActive(true);
        
        currentScreen.SetActive(false);
        newScreen.SetActive(true);
    }

    public void prevScreen()
    {
        currentBg.SetActive(true);
        newBg.SetActive(false);
        
        currentScreen.SetActive(true);
        newScreen.SetActive(false);
    }
    
}
