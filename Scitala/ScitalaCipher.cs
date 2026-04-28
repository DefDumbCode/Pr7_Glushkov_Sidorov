using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scitala
{
    public static class ScitalaCipher
    {
        /// <summary>
        /// Шифрует оригинальный текст шифром сциталы с заданным диаметром
        /// </summary>
        /// <param name="text">Исходный текст для шифроки</param>
        /// <param name="diam">Диаметр сциталы. (В коде - количество символов на одном витке смежной матрицы)</param>
        /// <returns>Возвращает строку с шифром</returns>
        public static string Encrypt(string text, int diam)
        {
            string cipher = "";
            int cols = (text.Length + diam - 1) / diam;
            for (int i = 0; i < cols; i++) 
            {
                for (int j = 0; j < diam; j++)
                {
                    int index = j * cols + i;
                    if (index < text.Length)
                    {
                        cipher += text[index];
                    }
                    else
                    {
                        cipher += " ";
                    }
                }
            }
            return cipher;
        }

        /// <summary>
        /// Дешифрует зашифрованный текст шифром сциталы с заданным диаметром
        /// </summary>
        /// <param name="text">Текст для дешифровки</param>
        /// <param name="diam">Диаметр сциталы. (В коде - количество символов на одном витке смежной матрицы)</param>
        /// <returns>Возвращает строку с дешифрованным сообщением</returns>
        public static string Decrypt(string text, int diam)
        {
            string cipher = "";
            int cols = (text.Length + diam - 1) / diam;
            for (int i = 0; i < diam; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int index = j * diam + i;
                    if (index < text.Length)
                    {
                        cipher += text[index];
                    }
                    else
                    {
                        cipher += " ";
                    }
                }
            }
            return cipher;
        }

        /// <summary>
        /// Определяет валидность введенных параметров
        /// </summary>
        /// <param name="text">Текст для шифровки/дешифровки*</param>
        /// <param name="diam">Диаметр сциталы. (В коде - количество символов на одном витке смежной матрицы)</param>
        /// <returns>Булево значение валидности параметров</returns>
        public static bool Validate(string text, string diam)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(diam))
            {
                MessageBox.Show("Ошибка, не все данные заполнены");
                return false;
            }

            int diam_;
            if(!int.TryParse(diam, out diam_))
            {
                MessageBox.Show("Некорректно введено значение диаметра");
                return false;
            }

            if (diam_ <= 0)
            {
                MessageBox.Show("Некорректно введено значение диаметра");
                return false;
            }

            if (diam_ > text.Length)
            {
                MessageBox.Show("Соотношение текста и диаметра не позволяют выполнить операцию");
                return false;
            }
            return true;
        }
    }
}
