using System.Collections;
using UnityEngine;

namespace DaleranGames
{
    public class SignalData<T>: ISignalData
    {
        public string SignalName { get; private set; }
        public T Data { get; set; }

        public SignalData (string signalName, T data)
        {
            SignalName = signalName;
            Data = data;
        }
    }

    public class SignalData<T1, T2>: ISignalData
    {
        public string SignalName { get; private set; }
        public T1 Data { get; set; }
        public T2 Data2 { get; set; }

        public SignalData(string signalName, T1 data, T2 data2)
        {
            SignalName = signalName;
            Data = data;
            Data2 = data2;
        }
    }
}