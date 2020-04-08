using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Classes
{
    public abstract class Autocar
    {
        public AutoCompany ManufacturedCompany { get; private set; }
        public string ModelCipher { get; private set; }

        public EngineTypes EngineType { get; private set; }

<<<<<<< HEAD
        public Autocar(AutoCompany manufacturedCompany, string modelCipher, EngineTypes engineTypes)
=======
        public decimal EngineVolume { get; private set; }

        public Autocar(string manufacturedCompany, string modelCipher, EngineTypes engineTypes = EngineTypes.Gas, decimal engineVolume = 2)
>>>>>>> 1c25bc0404f337966759a96884c71694ffa414f8
        {
            ManufacturedCompany = manufacturedCompany;
            ModelCipher = modelCipher;
            EngineType = engineTypes;
            EngineVolume = engineVolume;
        }

        public virtual string GetFullName()
        {
            return $"{ManufacturedCompany}, {ModelCipher}";
        }

    }
}
