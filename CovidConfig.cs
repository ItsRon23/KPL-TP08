using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class CovidConfig
{       
    public String satuan_suhu { get; set; }
    public int batas_hari_demam { get; set; }
    public String pesan_ditolak { get; set; }
    public String pesan_diterima { get; set; }

    public CovidConfig() { }

}   

public class AppConfig
{
    public CovidConfig config;

    // private const string filePath = ""C:\Users\Aaron\Downloads\jsonfile\covid_config.json"
    private const string filePath = "../../../covid_config.json";

    public AppConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch
        {
            SetDefault();
            WriteConfigFile();
        }
    }
    public void ReadConfigFile()
    {
        String configJsonData = File.ReadAllText(filePath);
        config = JsonSerializer.Deserialize<CovidConfig>(configJsonData);
    }

    public void WriteConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        String tulisan = JsonSerializer.Serialize(config);
        File.WriteAllText(filePath, tulisan);
    }

    public void SetDefault()
    {
        config = new CovidConfig();

        config.satuan_suhu = "celcius";
        config.batas_hari_demam = 14;
        config.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        config.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
    }

    public void UbahSatuan()
    {
        if (this.config.satuan_suhu == "celcius")
        {
            this.config.satuan_suhu = "fahrenheit";
        }
        else
        {
            this.config.satuan_suhu = "celcius";
        }

        String tulisan = JsonSerializer.Serialize(config);
        File.WriteAllText(filePath, tulisan);
    }
}
