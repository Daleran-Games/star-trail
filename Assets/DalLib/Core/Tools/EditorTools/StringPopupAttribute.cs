using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class StringPopupAttribute : PropertyAttribute
    {
        public readonly string[] options;

        public StringPopupAttribute(params string[] options)
        {
            this.options = options;
        }

    }
}

