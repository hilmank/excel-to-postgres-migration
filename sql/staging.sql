-- 1. Tabel Staging untuk Data Individu
CREATE UNLOGGED TABLE staging_individu (
    id SERIAL PRIMARY KEY,
    nomor_induk_kependudukan TEXT,
    nomor_kartu_keluarga TEXT,
    nama TEXT,
    tanggal_lahir TEXT,
    umur TEXT,
    jenis_kelamin TEXT,
    status_hubungan_keluarga TEXT,
    pbi_nas TEXT,
    pbi_pemda TEXT,
    id_pelanggan_pln TEXT,
    status_kawin TEXT,
    partisipasi_sekolah TEXT,
    jenjang_tertinggi_yang_diduduki TEXT,
    kelas_tertinggi_yang_diduduki TEXT,
    ijazah_tertinggi_yang_dimiliki TEXT,
    status_bekerja TEXT,
    lapangan_usaha_dari_pekerjaan_utama TEXT,
    status_dalam_pekerjaan_utama TEXT,
    kepemilikan_usaha TEXT,
    jumlah_usaha TEXT,
    lapangan_usaha_dari_usaha_utama TEXT,
    jumlah_pekerja_yang_dibayar_dari_usaha_utama TEXT,
    jumlah_pekerja_yang_tidak_dibayar_dari_usaha_utama TEXT,
    omzet_usaha_utama TEXT,
    kondisi_gizi TEXT,
    penglihatan TEXT,
    pendengaran TEXT,
    berjalan_atau_naik_tangga TEXT,
    menggunakan_tangan_jari TEXT,
    belajar_kemampuan_intelektual TEXT,
    pengendalian_perilaku TEXT,
    berbicara_komunikasi TEXT,
    mengurus_diri TEXT,
    mengingat_berkonsentrasi TEXT,
    kesedihan_depresi TEXT,
    penyakit_kronis TEXT,
    kode_kelurahan_desa_ktp TEXT,
    nama_file_sumber TEXT, -- Tambahan untuk tracking file asal
    waktu_import TIMESTAMP DEFAULT NOW()
);

-- 2. Tabel Staging untuk Data Keluarga
CREATE UNLOGGED TABLE staging_keluarga (
    id SERIAL PRIMARY KEY,
    kode_provinsi TEXT,
    provinsi TEXT,
    kode_kabupaten_kota TEXT,
    kabupaten_kota TEXT,
    kode_kecamatan TEXT,
    kecamatan TEXT,
    kode_kelurahan_desa TEXT,
    kelurahan_desa TEXT,
    alamat TEXT,
    nomor_kartu_keluarga TEXT,
    jumlah_anggota_keluarga TEXT,
    nama_anggota_keluarga TEXT,
    desil_nasional TEXT,
    pbi_nas TEXT,
    pbi_pemda TEXT,
    id_pelanggan_pln TEXT,
    status_kepemilikan_rumah TEXT,
    jenis_lantai_terluas TEXT,
    luas_lantai TEXT,
    jenis_dinding_terluas TEXT,
    jenis_atap_terluas TEXT,
    sumber_air_minum_utama TEXT,
    sumber_penerangan_utama TEXT,
    daya_terpasang TEXT,
    bahan_bakar_utama_memasak TEXT,
    fasilitas_bab TEXT,
    jenis_kloset TEXT,
    pembuangan_akhir_tinja TEXT,
    kepemilikan_aset TEXT,
    aset_bergerak_tabung_gas TEXT,
    aset_bergerak_lemari_es TEXT,
    aset_bergerak_ac TEXT,
    aset_bergerak_pemanas_air TEXT,
    aset_bergerak_telepon_rumah TEXT,
    aset_bergerak_tv_datar TEXT,
    aset_bergerak_emas_perhiasan TEXT,
    aset_bergerak_komputer_laptop_tablet TEXT,
    aset_bergerak_sepeda_motor TEXT,
    aset_bergerak_sepeda TEXT,
    aset_bergerak_mobil TEXT,
    aset_bergerak_perahu TEXT,
    aset_bergerak_kapal_perahu_motor TEXT,
    aset_bergerak_smartphone TEXT,
    aset_tidak_bergerak_lahan_lainnya TEXT,
    aset_tidak_bergerak_rumah_lainnya TEXT,
    jumlah_ternak_sapi TEXT,
    jumlah_ternak_kerbau TEXT,
    jumlah_ternak_kuda TEXT,
    jumlah_ternak_babi TEXT,
    jumlah_ternak_kambing_domba TEXT,
    nama_file_sumber TEXT,
    waktu_import TIMESTAMP DEFAULT NOW()
);

/* Catatan:
Mengapa menggunakan UNLOGGED?
Pada PostgreSQL, tabel UNLOGGED tidak menulis data ke Write-Ahead Log (WAL). 
Keuntungannya:
- Proses Tulis Sangat Cepat: Cocok untuk data migrasi yang bersifat sementara.
- Hemat Disk I/O: Mengurangi beban sistem saat memasukkan 1 juta record sekaligus.
- Catatan: Jika database mati mendadak (crash), data di tabel ini bisa hilang. Namun, untuk proses staging, ini bukan masalah karena Anda tinggal menjalankan ulang migrasinya.
*/

INSERT INTO qst.refkuisioner
(kode, nama) values 
('keluarga-26', 'Sensus Keluarga');

INSERT INTO qst.kuisioner
(id, kode, tahun, namapendek, nama, deskripsi, ketkodedata, status, tanggalmulai, tanggalselesai, iconfile, bgcolor, imagefile)
select 'keluarga-2026', 'keluarga-26', tahun, 'Pendataan Keluarga 2026', 'Pendataan Keluarga 2026', 'Pendataan Keluarga 2026', ketkodedata, status, tanggalmulai, tanggalselesai, iconfile, bgcolor, imagefile
from qst.kuisioner where id = 'keluarga_2026';

