using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulawayo_Storage
{
    public class NewStudent
    {
        private int _id;
        private string _name;
        private string _surname;
        private FalconCollegeHouse _house;
        private string _number;
        private int _trunks;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                try
                {
                    value = value.Replace(" ","");
                    foreach (char c in value)
                    {
                        if (c < 'A' || (c > 'Z' && c < 'a') || c > 'z')
                        {
                            throw new Exception();
                        }
                    }
                    _name = value;
                }
                catch 
                {
                    // we can do more with this later
                    throw new Exception("Please enter a value between a-z, Capitals can be included");
                }
            } 
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        public FalconCollegeHouse House
        {
            get => _house;
            set => _house = value;
        }
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                    value = value.Replace(" ","");
                    foreach (char n in value)
                    {
                        // if we are out of the range then throw and exception

                        if (n == 0x2B)
                        {
                            continue;
                        }else if (n < 0x30 || n > 0x39)
                        {
                            _number = null;
                        }
                    }
                    _number = value;
            }
        }

        public int Trunks
        {
            get => _trunks;
            set => _trunks = value;
        }
        public int Id { get => _id; set => _id = value; }
    }


    public class Parent : NewStudent
    {
        private string _email;
        private string _mobileNumber;
        private DateTime _StoragePeriod;
        private StorageOption _option;
        private MethodOfPayment _methodOfPayment;

        public string Email
        {
            get => _email;
            set
            {
                value = value.Replace(" ","");
                if (value.Contains("@"))
                {// checking that we contain the correct symbols
                    _email = value;
                }

            } 
        }

        public string GaurdianNumber
        {
            get => _mobileNumber;
            set
            {
                    value = value.Replace(" ","");
                    foreach (char n in value)
                    {
                        // if we are out of the range then throw and exception
                        if (n == 0x2B)
                        {
                            continue;
                        }else if (n < 0x30 || n > 0x39)
                        {
                            _mobileNumber = null;
                        }
                    }
                    _mobileNumber = value;
            }
}

        public StorageOption Option
        {
            get => _option;
            set => _option = value;
        }
        public MethodOfPayment MethodOfPayment
        {
            get => _methodOfPayment;
            set => _methodOfPayment = value;
        }
        public DateTime StoragePeriod
        {
            get => _StoragePeriod;
            set
            {// We have 3 periods, april holiday, august holiday, decmber Holiday
                // I have to restrict this to those values
                try
                {
                    if (value.Month == 4 || value.Month == 8 || value.Month == 12)
                    {
                        _StoragePeriod = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("The month Selected in not a valid storage period");
                    }
                }
                catch (IndexOutOfRangeException IndOutRangeExp)
                {
                    Console.WriteLine(IndOutRangeExp.Message);
                }

            }
        }
    }

    public enum FalconCollegeHouse
    {
        Hervey,
        Founders,
        GeorgeGrey,
        Oates,
        Tredgold,
        Chubb,
        Kestral
    }

    public enum StorageOption
    {
        Storage,
        StorageAndWashing
    }

    public enum MethodOfPayment
    {
        Cash,
        EcoCash,
        BankTransfer,
        StudentAccount
    }

    // have to add the type for when they stored with us, I have to make it accessable to be able to add a new storage period
}
