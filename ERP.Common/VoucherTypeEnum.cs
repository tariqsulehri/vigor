using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common
{
    public enum VoucherTypeEnum
    {
        JV = 001,
        CPV = 002,
        BPV = 003,
        CRV = 004,
        BRV = 005
    }
    public enum VoucherStatus
    {
        Posted = 1,
        UnPosted = 0

    }
    public enum ActiveStatus
    {
        Active = 1,
        InActive = 0
    }
    public enum CloseStatus
    {
        Close = 1,
        Open = 0
    }
    public enum InquieryStatus
    {
        All = 'A',
        InProcess = 'P',
        Active = 'Y',
        Close = 'C',
        Cancel = 'D'
    }
    public enum ContractStatus
    {
        All = 'A',
        InProcess = 'P',
        Active = 'Y',
        Close = 'C',
        Cancel = 'D',
        UnApproved = 'U'
    }
    public enum comessionType : int
    {
        P = 1,
        Q = 0
    }

    public enum DispatchType
    {
        Dispatch = 'D',
        Return = 'R'
    }
    public enum PaymentEffect
    {
        Plus = 1,
        Minus = 0,
    }
    public enum PaymentType
    {
        P = 1,
        F = 2
    }
    public static class CommonFunction
    {
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }
            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " Lac ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "And ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
    public class AboutDispatch
    {
        public Hashtable AboutDispatchReport()
        {
            Hashtable ht = new Hashtable()
            {
                { 1,"Local Dispatch[Seller Wise]" },
                { 2,"Local Dispatch[Buyer Wise]" },
                { 3,"Monthly Dispatch Summary[Seller Wise]"},
                { 4,"Monthly Dispatch Summary[Buyer Wise]"},
                { 5,"Sales Tax Invoices Not Received"},
            };
            return ht;
        }
    }
}
