using System;
using System.Collections.Generic;

namespace SistemPerpustakaan
{
    // 1. Kelas Induk (Parent Class) - Item
    public class Item
    {
        public string Judul { get; set; }
        public int Tahun { get; set; }

        public Item(string judul, int tahun)
        {
            Judul = judul;
            Tahun = tahun;
        }

        public virtual void Deskripsi()
        {
            Console.WriteLine($"[Item] Judul: {Judul}, Tahun: {Tahun}");
        }

        public void InfoItem()
        {
            Console.WriteLine($"Informasi Item Umum -> Judul: {Judul} (Dirilis tahun {Tahun})");
        }
    }

    // 2. Kelas Buku (Turunan Item)
    public class Buku : Item
    {
        public string Penulis { get; set; }

        public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
        {
            Penulis = penulis;
        }

        public void CekPenulis()
        {
            Console.WriteLine($"Penulis dari buku '{Judul}' adalah {Penulis}.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"[Buku] Judul: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
        }
    }

    // 3. Kelas Majalah (Turunan Item)
    public class Majalah : Item
    {
        public int Edisi { get; set; }

        public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
        {
            Edisi = edisi;
        }

        public void InfoEdisi()
        {
            Console.WriteLine($"Majalah '{Judul}' merupakan edisi ke-{Edisi} tahun {Tahun}.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"[Majalah] Judul: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
        }
    }

    // 4. Kelas Turunan dari Buku: Novel & Komik
    public class Novel : Buku
    {
        public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public void BacaSinopsis()
        {
            Console.WriteLine($"Membaca sinopsis dari novel '{Judul}' karya {Penulis}. Ceritanya sangat menarik!");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"[Novel] Judul: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
        }
    }

    public class Komik : Buku
    {
        public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public void TampilkanIlustrasi()
        {
            Console.WriteLine($"Menampilkan ilustrasi bergambar penuh warna dari komik '{Judul}'.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"[Komik] Judul: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
        }
    }

    // 5. Kelas Turunan dari Majalah: MajalahAnak & MajalahTeknologi
    public class MajalahAnak : Majalah
    {
        public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public void KategoriAnak()
        {
            Console.WriteLine($"Majalah '{Judul}' berisi rubrik permainan edukatif dan cerita bergambar untuk anak-anak.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"[Majalah Anak] Judul: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
        }
    }

    public class MajalahTeknologi : Majalah
    {
        public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public void TopikTeknologi()
        {
            Console.WriteLine($"Majalah '{Judul}' membahas topik terkini seputar Artificial Intelligence dan Software Engineering.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"[Majalah Teknologi] Judul: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
        }
    }

    // 6. Kelas Perpustakaan (Menampung Koleksi Item)
    public class Perpustakaan
    {
        private List<Item> daftarItem = new List<Item>();

        public void TambahItem(Item item)
        {
            daftarItem.Add(item);
            Console.WriteLine($"Berhasil menambahkan '{item.Judul}' ke perpustakaan.");
        }

        public void DaftarItem()
        {
            Console.WriteLine("\n--- DAFTAR KOLEKSI PERPUSTAKAAN ---");
            foreach (var item in daftarItem)
            {
                item.Deskripsi(); // Demonstrasi Polimorfisme
            }
            Console.WriteLine("------------------------------------\n");
        }
    }

    // 7. Program Utama (Main Method)
    class Program
    {
        static void Main(string[] args)
        {
            // a. Buat objek perpustakaan
            Perpustakaan perpus = new Perpustakaan();

            // b. Buat beberapa objek item (subclass)
            Novel novel1 = new Novel("Laskar Pelangi", 2005, "Andrea Hirata");
            Komik komik1 = new Komik("Naruto Vol. 1", 2000, "Masashi Kishimoto");
            MajalahTeknologi majalahTekno = new MajalahTeknologi("PC Media", 2024, 45);
            MajalahAnak majalahAnak = new MajalahAnak("Bobo", 2023, 12);

            // c. Tambahkan ke perpustakaan
            perpus.TambahItem(novel1);
            perpus.TambahItem(komik1);
            perpus.TambahItem(majalahTekno);
            perpus.TambahItem(majalahAnak);

            // d. Tampilkan semua data
            perpus.DaftarItem();

            // e. Demonstrasikan polimorfisme secara langsung
            Console.WriteLine("--- DEMONSTRASI POLIMORFISME ---");
            Item itemPolimorf1 = new Novel("Bumi Manusia", 1980, "Pramoedya Ananta Toer");
            Item itemPolimorf2 = new MajalahTeknologi("Infokom", 2025, 3);

            itemPolimorf1.Deskripsi(); // Memanggil Deskripsi versi Novel
            itemPolimorf2.Deskripsi(); // Memanggil Deskripsi versi MajalahTeknologi
            Console.WriteLine();

            // f. Panggil method khusus masing-masing objek
            Console.WriteLine("--- PEMANGGILAN METHOD KHUSUS ---");
            novel1.BacaSinopsis();
            komik1.TampilkanIlustrasi();
            majalahTekno.TopikTeknologi();
            majalahAnak.KategoriAnak();
            novel1.CekPenulis(); // Method dari kelas Buku
            majalahTekno.InfoEdisi(); // Method dari kelas Majalah

            Console.WriteLine("\nProgram Selesai. Tekan sembarang tombol untuk keluar.");
            Console.ReadKey();
        }
    }
}