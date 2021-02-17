using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace User_registration_by_Nesa
{
    class PaymentClass
    {
        private decimal _Subtotal;
        private decimal _ServiceTax;
        private decimal _GST;
        private decimal _Rounding;
        private decimal _GrandTotal;
        private string _SelectedFood;
        private string _SelectedIce;
        private string _SelectedExp;
        private string _IceSize;
        private string _ExpSize;
        private int _FoodQuantity;
        private int _IceQuantity;
        private int _ExpQuantity;
        private decimal _FoodPrice;
        private decimal _IcePrice;
        private decimal _ExpPrice;
        private decimal _TotalFoodPrice;
        private decimal _TotalIcePrice;
        private decimal _TotalExpPrice;

        public decimal Subtotal
        {
            get
            {
                return _Subtotal;
            }
            set
            {
                _Subtotal = value;
            }
        }

        public decimal ServiceTax
        {
            get
            {
                return _ServiceTax;
            }
            set
            {
                _ServiceTax = value;
            }
        }

        public decimal GST
        {
            get
            {
                return _GST;
            }
            set
            {
                _GST = value;
            }
        }

        public decimal Rounding
        {
            get
            {
                return _Rounding;
            }
            set
            {
                _Rounding = value;
            }
        }

        public decimal GrandTotal
        {
            get
            {
                return _GrandTotal;
            }
            set
            {
                _GrandTotal = value;
            }
        }

        public string SelectedFood
        {
            get
            {
                return _SelectedFood;
            }
            set
            {
                _SelectedFood = value;
            }
        }

        public string SelectedIce
        {
            get
            {
                return _SelectedIce;
            }
            set
            {
                _SelectedIce = value;
            }
        }

        public string SelectedExp
        {
            get
            {
                return _SelectedExp;
            }
            set
            {
                _SelectedExp = value;
            }
        }

        public string IceSize
        {
            get
            {
                return _IceSize;
            }
            set
            {
                _IceSize = value;
            }
        }

        public string ExpSize
        {
            get
            {
                return _ExpSize;
            }
            set
            {
                _ExpSize = value;
            }
        }

        public int FoodQuantity
        {
            get
            {
                return _FoodQuantity;
            }
            set
            {
                _FoodQuantity = value;
            }
        }

        public int IceQuantity
        {
            get
            {
                return _IceQuantity;
            }
            set
            {
                _IceQuantity = value;
            }
        }

        public int ExpQuantity
        {
            get
            {
                return _ExpQuantity;
            }
            set
            {
                _ExpQuantity = value;
            }
        }

        public decimal FoodPrice
        {
            get
            {
                return _FoodPrice;
            }
            set
            {
                _FoodPrice = value;
            }
        }

        public decimal IcePrice
        {
            get
            {
                return _IcePrice;
            }
            set
            {
                _IcePrice = value;
            }
        }

        public decimal ExpPrice
        {
            get
            {
                return _ExpPrice;
            }
            set
            {
                _ExpPrice = value;
            }
        }

        public decimal TotalFoodPrice
        {
            get
            {
                return _TotalFoodPrice;
            }
            set
            {
                _TotalFoodPrice = value;
            }
        }

        public decimal TotalIcePrice
        {
            get
            {
                return _TotalIcePrice;
            }
            set
            {
                _TotalIcePrice = value;
            }
        }

        public decimal TotalExpPrice
        {
            get
            {
                return _TotalExpPrice;
            }
            set
            {
                _TotalExpPrice = value;
            }
        }

        /*
        public decimal CalcSubtotal()
        {
            Subtotal = FoodPrice + IcePrice + ExpPrice;
            return Subtotal;
        }*/

        public decimal CalcDiscount()
        {
            Subtotal = Subtotal * 90 / 100;
            Subtotal = Math.Round(Subtotal, 2);
            return Subtotal;
        }

        public decimal CalcServiceTax()
        {
            ServiceTax = Subtotal * 10 / 100;
            ServiceTax = Math.Round(ServiceTax, 2);
            Subtotal += ServiceTax;
            return Subtotal;
        }

        public decimal CalcGST()
        {
            GST = Subtotal * 6 / 100;
            GST = Math.Round(GST, 2);
            Subtotal += GST;
            return Subtotal;
        }

        // ref :https://rextester.com/FXERL73836
        //Below is the code for rounding mechanism to work.

        public decimal RoundOff()
        {
            Subtotal = Subtotal * 20;
            Subtotal = Math.Round(Subtotal, MidpointRounding.AwayFromZero);
            Subtotal = Subtotal / 20;
            return Subtotal;
        }
    }
}
