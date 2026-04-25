using System;
using System.Runtime.CompilerServices;

namespace tpmodul8_103082430003
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig config = CovidConfig.LoadConfigFile();

            config.UbahSatuan();

            Console.WriteLine("=== Aplikasi Pengecekan Status Covid ===");
            //Input 1
            Console.Write($"Berapa suhu badan anda saat ini? dalam nilai {config.satuan_suhu} :");
            double suhuInputan = Convert.ToDouble(Console.ReadLine());
            //Input 2
            Console.Write($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
            int inputHari = Convert.ToInt32(Console.ReadLine());

            bool KondisiSuhu = false;
            if (config.satuan_suhu.ToLower()=="celcius")
            {
                //Range 36.5-37.5
                if (suhuInputan >= 36.5 && suhuInputan <= 37.5) KondisiSuhu = true;

            }
            else if (config.satuan_suhu.ToLower()=="fahrenheit")
            {
                //Range 97.7-99.5
                if (suhuInputan >= 97.7 && suhuInputan <= 99.5) KondisiSuhu = true;
            }

            if (KondisiSuhu && inputHari < config.batas_hari_demam)
            {
                Console.WriteLine($"{config.pesan_diterima}");
            }
            else
            {
                Console.WriteLine($"{config.pesan_ditolak}");
            }

            Console.WriteLine("=== Selesai ===");
            Console.ReadKey();
        }
    }
}
