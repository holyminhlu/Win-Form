using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormThongTin
{
    internal class XuLyDuLieu
    {
        public static void suaChuoi(ref string suaChuoi)
        {
            string resultName = "";
            //Loai bo khoang trang giua 2 dau chuoi     
            suaChuoi = suaChuoi.Trim();
            //Loai bo khoang trang o cac tu, chuyen thanh 1 khoang trang 
            while (suaChuoi.IndexOf("     ") != -1)
            {
                suaChuoi = suaChuoi.Replace("  ", " ");
            }
            // chep cac ki tu cua chuoi vao 1 mang
            string[] arrName = suaChuoi.Split(' ');
            // duyet cac phan tu trong mang
            // chuyen ky tu dau thanh viet hoa, con lai viet thuong
            for (int i = 0; i < arrName.Length; i++)
            {
                arrName[i] = arrName[i].Substring(0, 1).ToUpper() + arrName[i].Substring(1).ToLower();
                resultName += arrName[i].ToString() + " ";
            }
            suaChuoi = resultName;
        }
    }
}
