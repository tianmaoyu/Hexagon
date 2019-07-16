using NPinyin;
using System;
using System.Text;


/// <summary>
/// http://ascii.911cha.com/
/// </summary>
namespace Character
{
    class Program
    {
        static void Main(string[] args)
        {
            var pinyin0 = NameConvert("田maoyu @$%^&..dd你好");
            var p = NameCut(pinyin0);
            var pinyin = NameConvert("我是中国人");
            var pinyin1 = NameConvert("@#$%^&*(ti");
            var pinyin2 = NameConvert("sdf5446512sdf");
            var pinyin3 = NameConvert("田茂宇");
            var pinyin4 = NameConvert("tian maoyu ");
            var pinyin5 = NameConvert("5156村长");
            Console.WriteLine(pinyin);
        }



        /// <summary>
        /// 名字裁剪，名字太长，大于14的个裁中间
        /// </summary>
        /// <param name="nameStr"></param>
        /// <returns></returns>
        public static string NameCut(string nameStr)
        {
            if (nameStr.Length > 13)
            {
                return nameStr.Substring(0, 11) + "*";
            }
            return nameStr;
        }



        /// <summary>
        /// 只留 字母，数字，汉字转拼音
        /// </summary>
        /// <param name="nameStr"></param>
        /// <returns></returns>
        public static string NameConvert(string nameStr)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < nameStr.Length; ++i)
            {
                var ch = nameStr[i];
                if (IsNumber(ch))
                {
                    stringBuilder.Append(ch);
                    continue;
                }
                if (IsLetter(ch))
                {
                    stringBuilder.Append(ch);
                    continue;
                }
                if (IsChineseChar(ch))
                {
                    var pinyinStr = Pinyin.GetPinyin(nameStr[i]);
                    stringBuilder.Append(pinyinStr);
                    continue;
                }
                //其他的使用*
                stringBuilder.Append('*');
            }

            return stringBuilder.ToString();
        }


        /// <summary>
        /// 数字
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static bool IsNumber(char ch)
        {
            return ch <= 57 && ch >= 48;
        }

        /// <summary>
        /// 字母
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static bool IsLetter(char ch)
        {
            return  (ch <= 65 && ch >= 90) || (ch <= 122 && ch >= 97);
        }

        /// <summary>
        /// 中文
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static bool IsChineseChar(char ch)
        {
            return ch >= 0x4e00 && ch <= 0x9fbb;
        }
    }
}
