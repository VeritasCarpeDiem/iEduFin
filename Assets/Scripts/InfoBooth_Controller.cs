using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBooth_Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] scenes;

    public void onSwitch(GameObject scene)
    {
        scene.SetActive(true);
        Debug.Log("testing 0: " + (scene == GameObject.Find("ChoicesScreen1")));

        if(scene == GameObject.Find("ChoicesScreen1"))
        {
            GameObject.Find("WelcomeScreen").SetActive(false);
        }

        if(scene == GameObject.Find("ChoicesScreen1.1") || scene == GameObject.Find("ChoicesScreen2.1"))
        {
            GameObject.Find("ChoicesScreen1").SetActive(false);
        }

    }

    public void offSwitchScreen2(GameObject scene)
    {
        scene.SetActive(true);
        Debug.Log("testing 0: " + scene.name);
        if (scene == GameObject.Find("ChoicesScreen1"))
        {
            GameObject.Find("ChoicesScreen2.1").SetActive(false);
        }

    }

    public void offSwitchScreen1(GameObject scene)
    {
        scene.SetActive(true);
        Debug.Log("testing 0: " + scene.name);
        if (scene == GameObject.Find("ChoicesScreen1"))
        {
            GameObject.Find("ChoicesScreen1.1").SetActive(false);
        }

    }

    public void onClickETF(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaBackground").SetActive(true);
        GameObject.Find("ChoicesScreen2.1").SetActive(false);
        GameObject.Find("DefaultBackground").SetActive(false);

    }

    public void onCickETFBtn1(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Use limit orders, not market orders";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text =
            "Limit orders allow you to set the price at which you are willing to trade, " +
            "while market orders will be executed at the current market price as soon as shares are available. " +
            "Market orders present the risk of paying an undesirable price, as the market price can change due to events " +
            "that are out of your control. Limit orders provide investors with greater control over their execution price.";
        GameObject.Find("ETF_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);
        
    }

    public void onCickETFBtn2(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Do not trade when the market is volatile";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = "The market tends to be particularly volatile during the first and l" +
            "ast 15 minutes of the trading day so, generally speaking, it’s a good idea to avoid trading during that time. " +
            "In the morning, ETFs are going through a “price discovery” phase — comparing the previous day’s closing price with the " +
            "current net asset value price, and, at the same time, factoring in changes to the value of the underlying holdings. " +
            "At the end of the trading day, large investors may begin to hedge their positions, which can result in rapid price " +
            "changes and widening bid/ask spreads. Overall, trading ETFs during market volatility is best avoided because it " +
            "can cause the bid/ask spread to widen.";
        GameObject.Find("ETF_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);

    }

    public void onCickETFBtn3(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Trade ETFs with international exposure when underlying markets are open";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = "Most international markets close by the afternoon for investors " +
            "in the Toronto region. If the market is closed, then market makers are pricing based on estimates and assumptions, " +
            "as they cannot hedge until the following day. Market makers do not know exactly what the price is going to be when " +
            "those markets open, and whenever there is uncertainty, you can be sure that some measure of risk premium is attached to the price of the security.";
        GameObject.Find("ETF_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);

    }

    public void onCickETFBtn4(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Watch the bid/ask spread";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = "At any given time, there are two prices for an ETF: " +
            "the price at which someone is willing to buy (the “bid”) and the price at which someone is willing to sell (the “ask”). " +
            "The difference between these two prices is called the “spread.” The spreads exists because, as in any open market, investors " +
            "try to negotiate the best price. Spreads widen and narrow for various reasons. Popular ETFs with strong trading volume may have narrower spreads, " +
            "while less popular, thinly traded ETFs may have wider spreads. However, the underlying market is typically the best determining factor or indicator of spreads. " +
            "It’s important to remember that your quote may not provide you with complete volume data (see below for more on this).";
        GameObject.Find("ETF_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);

    }

    public void onCickETFBtn5(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Your ETF data may not be complete";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = "In Canada, the majority of investors and advisors do not have the ability to " +
            "see an ETF’s consolidated bid/ask spread or trading volume. This means that advisors are not seeing every available quote, all the trading volume or the " +
            "existing liquidity on various exchanges. One exchange could be posting more volume and a better price, but you may not be aware of that based on the available data. " +
            "This inability to see the complete picture can drastically affect how you view an ETF’s liquidity and trading volume.";
        GameObject.Find("ETF_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);

    }

    public void onCickETFBtn6(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Don’t forget about holidays";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = "Many ETFs that trade on Canadian stock exchanges hold U.S. " +
            "and other international securities. There may be days when the ETF will trade on a Canadian exchange even though it is a holiday in the country where " +
            "the underlying securities trade. This can cause bid/ask spreads to widen.";
        GameObject.Find("ETF_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);

    }

    public void onCickETFBtn7(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Be aware of political and economic announcements";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = "Macroeconomic news, political shifts or even tweets from the current U.S. " +
            "president can introduce greater market fluctuations, affect the price of securities and potentially widen bid/ask spreads for ETFs.";
        GameObject.Find("ETF_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);

    }

    public void onCickETFBtn8(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Remember, you’re human";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = "Behavioural finance is more than just a fancy term — it has a real effect on investor behaviour. " +
            "The key is to keep your emotions in check and focus on quantitative analysis and your long-term plan. When trading ETFs, it’s important to keep the bigger picture in mind. " +
            "Recognizing and understanding the various elements that could impact your trades can help you make the most of your trading practices. When in doubt, speak to the ETF provider, " +
            "as they will be happy to assist and answer any questions you may have.";
        GameObject.Find("ETF_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);

    }

    public void onClickCryptoBtn1(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Take Care of Your Wallet";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = "The purchased cryptocurrency needs to be stored somewhere. " +
            "Ways and the options are endless, but first, you need to know about two types: light and heavy purses. If you are going to buy a “souvenir” amount of currency, the safety of which you will not " +
            "have nightmares about, the light purse, available directly from your phone, is a great option. It is best to choose a proven solution with a good rating and reviews, just like FoPay. " +
            "Important — before making the final choice we advise you to make sure that the wallet allows you to transfer the account or wallet to another device, and you are satisfied with the rate of inputting or outputting the currency. " +
            "If you have a significant amount on hand, that has been accumulated over several years and want to transfer it to digital coins, here we advise you to spend time reading the instructions and allocate " +
            "space on your hard drive for the installation of a full (heavy) wallet for the selected cryptocurrency. This is the most secure option, as in fact, you download all your coins to your PC, where they are stored " +
            "and regularly communicate with the server for verification.";
        GameObject.Find("Crypto_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);
    }

    public void onClickCryptoBtn2(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Do not buy the cryptocurrency at the point of “take-off”";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = "THearing from a friend or your favorite crypto Magazine that bitcoin has set a " +
            "new growth record, do not hurry to register a wallet and look for an exchange office. Any cryptocurrency after a sharp rise either going through a correction or a strong enough fall. " +
            "But in any case, the chance that you will have time to run into a rushing train is always less than the chance that the idea will end in failure and disappointment. It is much more reasonable to wait for the " +
            "moment of decline in your chosen currency and buy it at the lowest price.";
        GameObject.Find("Crypto_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);
    }

    public void onClickCryptoBtn3(GameObject scene)
    {
        scene.SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").SetActive(true);
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(1).GetComponent<TextMesh>().text = "Do not buy the cryptocurrency at the point of “take-off”";
        GameObject.Find("DisplayAreaScreen(Alt)").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = "No one can say for sure what will happen to Bitcoin in a year, " +
            "five years or a quarter of a century. However, only the Bitcoin (cryptocurrency) has the highest credibility today. Dubious rumors are pushing the new traders to risky actions for the sale " +
            "of Bitcoin and the purchase of other coins with the hope of a sharp enrichment, which does not always end this way. If you are in this category recently, we strongly recommend that you " +
            "keep most of the investment (at least 50%) in it.";
        GameObject.Find("Crypto_choice").SetActive(false);
        GameObject.Find("DisplayAreaBackground").SetActive(false);
    }
}
