using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace tpmodul8_103082430003
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public static CovidConfig LoadConfigFile()
        {
            string filename = "covid_config.json";
            try
            {
                string jsonString = File.ReadAllText(filename);

                return JsonSerializer.Deserialize<CovidConfig>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal memuat konfigurasi: {ex.Message}");
                return new CovidConfig
                {
                    satuan_suhu = "Celcius",
                    batas_hari_demam = 14,
                    pesan_ditolak = "Akses ditolak.",
                    pesan_diterima = "Akses diterima"
                };
            }
        }

    public void UbahSatuan()
        {
            if (this.satuan_suhu.ToLower() == "celcius")
            {
                this.satuan_suhu = "fahrenheit";
            }
            else if (this.satuan_suhu.ToLower() == "fahrenheit")
            {
                this.satuan_suhu = "celcius";
            }
        }
    } 
}
