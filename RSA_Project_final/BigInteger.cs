using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Project_final
{
    class BigInteger
    {
        public BigInteger() { }
        // add by using array
        public string Add(string x, string y)//(N)
        {
            int sz = Math.Max(x.Length, y.Length) + 1; //O(1)
            char[] res = new char[sz];                //O(1)
            int carry = 0, xsz = x.Length, ysz = y.Length, sumchar, res_indx = 0;//O(1)
            for (int i = 0; i < sz - 1; i++)//O(N)
            {
                int n1, n2;//O(1)
                if (i < xsz)//O(1)
                    n1 = x[xsz - 1 - i] - '0';//O(1)
                else
                    n1 = 0;//O(1)
                if (i < ysz)//O(1)
                    n2 = y[ysz - 1 - i] - '0';//O(1)
                else
                    n2 = 0;//O(1)
                sumchar = n1 + n2 + carry;//O(1)
                if (sumchar > 9)//O(1)
                {
                    sumchar -= 10;//O(1)
                    carry = 1;//O(1)
                }
                else
                    carry = 0;//O(1)
                res[sz - 1 - res_indx++] = (char)(sumchar + '0');//O(1)


            }
            if (carry == 1)//O(1)
                res[sz - 1 - res_indx++] = '1';//(1)
            return new string(res, sz - res_indx, res_indx);//(N)

        }
        public string subtract(string x, string y)//O(N+N)=O(N)
        {
            bool negative = sign(x, y);  //O(N)
            char[] ans = new char[Math.Max(x.Length, y.Length) + 1];//(1)
            int ans_indx = 0;//(1)
            if (negative)//O(1)
            {
                string temp = x;//(1)
                x = y;//(1)
                y = temp;//(1)
            }
            int szx = x.Length, szy = y.Length, carry = 0;//(1)
            int szdiff = szx - szy, sub_val;//(1)
            for (int i = szy - 1; i >= 0; i--)//(N)
            {
                sub_val = (x[i + szdiff] - '0') - (y[i] - '0') - carry;//(1)
                if (sub_val < 0)//(1)
                {
                    carry = 1;//(1)
                    sub_val += 10;//(1)
                }
                else
                    carry = 0;//(1)
                ans[ans_indx++] = (char)(sub_val + '0');//(1)
            }
            for (int i = szx - szy - 1; i >= 0; i--)//(N)
            {
                if (x[i] == '0' && carry > 0)//(1)
                {
                    ans[ans_indx++] = '9';//(1)
                }
                else
                {
                    sub_val = ((x[i] - '0') - (0) - carry);//(1)
                    // here will add to array only when ans of sub will not be zero 
                    if (i > 0 || sub_val > 0)//(1)
                        ans[ans_indx++] = (char)(sub_val + '0');//(1)
                    carry = 0;//(1)
                }
            }
            string final_ans = new string(ans, 0, ans_indx);//(N)
            final_ans = reverseString(final_ans);//(N)
            // here will be leading zero so we delete it
            final_ans = deletestringzero(final_ans);//(N)
            return final_ans;//(1)

        }
        public string deletestringzero(string a) //O(N)
        {
            int cnt = 0;//(1)
            for (int i = 0; i < a.Length - 1; i++)//O(N)
            {
                if (a[i] != '0')//(1)
                    break;//(1)
                cnt++;//(1)
            }
            char[] ans = new char[a.Length - cnt];//(1)
            for (int i = 0, j = cnt; j < a.Length; j++, i++)//(1)
                ans[i] = a[j];//(1)

            return new string(ans);//(N)
        }
        public string reverseString(string a)//O(N)
        {
            char[] ans = a.ToCharArray();
            Array.Reverse(ans);        //O(N)
            return new string(ans);   //O(1)
        }
        static bool sign(string a, string b)//O(N)
        {
            int sz1 = a.Length, sz2 = b.Length;//O(1)

            if (sz1 < sz2)//O(1)
                return true;//O(1)
            if (sz2 < sz1)//O(1)
                return false;//O(1)

            for (int i = 0; i < sz1; i++)//O(1)
            {
                if (a[i] < b[i])//O(1)
                    return true;//O(1)

                else if (a[i] > b[i])//O(1)
                    return false;//O(1)
            }
            return false;//O(1)
        }


        public void compeleteZerosfirst(ref string s, int n)//O(N)
        {
            char[] arr = new char[n + s.Length];//O(1)
            for (int i = 0; i < n; i++)//O(N)
                arr[i] = '0';//O(1)
            for (int i = n, j = 0; j < s.Length; j++, i++)//O(N)
                arr[i] = s[j];//O(1)
            s = new string(arr);//O(N)
        }
        public string Mul(string s1, string s2)//T(N)=3T(N/2)+CN+C2=O(N^1.58)master method
        {

            int xcnt = s1.Length, ycnt = s2.Length, dif = 0;//O(1)
            if (xcnt > ycnt)//O(1)
            {
                dif = xcnt - ycnt;//O(1)
                compeleteZerosfirst(ref s2, dif);//O(N)
            }
            else if (ycnt > xcnt)//O(1)
            {
                dif = ycnt - xcnt;//O(1)
                compeleteZerosfirst(ref s1, dif);//O(N)
            }
            if (s1.Length == s2.Length && s1.Length == 1)          //O(1)
            {
                long x = 1, y = 1;//O(1)
                x = s1[0] - '0';//O(1)
                y = s2[0] - '0';//O(1)
                long answer = x * y;//O(1)
                return answer.ToString();//O(1) cuz string will only 1 or 2 numbers
            }

            string a = "", b = "", c = "", d = ""; //O(1)

            a = s1.Substring(0, (s1.Length) / 2);//O(N)
            b = s1.Substring(s1.Length / 2, s1.Length - (s1.Length / 2));//O(N)

            c = s2.Substring(0, (s2.Length) / 2);//O(N)
            d = s2.Substring(s2.Length / 2, s2.Length - (s2.Length / 2));//O(N)

            string m1 = Mul(a, c);    //T(N/2)
            string m2 = Mul(b, d);    //T(N/2)
            string z = Mul(Add(a, b), Add(c, d)); //T(N/2)
            string w;//= subtract(z, Add(m1, m2));
            w = subtract(subtract(z, m1), m2);//O(N)

            int m1size = m1.Length + 2 * (s1.Length - s1.Length / 2);//O(1)
            int wsize = w.Length + s1.Length - s1.Length / 2;//O(1)
            char[] m1_temp = new char[m1size];//O(1)
            char[] w_temp = new char[wsize];//O(1)
            for (int i = 0; i < m1.Length; i++)//O(N)
                m1_temp[i] = m1[i];//O(1)
            for (int i = 0; i < w.Length; i++)//O(N)
                w_temp[i] = w[i];//O(1)
            for (int i = 0, j = m1.Length; i < 2 * (s1.Length - s1.Length / 2); i++, j++)//O(N)
                m1_temp[j] = '0';//O(1)
            for (int i = 0, j = w.Length; i < s1.Length - s1.Length / 2; i++, j++)//O(N)
                w_temp[j] = '0';//O(1)

            m1 = new string(m1_temp);//O(N)
            w = new string(w_temp);//O(N)

            string ans = Add(Add(m1, m2), w);//O(N)
            ans = deletestringzero(ans);//O(N)

            return ans;
        }
        public void div(string a, string b, ref string q, ref string r)
        {
            if (b == "0")//O(1)
            {
                DivideByZeroException ze = new DivideByZeroException();//O(1)
                throw ze;//O(1)
            }
            if (sign(a, b))//O(N)
            {
                q = "0";//O(1)
                r = a;//O(1)
                return;//O(1)
            }


            div(a, Add(b, b), ref q, ref r);
            q = Add(q, q);//O(N)
            if (sign(r, b))//O(N)
            {
                return;//O(1)
            }

            else
            {
                q = Add(q, "1");//O(N)
                r = subtract(r, b);//O(N)
                return;//O(1)
            }


        }





        public bool MulnDivResultSign(ref string x, ref string y) // No Need for this if Unsigned
        {
            if (x[0] == '-' && y[0] == '-')
            {
                x = x.Substring(1);
                y = y.Substring(1);
                return true;
            }
            else if (x[0] != '-' && y[0] != '-')
            {
                return true;
            }
            else
            {
                if (x[0] == '-')
                    x = x.Substring(1);
                else
                    y = y.Substring(1);
                return false;
            }

        }

        public string fastpower(string n, string p, string mod)
        {
            if (p == "0")//O(1)
                return "1";//O(1)
            if (n == "0")//O(1)
                return "0";//O(1)
            string division = "", reminder = "", result = "";//O(1)
            div(p, "2", ref division, ref reminder);////O(NlogN)
            if (reminder == "0")//O(1)
            {
                result = fastpower(n, division, mod);//T(N/2)  m4 mot2kd ?
                // result= res*res, = ((res%M)*(res%M))%M
                div(result, mod, ref division, ref reminder);//O(NlogN)
                result = Mul(reminder, reminder);//O(N^1.5)
                div(result, mod, ref division, ref reminder);//O(NlogN)
                result = reminder;//O(1)
            }
            else if (reminder == "1")//O(1)
            {

                string aa = division, bb = reminder, cc = "", dd = "";//O(1)
                div(n, mod, ref division, ref reminder);//O(NlogN)
                result = reminder;//O(1)
                string k = fastpower(n, aa, mod);
                div(k, mod, ref dd, ref cc);
                k = cc;
                string second = Mul(k, k);
                div(second, mod, ref dd, ref cc);
                second = cc;
                result = Mul(result, second);
                div(result, mod, ref division, ref reminder);
                result = reminder;
            }
            return result;

        }

        public string Encrypt(string n, string e, string m)
        {
            return fastpower(n, e, m);
        }
        public string Decrypt(string n, string d, string m)
        {
            return fastpower(n, d, m);
        }
    }
}
