using System;

namespace StackArray
{
    //StackArray sınıfı
    class StackArray
    {
        private int[] stack; //Verilerin tutulacağı değişken. Bir int array olarak tanımladık.
        private int maxSize; //Stack'in maksimum boyutu.
        private int top; //Stack'in index değerini gösterecek olan değişken.


        public StackArray(int size)
        {
            maxSize = size; //size değeri Stack oluşturulurken bizim tarafımızdan belirlenir. size değerini maxSize'a aktarıyoruz.
            stack = new int[maxSize]; //Stack array boyutu belirlediğimiz değer kadar.
            top = -1; //top değeri başlangıçta -1 dir. Bu dizinin boş olduğunu gösterir.
        }

        /* Stack'e veri ekleme Push metodu.
           data değişkeni Stack'e eklediğimiz verileri temsil eder.
        */
        public void Push(int data)
        {
            if ( top == maxSize - 1 ) //Stack'in tamamen dolu olup olmadığını kontrol et.
            {
                Console.WriteLine("StackOverflow"); //Eğer Stack doluysa bu hatayı ekrana yazdır.
                return;
            }
            stack[++top] = data; //Stack dolu değilse veriyi Stack'e ekle.
        }

        //Stack'den veri silme Pop metodu.
        public int Pop()
        {
            if ( top == -1 ) //Stack boş ise
            {
                Console.WriteLine("Stack boş. Silinecek veri bulunamadı."); //Ekrana bu hatayı yazdır.
                return -1;
            }
            return stack[top--]; // veriyi sil
        }

        //Stack'deki verileri ekrana yazdırma
        public void Print()
        {
            if ( top == -1 ) //Stack boş ise
            {
                Console.WriteLine("Stack boş. Yazdırılacak veri bulunamadı.");  //Ekrana bu hatayı yazdır.
            }
            else
            {
                for (int i = top; i > -1; i--) // Stack boş değilse en üstten başlayarak verileri ekrana yazdırır.
                {
                    Console.WriteLine(stack[i]);
                }   
            }
        }
    } 

    class Program
    {
        static void Main()
        {
            StackArray stackArray = new StackArray(5); //5 Elemanlı bir Array tanımladık.
            stackArray.Push(5); //5 elemanını Stack'e ekledik.
            stackArray.Push(10);
            stackArray.Push(15);
            stackArray.Push(20);
            stackArray.Push(25);
            stackArray.Print(); //Tüm elemanları ekrana yazdırdık.
            Console.WriteLine("--------------");
            stackArray.Pop(); //25 elemanını Stack'den sildik. LIFO kuralına göre en son eklenen eleman ilk önce Stack'den çıkacaktır.
            stackArray.Print();
            Console.WriteLine("--------------");
            stackArray.Push(100);
            stackArray.Push(150); //Stack'den sadece 1 eleman silmiştik şimdi yerine 2 eleman ekledik ve Stack maksimum boyutu aştığı için "StackOverflow" hatası verecektir.
            Console.ReadKey();
        }
    } 
}