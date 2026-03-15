using ExcelDataReader;
using Npgsql;
using Microsoft.Extensions.Configuration;

async Task MigrateKeluargaData(NpgsqlConnection conn, string folderPath, string tableName, string copyCommand)
{
    string[] excelFiles = Directory.GetFiles(folderPath, "*.xlsx");

    Console.WriteLine($"Memulai migrasi data dari folder {folderPath} ke table {tableName}...");

    foreach (var file in excelFiles)
    {
        Console.WriteLine($"Memproses: {Path.GetFileName(file)}");

        using var stream = File.Open(file, FileMode.Open, FileAccess.Read);
        using var reader = ExcelReaderFactory.CreateReader(stream);

        using (var writer = conn.BeginBinaryImport(copyCommand))
        {
            // Lewati header Excel
            reader.Read();

            while (reader.Read())
            {
                await writer.StartRowAsync();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    await writer.WriteAsync(reader.GetValue(i)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text);
                }

                // Tambahkan nama file sumber
                await writer.WriteAsync(Path.GetFileName(file), NpgsqlTypes.NpgsqlDbType.Text);
            }

            await writer.CompleteAsync();
        }
    }

    Console.WriteLine($"Selesai memproses data dari folder {folderPath} ke table {tableName}.");
}

async Task MigrateIndividuData(NpgsqlConnection conn, string folderPath, string tableName, string copyCommand)
{
    string[] excelFiles = Directory.GetFiles(folderPath, "*.xlsx");

    Console.WriteLine($"Memulai migrasi data dari folder {folderPath} ke table {tableName}...");

    foreach (var file in excelFiles)
    {
        Console.WriteLine($"Memproses: {Path.GetFileName(file)}");

        using var stream = File.Open(file, FileMode.Open, FileAccess.Read);
        using var reader = ExcelReaderFactory.CreateReader(stream);

        using (var writer = conn.BeginBinaryImport(copyCommand))
        {
            // Lewati header Excel
            reader.Read();

            while (reader.Read())
            {
                await writer.StartRowAsync();
                // Ambil data dan handle null secara aman
                await writer.WriteAsync(reader.GetValue(0)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // nomor_induk_kependudukan
                await writer.WriteAsync(reader.GetValue(1)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // nomor_kartu_keluarga
                await writer.WriteAsync(reader.GetValue(2)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // nama
                await writer.WriteAsync(reader.GetValue(3)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // tanggal_lahir
                await writer.WriteAsync(reader.GetValue(4)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // umur
                await writer.WriteAsync(reader.GetValue(5)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // jenis_kelamin
                await writer.WriteAsync(reader.GetValue(6)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // status_hubungan_keluarga
                await writer.WriteAsync(reader.GetValue(7)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // pbi_nas
                await writer.WriteAsync(reader.GetValue(8)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // pbi_pemda
                await writer.WriteAsync(reader.GetValue(9)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // id_pelanggan_pln
                await writer.WriteAsync(reader.GetValue(10)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // status_kawin
                await writer.WriteAsync(reader.GetValue(11)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // partisipasi_sekolah
                await writer.WriteAsync(reader.GetValue(12)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // jenjang_tertinggi_yang_diduduki
                await writer.WriteAsync(reader.GetValue(13)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // kelas_tertinggi_yang_diduduki
                await writer.WriteAsync(reader.GetValue(14)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // ijazah_tertinggi_yang_dimiliki
                await writer.WriteAsync(reader.GetValue(15)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // status_bekerja
                await writer.WriteAsync(reader.GetValue(16)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // lapangan_usaha_dari_pekerjaan_utama
                await writer.WriteAsync(reader.GetValue(17)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // status_dalam_pekerjaan_utama
                await writer.WriteAsync(reader.GetValue(18)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // kepemilikan_usaha
                await writer.WriteAsync(reader.GetValue(19)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // jumlah_usaha
                await writer.WriteAsync(reader.GetValue(20)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // lapangan_usaha_dari_usaha_utama
                await writer.WriteAsync(reader.GetValue(21)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // jumlah_pekerja_yang_dibayar_dari_usaha_utama
                await writer.WriteAsync(reader.GetValue(22)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // jumlah_pekerja_yang_tidak_dibayar_dari_usaha_utama
                await writer.WriteAsync(reader.GetValue(23)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // omzet_usaha_utama
                await writer.WriteAsync(reader.GetValue(24)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // kondisi_gizi
                await writer.WriteAsync(reader.GetValue(25)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // penglihatan
                await writer.WriteAsync(reader.GetValue(26)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // pendengaran
                await writer.WriteAsync(reader.GetValue(27)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // berjalan_atau_naik_tangga
                await writer.WriteAsync(reader.GetValue(28)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // menggunakan_tangan_jari
                await writer.WriteAsync(reader.GetValue(29)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // belajar_kemampuan_intelektual
                await writer.WriteAsync(reader.GetValue(30)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // pengendalian_perilaku
                await writer.WriteAsync(reader.GetValue(31)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // berbicara_komunikasi
                await writer.WriteAsync(reader.GetValue(32)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // mengurus_diri
                await writer.WriteAsync(reader.GetValue(33)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // mengingat_berkonsentrasi
                await writer.WriteAsync(reader.GetValue(34)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // kesedihan_depresi
                await writer.WriteAsync(reader.GetValue(35)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // penyakit_kronis
                await writer.WriteAsync(reader.GetValue(36)?.ToString() ?? "", NpgsqlTypes.NpgsqlDbType.Text); // kode_kelurahan_desa_ktp
                await writer.WriteAsync(Path.GetFileName(file), NpgsqlTypes.NpgsqlDbType.Text); // nama_file_sumber
            }

            await writer.CompleteAsync();
        }
    }

    Console.WriteLine($"Selesai memproses data dari folder {folderPath} ke table {tableName}.");
}

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

var connectionString = config.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("Connection string is not configured in appsettings.json.");

var individuFolderPath = config["DataSettings:IndividuFolderPath"];
if (string.IsNullOrWhiteSpace(individuFolderPath))
    throw new InvalidOperationException("IndividuFolderPath is not configured or is empty in appsettings.json.");

var keluargaFolderPath = config["DataSettings:KeluargaFolderPath"];
if (string.IsNullOrWhiteSpace(keluargaFolderPath))
    throw new InvalidOperationException("KeluargaFolderPath is not configured or is empty in appsettings.json.");

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
using var conn = new NpgsqlConnection(connectionString);
await conn.OpenAsync();


Console.WriteLine("Memulai migrasi ke Temporary Table data Individu...");
var individuCopyCommand = "COPY staging_individu (nomor_induk_kependudukan, nomor_kartu_keluarga, nama, tanggal_lahir, umur, jenis_kelamin, status_hubungan_keluarga, pbi_nas, pbi_pemda, id_pelanggan_pln, status_kawin, partisipasi_sekolah, jenjang_tertinggi_yang_diduduki, kelas_tertinggi_yang_diduduki, ijazah_tertinggi_yang_dimiliki, status_bekerja, lapangan_usaha_dari_pekerjaan_utama, status_dalam_pekerjaan_utama, kepemilikan_usaha, jumlah_usaha, lapangan_usaha_dari_usaha_utama, jumlah_pekerja_yang_dibayar_dari_usaha_utama, jumlah_pekerja_yang_tidak_dibayar_dari_usaha_utama, omzet_usaha_utama, kondisi_gizi, penglihatan, pendengaran, berjalan_atau_naik_tangga, menggunakan_tangan_jari, belajar_kemampuan_intelektual, pengendalian_perilaku, berbicara_komunikasi, mengurus_diri, mengingat_berkonsentrasi, kesedihan_depresi, penyakit_kronis, kode_kelurahan_desa_ktp, nama_file_sumber) FROM STDIN (FORMAT BINARY)";
await MigrateIndividuData(conn, individuFolderPath, "staging_individu", individuCopyCommand);

Console.WriteLine("Memulai migrasi ke Temporary Table data Keluarag...");
var keluargaCopyCommand = "COPY staging_keluarga (kode_provinsi, provinsi, kode_kabupaten_kota, kabupaten_kota, kode_kecamatan, kecamatan, kode_kelurahan_desa, kelurahan_desa, alamat, nomor_kartu_keluarga, jumlah_anggota_keluarga, nama_anggota_keluarga, desil_nasional, pbi_nas, pbi_pemda, id_pelanggan_pln, status_kepemilikan_rumah, jenis_lantai_terluas, luas_lantai, jenis_dinding_terluas, jenis_atap_terluas, sumber_air_minum_utama, sumber_penerangan_utama, daya_terpasang, bahan_bakar_utama_memasak, fasilitas_bab, jenis_kloset, pembuangan_akhir_tinja, kepemilikan_aset, aset_bergerak_tabung_gas, aset_bergerak_lemari_es, aset_bergerak_ac, aset_bergerak_pemanas_air, aset_bergerak_telepon_rumah, aset_bergerak_tv_datar, aset_bergerak_emas_perhiasan, aset_bergerak_komputer_laptop_tablet, aset_bergerak_sepeda_motor, aset_bergerak_sepeda, aset_bergerak_mobil, aset_bergerak_perahu, aset_bergerak_kapal_perahu_motor, aset_bergerak_smartphone, aset_tidak_bergerak_lahan_lainnya, aset_tidak_bergerak_rumah_lainnya, jumlah_ternak_sapi, jumlah_ternak_kerbau, jumlah_ternak_kuda, jumlah_ternak_babi, jumlah_ternak_kambing_domba, nama_file_sumber) FROM STDIN (FORMAT BINARY)";
await MigrateKeluargaData(conn, keluargaFolderPath, "staging_keluarga", keluargaCopyCommand);