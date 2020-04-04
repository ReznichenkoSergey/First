using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Classes
{
    public abstract class Autocar
    {
        public string ManufacturedCompany { get; private set; }
        public string ModelCipher { get; private set; }

        public Autocar(string manufacturedCompany, string modelCipher)
        {
            ManufacturedCompany = manufacturedCompany;
            ModelCipher = modelCipher;
        }

        public virtual string GetFullName()
        {
            return $"{ManufacturedCompany}, {ModelCipher}";
        }

    }
}
