using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace onlineCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class calculatorController : ControllerBase
    {
        // GET api/calculator/
        [HttpGet("")]
        public ActionResult<string> firstPage()
        {
            string str = "welcome, ohad aizik, 305088080";
            return str;
        }

        // GET api/calculator/GetFiveRandomNumbers
        [HttpGet("GetFiveRandomNumbers")]
        public List<int> GetFiveRandomNumbers()
        {
            var numbers = new List<int>();
            var rnd = new Random();
            int count = 0;
            while (count < 5)
            {
                int newNum = rnd.Next(1, 21); // generate a random number between 1- 20
                if (!numbers.Contains(newNum))
                {
                    numbers.Add(newNum);
                    count++;
                }
            }
            return numbers;
        }

        // GET api/calculator/turnToCamelCase function 1
        [HttpGet("turnToCamelCase")]
        public ActionResult<string> turnToCamelCase(string str)
        {
            char[] strArray = str.ToCharArray();

            for (int i = 1; i < strArray.Count(); i++)
            {
                strArray[i] = i == 0 || strArray[i - 1] == ' ' ? char.ToUpper(strArray[i]) : strArray[i];
            }
            for (int i = 1; i < strArray.Count(); i++)
            {
                if(strArray[i] == ' ')
                {
                    int temp = i;
                    while(temp < strArray.Count()-1)
                    {
                        strArray[temp] = strArray[temp + 1];
                        temp++;
                    }
                    strArray[strArray.Count()-1] = '\n';
                    i++;
                }
            }

            str = new string(strArray);
            return str;
        }

        // GET api/calculator/fourSympleMathReturn function 13
        // i asumed that the function get ints, so there isent floating point in the sub
        [HttpGet("fourSympleMathReturn")]
        public ActionResult<string> fourSympleMathReturn(int num1, int num2)
        {
            string str = "+: ";
            str += num1 + num2;
            str += ", -: ";
            str += num1 - num2;
            str += ", *: ";
            str += num1 * num2;
            if (num2 != 0)
            {
                str += ", /: ";
                str += num1 / num2;
                return str;
            }
            else
            {
                str += ", calaulator crashed!";
                return str;
            }
        }

        // GET api/calculator/splitNumToFour function 14
        [HttpGet("splitNumToFour")]
        public ActionResult<string> splitNumToFour(int num)
        {
            string str;
            if ((num > 9999) && (num < 1000))
            {
                str = "invaild number";
                return str;
            }
            else
            {
                int toAdd;
                str = "the numbers: ";
                for(int i = 1000; i < 1; i /= 10)
                {
                    toAdd = num / i;
                    str += toAdd;
                    str = ", ";
                    toAdd *= 1000;
                    num -= toAdd;
                }
                return str;
            }
        }
        // GET api/calculator/returmMin function 16
        [HttpGet("returmMin")]
        public ActionResult<string> returmMin(int num1, int num2, int num3, int num4)
        {
            string str = "the minimal number is: ";
            int min, temp1, temp2;
            if(num1 > num2)
            {
                temp1 = num2;
            }
            else
            {
                temp1 = num1;
            }
            if (num3 > num4)
            {
                temp2 = num4;
            }
            else
            {
                temp2 = num3;
            }
            if(temp1 > temp2)
            {
                min = temp2;
            }
            else
            {
                min = temp1;
            }
            str += min;
            return str;
        }

        // GET api/calculator/consecutiveNumbers function 19
        [HttpGet("consecutiveNumbers")]
        public ActionResult<string> consecutiveNumbers(int top)
        {
            string str;
            int counter = 2;
            if (top < 1)
            {
                str = "invaild number!";
                return str;
            }
            str = "the consecutive: ";
            str += 1;
            while(counter < top)
            {
                str += ", ";
                str += counter;
                counter++;
            }
            return str;
        }
    }
}
