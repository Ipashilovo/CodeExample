using System.Collections.Generic;
using AppsFlyerSDK;
using UI.Kapcha;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Monetization
{
    public class BuyNoAdsButton : MonoBehaviour
    {
        [SerializeField] private KapchaScreen _kapchaScreen;

        private void OnEnable()
        {
            _kapchaScreen.FilledCorrect += InitiatePurchase;
        }

        private void OnDisable()
        {
            _kapchaScreen.FilledCorrect -= InitiatePurchase;
        }

        private void InitiatePurchase()
        {
            CodelessIAPStoreListener.Instance.InitiatePurchase(MonetizationData.NoAdsProductID);
        }

        public void OnSuccess(Product _product)
        {
            MonetizationData.SetNoAdsBought();
            //AppMetrica
            var metrica = AppMetrica.Instance;
            var parametrs = new Dictionary<string, object>
            {
                {"inapp_id","no_ads"},
                {"currency",_product.metadata.isoCurrencyCode},
                {"price", (double)_product.metadata.localizedPrice},
                {"inapp_type","noads"}
            };
            var revenue = new YandexAppMetricaRevenue(_product.metadata.localizedPrice,
                _product.metadata.isoCurrencyCode);
            var yandexAppMetricaAndroid = new YandexAppMetricaAndroid();
            //AppsFlyer//
            var purchaseEvent = new Dictionary<string, string>
            {
                {"af_revenue", _product.metadata.localizedPriceString},
                {"af_currency", _product.metadata.isoCurrencyCode},
                {"af_quantity", "1"},
                {"af_content_id", "001"},
                {"order_id", "9277"},
                {"af_receipt_id", "9277"}
            };
            AppsFlyer.sendEvent("af_purchase", purchaseEvent);
            /////
            try
            {
                yandexAppMetricaAndroid.ReportRevenue(revenue);
            
            }
            catch
            {
                // ignored
            }

            try
            {
                metrica.ReportEvent("payment_succeed",parametrs);
            }
            catch
            {
                // ignored
            }

            //AppMetrica
        
            Debug.Log("Успешно куплено");
        }
    }
}
