using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Classes
{
    public abstract class Autocar
    {
        public string ManufacturedCompany { get; private set; }
        public string ModelCipher { get; private set; }

        public EngineTypes EngineType { get; private set; }

        public Autocar(string manufacturedCompany, string modelCipher, EngineTypes engineTypes)
        {
            ManufacturedCompany = manufacturedCompany;
            ModelCipher = modelCipher;
            EngineType = engineTypes;
        }

        public virtual string GetFullName()
        {
            return $"{ManufacturedCompany}, {ModelCipher}";
        }

    }
}
