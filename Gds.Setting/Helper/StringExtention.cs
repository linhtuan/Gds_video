using System;
using System.Text;

namespace Gds.Setting.Helper
{
    public static class StringExtention
    {
        public static string ConvertTime<T>(this T obj)
        {
            if (obj == null) return string.Empty;
            var number = Convert.ToInt64(obj);
            string result;
            if (number > 60 * 1000 * 60)
            {
                result = string.Format("{0}h {1}p", (int)TimeSpan.FromMilliseconds(number).TotalHours, TimeSpan.FromMilliseconds(number).TotalMinutes);
            }
            else if (number > 60 * 1000)
            {
                result = string.Format("{0}p {1}s", (int)TimeSpan.FromMilliseconds(number).TotalMinutes, TimeSpan.FromMilliseconds(number).Seconds);
            }
            else
            {
                result =  string.Format("{0}s", TimeSpan.FromMilliseconds(number).Seconds);
            }
            return result;
        }

        public static string ConvertTimeOneVideo<T>(this T obj)
        {
            if (obj == null) return string.Empty;
            var number = Convert.ToInt64(obj);
            var result = string.Empty;
            if (number > 60 * 1000 * 60)
            {
                var hour = (int) TimeSpan.FromMilliseconds(number).TotalHours;
                var minutes = TimeSpan.FromMilliseconds(number).TotalMinutes;
                result = string.Format("{0}:{1}", hour >= 10 ? hour.ToString() : string.Format("0{0}", hour),
                    minutes >= 10 ? minutes.ToString() : string.Format("0{0}", minutes));
            }
            else if (number > 60 * 1000)
            {
                var minutes = (int)TimeSpan.FromMilliseconds(number).TotalMinutes;
                var seconds = TimeSpan.FromMilliseconds(number).Seconds;
                result = string.Format("{0}:{1}", minutes >= 10 ? minutes.ToString() : string.Format("0{0}", minutes),
                    seconds >= 10 ? seconds.ToString() : string.Format("0{0}", seconds));
            }
            return result;
        }

        public static string BindingRating<T>(this T obj)
        {
            if (obj == null) return string.Empty;
            var number = Convert.ToDouble(obj);
            var str = new StringBuilder();
            for (var i = 0; i < Convert.ToInt32(number); i++)
            {
                str.Append("<i class='fa fa-star rated'></i>");
            }
            for (var i = 0; i < 5 - Convert.ToInt32(number); i++)
            {
                str.Append("<i class='fa fa-star'></i>");
            }
            return str.ToString();
        }
    }
}
