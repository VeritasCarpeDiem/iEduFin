using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OpenLink : MonoBehaviour
{
    [SerializeField] public List<GameObject> stockLinks;
    [SerializeField] public List<GameObject> stock2Links;
    [SerializeField] public List<GameObject> cryptoLinks;
    [SerializeField] public List<GameObject> precautionLinks;

    string[] stockURLs =
    {
        "https://money.usnews.com/investing/investing-101/articles/investing-in-stocks-for-beginners",
        "https://www.forbes.com/advisor/investing/how-to-invest-in-stocks/",
        "https://www.youtube.com/watch?v=bJHr6_skXWc",
        "https://www.youtube.com/watch?v=giGcuofIYis",
        "https://www.youtube.com/watch?v=gFQNPmLKj1k"
    };

    string[] stock2URLs =
    {
        "https://www.investopedia.com/investing/investing-strategies/",
        "https://money.usnews.com/investing/investing-101/slideshows/how-to-pick-stocks-things-all-beginner-investors-should-know",
        "https://www.youtube.com/watch?v=j38ZXGcZ9u4",
        "https://www.youtube.com/watch?v=DlA2jMueIyc",
        "https://www.youtube.com/watch?v=eynxyoKgpng"
    };

    string[] cryptoURLs =
    {
        "https://www.fool.com/investing/stock-market/market-sectors/financials/cryptocurrency-stocks/how-to-invest-in-cryptocurrency/",
        "https://www.nerdwallet.com/article/investing/cryptocurrency",
        "https://www.business2community.com/cryptocurrency/invest-in-cryptocurrency",
        "https://www.youtube.com/watch?v=Yb6825iv0Vk",
        "https://www.youtube.com/watch?v=iFIqffaaSH8",
        "https://www.youtube.com/watch?v=-Hbu2nKVJR0"
    };

    string[] precautionURLs =
    {
        "https://www.zeebiz.com/personal-finance/news-investment-precautions-you-must-take-to-ensure-best-returns-avoid-risks-of-losing-hard-earned-money-98245",
        "https://www.investopedia.com/articles/fundamental-analysis/08/risk-warnings.asp",
        "https://www.goodreturns.in/personal-finance/investment/2017/09/6-precautions-take-when-investing-the-stock-market-617791.html",
        "https://www.youtube.com/watch?v=ZHEyRiY7Jdc",
        "https://www.youtube.com/watch?v=yFMF7qtQqMo",
        "https://www.youtube.com/watch?v=A7fZp9dwELo"
    };
    public void OpenWebpage(GameObject link)
    {
        if (stockLinks.Contains(link))
        {
            int index = stockLinks.IndexOf(link);
            Application.OpenURL(stockURLs[index]);
        }
        else if (stock2Links.Contains(link))
        {
            int index = stock2Links.IndexOf(link);
            Application.OpenURL(stock2URLs[index]);
        }
        else if (cryptoLinks.Contains(link))
        {
            int index = cryptoLinks.IndexOf(link);
            Application.OpenURL(cryptoURLs[index]);
        }
        else
        {
            int index = precautionLinks.IndexOf(link);
            Application.OpenURL(precautionURLs[index]);
        }
    }
}
