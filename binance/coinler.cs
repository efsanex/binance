using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binance
{
    class coinler
    {

        string coinAdi_;
        decimal coinFiyati_;

        public string coinAdi
        {
            get
            {
                return coinAdi_;
            }

            set
            {
                coinAdi_ = value;
            }
        }

        public decimal coinFiyati
        {
            get
            {
                return coinFiyati_;
            }

            set
            {
                coinFiyati_ = value;
            }
        }
    }
}
