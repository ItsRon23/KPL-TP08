namespace tpmodul8_1302220005
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AppConfig cfg = new AppConfig();

            cfg.UbahSatuan();

            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {cfg.config.satuan_suhu} : ");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.Write($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? : ");
            int lama_demam = int.Parse(Console.ReadLine());


            if (
                ((cfg.config.satuan_suhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
                (cfg.config.satuan_suhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5)) &&
                lama_demam < cfg.config.batas_hari_demam
            )
            {
                Console.WriteLine(cfg.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(cfg.config.pesan_ditolak);
            }
        }
    }
}
