using System;

class Program
{
    static void Main(string[] args)
    {
        // Kullanıcıdan gün sayısını girmesini istiyoruz
        Console.WriteLine("Gün sayısını girin:");
        int days = int.Parse(Console.ReadLine());

        // Girilen gün sayısı kadar sıcaklık değerlerini tutacak bir dizi oluşturuyoruz
        int[] temp = new int[days];

        // Hava durumu koşullarını içeren bir dizi oluşturuyoruz
        string[] con = { "güneşli", "bulutlu", "karli", "yagmurlu" };

        // Girilen gün sayısı kadar hava durumu koşullarını tutacak bir dizi oluşturuyoruz
        int[] con2 = new int[days];

        // Rastgele sayı üretmek için Random sınıfından bir nesne oluşturuyoruz
        Random random = new Random();

        // Her gün için rastgele sıcaklık ve hava durumu koşulunu atıyoruz
        for (int i = 0; i < days; i++)
        {
            temp[i] = random.Next(-10, 40); // -10 ile 40 arasında rastgele sıcaklık değeri

            // Hava durumu koşulunu belirlerken sıcaklık durumunu göz önüne alıyoruz
            if (temp[i]<0)
            {
                // Sıcaklık 0'dan düşükse yağmurlu olamaz
                con2[i] = random.Next(4); // "karli" dahil olabilir, "yagmurlu" hariç
                while (con2[i]==3)
                {
                    con2[i] = random.Next(4);
                }
            }
            else if (temp[i] > 0)
            {
                // Sıcaklık 0'dan yüksekse karli olamaz
                con2[i] = random.Next(4); // 0, 1, 2, 3 arasında rastgele seç
                while (con2[i] == 2) // Eğer "karli" seçilmişse
                {
                    con2[i] = random.Next(4); // Yeniden ata, "karli" hariç
                }
            }
            else
            {
                // Sıcaklık 0 ise herhangi bir hava durumu olabilir
                con2[i] = random.Next(4);
            }
        }

        // Ortalama sıcaklığı hesaplayıp ekrana yazdırıyoruz
        Console.WriteLine("Ortalama sıcaklık: " + CalculateAverage(temp) + "°C");

        // Hava d urumlarını gösteriyoruz
        Goster(con, con2, temp);

        // Konsolu açık tutmak için bir tuşa basmayı bekliyoruz
        Console.ReadLine();
    }

    // Ortalama sıcaklık hesaplama metodu
    static double CalculateAverage(int[] temp)
    {
        int sum = 0;

        // Dizideki tüm sıcaklık değerlerini topluyoruz
        for (int i = 0; i < temp.Length; i++)
        {
            sum += temp[i];
        }

        // Ortalama sıcaklığı hesaplıyoruz
        double average = (double)sum / temp.Length;

        return average;
    }

    // Hava durumlarını gösterme metodu
    static void Goster(string[] con, int[] con2, int[] temp)
    {
        for (int i = 0; i < con2.Length; i++)
        {
            Console.WriteLine($"{i + 1}. gün hava durumu: {con[con2[i]]}, sıcaklık: {temp[i]}°C");
        }
    }
}
