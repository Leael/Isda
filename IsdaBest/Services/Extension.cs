﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsdaBest.Services
{
    public static class Extension
    {
        public static readonly string AssetsDir = Path.Combine(Environment.CurrentDirectory, "Assets");
        public static readonly string ImagesDir = Path.Combine(AssetsDir, "Images");
        public static readonly string TempDir = Path.Combine(AssetsDir, "~Temp");
        public static readonly string TransferModel = Path.Combine(AssetsDir, "transfer_model.zip");

        public static readonly string Depencencies = Path.Combine(Environment.CurrentDirectory, "x64");
        public static readonly string Concrt140 = Path.Combine(Depencencies, "concrt140.dll");
        public static readonly string Cvextern = Path.Combine(Depencencies, "cvextern.dll");
        public static readonly string Msvcp140 = Path.Combine(Depencencies, "msvcp140.dll");
        public static readonly string Msvcp140_1 = Path.Combine(Depencencies, "msvcp140_1.dll");
        public static readonly string Msvcp140_2 = Path.Combine(Depencencies, "msvcp140_2.dll");
        public static readonly string Msvcp140_codecvt_ids = Path.Combine(Depencencies, "msvcp140_codecvt_ids.dll");
        public static readonly string OpenCV_videoio_ffmpeg420_64 = Path.Combine(Depencencies, "opencv_videoio_ffmpeg420_64.dll");
        public static readonly string VCruntime140 = Path.Combine(Depencencies, "vcruntime140.dll");
        public static readonly string VCruntime140_1 = Path.Combine(Depencencies, "vcruntime140_1.dll");

        public static class Helpers
        {
            #region Serializer

            private const string FragmentOpening = "–—";
            private const string FragmentClosing = "—–";
            private const string UIDCharset = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"; // 128 kabuok

            internal static readonly DateTime DefaultDateTime = new DateTime(1999, 1, 20);

            internal const int DateTimeLength = 14;
            internal const int DefaultGuidLength = 10;

            internal static string[] Split(string data, params int[] lengths)
            {
                int sizes = 0;
                foreach (int size in lengths) sizes += size;
                if (sizes != data.Length) throw new Exception("Split error");

                string[] datas = new string[lengths.Length];
                int lastIndex = 0;
                for (int i = 0; i < datas.Length; i++)
                {
                    datas[i] = data.Substring(lastIndex, lengths[i]);
                    lastIndex += lengths[i];
                }
                return datas;
            }

            internal static string EncodeDateTime(DateTime dateTime)
            {
                string data = "";
                data += dateTime.Year.ToString("0000");
                data += dateTime.Month.ToString("00");
                data += dateTime.Day.ToString("00");
                data += dateTime.Hour.ToString("00");
                data += dateTime.Minute.ToString("00");
                data += dateTime.Second.ToString("00");
                return data;
            }

            internal static DateTime DecodeDateTime(string data)
            {
                try
                {
                    if (data.Length != DateTimeLength) return DefaultDateTime;
                    string[] datas = Split(data, 4, 2, 2, 2, 2, 2);
                    int year = Convert.ToInt32(datas[0]);
                    int month = Convert.ToInt32(datas[1]);
                    int day = Convert.ToInt32(datas[2]);
                    int hour = Convert.ToInt32(datas[3]);
                    int minute = Convert.ToInt32(datas[4]);
                    int second = Convert.ToInt32(datas[5]);
                    return new DateTime(year, month, day, hour, minute, second);
                }
                catch { return DefaultDateTime; }
            }

            internal static string ValidateInputData(string data)
            {
                string result = data.Replace(FragmentOpening, "");
                return result.Replace(FragmentClosing, "");
            }

            internal static string GetValue(string blob, string key)
            {
                if (!blob.Contains(FragmentOpening + key + FragmentClosing)) return "";
                string startData = blob.Substring(blob.IndexOf(FragmentOpening + key + FragmentClosing) + FragmentOpening.Length + key.Length + FragmentClosing.Length);
                if (!startData.Contains(FragmentOpening)) return startData;
                else return startData.Substring(0, startData.IndexOf(FragmentOpening));
            }

            internal static string SetValue(string blob, string key, string value)
            {
                value = ValidateInputData(value);
                if (!blob.Contains(FragmentOpening + key + FragmentClosing)) blob += FragmentOpening + key + FragmentClosing + value;
                else
                {
                    string leftData = blob.Substring(0, blob.IndexOf(FragmentOpening + key + FragmentClosing));
                    string startData = blob.Substring(blob.IndexOf(FragmentOpening + key + FragmentClosing) + FragmentOpening.Length + key.Length + FragmentClosing.Length);
                    if (!startData.Contains(FragmentOpening))
                    {
                        blob = leftData + FragmentOpening + key + FragmentClosing + value;
                    }
                    else
                    {
                        blob = leftData + startData.Substring(startData.IndexOf(FragmentOpening)) + FragmentOpening + key + FragmentClosing + value;
                    }
                }
                return blob;
            }

            internal static string GenerateUID(int length = DefaultGuidLength)
            {
                string id = "";
                Random random = new Random();
                for (int i = 0; i < length; i++)
                {
                    id += UIDCharset[random.Next(UIDCharset.Length)];
                }
                return id;
            }

            #endregion

            #region Geometry

            internal static bool IsInside(Point interest, params Point[] polygon)
            {
                bool isInside = false;
                for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
                {
                    if (((polygon[i].Y > interest.Y) != (polygon[j].Y > interest.Y)) &&
                    (interest.X < (polygon[j].X - polygon[i].X) * (interest.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                    {
                        isInside = !isInside;
                    }
                }
                return isInside;
            }

            #endregion
        }
    }
}
