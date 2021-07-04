using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaleranGames.StarTrail
{
    public class StockCounter : MonoBehaviour
    {
        [SerializeField]
        private string _stockName;

        [SerializeField]
        private Text _text;

        private Stock _stock;

        Signal _stockChangedSig;

        // Start is called before the first frame update
        private void OnEnable()
        {
            _stockChangedSig = OnStockChanged;
            Signals.Listen(Stock.ChangedSignal(_stockName), _stockChangedSig);
        }

        private void Start()
        {
            if(_stock == null)
            {
                var data = (SignalData<Stock>)Signals.Raise(new SignalData<Stock>(Stock.GetSignal(_stockName), null));
                _stock = data.Data;
            }
            _text.text = _stock.CurrentValue.ToString();
        }

        // Update is called once per frame
        private void OnDisable()
        {
            Signals.Quiet(Stock.ChangedSignal(_stockName), _stockChangedSig);
        }

        public ISignalData OnStockChanged(ISignalData data)
        {
            _text.text = _stock.CurrentValue.ToString();
            return data;
        }
    } 
}
