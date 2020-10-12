using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA2_new
{
    public partial class MaTran : UserControl
    {
        public MaTran()
        {
            InitializeComponent();
            cacDinhDaXoa.Clear();
        }
        TextBox[] phanTu;

        public TextBox[] PhanTu
        {
            get { return phanTu; }
            set { phanTu = value; }
        }
        int soDong = 1, soCot = 1;

        public int SoCot
        {
            get { return soCot; }
            set { soCot = value; }
        }

        public int SoDong
        {
            get { return soDong; }
            set { soDong = value; }
        }
        int[,] a;

        public int[,] A
        {
            get { return a; }
            set { a = value; }
        }
        bool coHuong = false;

        public bool CoHuong
        {
            get { return coHuong; }
            set { coHuong = value; }
        }

        public bool isDoiXung()
        {
            // vi dong==cot;
            // kiem tra ma tran a co doi xung qua cheo chinh khong
            for (int i = 0; i < SoDong; i++)
                for (int j = 0; j < SoCot; j++)
                    if (A[i, j] != A[j, i])
                        return false;
            return true;
        }
        public bool CoTrongSo()
        {
            for (int i = 0; i < SoDong; i++)
                for (int j = 0; j < SoCot; j++)
                    if (A[i, j] > 1)
                        return true;
            return false;
        }
        public void DocMatTranTuFile(string name)
        {
            cacDinhDaXoa.Clear();
            // file Name co cau truc sau:
            /*
             SoDong SoCot 40 50
             0 0 0 0
             0 0 0 0
             0 0 0 0, 
            */
            FileStream fs = new FileStream(name, FileMode.Open);
            StreamReader doc = new StreamReader(fs);
            string s;
            s = doc.ReadLine();// doc dong dau tien
            s = s.Trim();
            List<int> kq = StringToInt(s);
            SoDong = kq[0];
            SoCot = kq[1];
            A = new int[SoDong, SoCot];
            for (int i = 0; i < SoDong; i++)
            {
                s = doc.ReadLine();
                s = s.Trim();
                List<int> kq1 = StringToInt(s);
                for (int j = 0; j < kq1.Count; j++)
                    A[i, j] = kq1[j];
            }
            doc.Close();
            if (isDoiXung() == true)
                coHuong = false;
            else
                coHuong = true;
            ChuaXet.Clear();
            for (int i = 0; i < SoCot; i++)
            {
                bool tmp = true;
                ChuaXet.Add(tmp);
            }
        }
        List<int> StringToInt(string s)
        {
            List<int> kq = new List<int>();
            s = s.Trim();
            Char[] CharSet = new Char[1];
            CharSet[0] = ' ';
            string[] tam = s.Split(CharSet);// 12 34  45  6 ==> 12 34 '   ' 45 6 la chuoi
            for (int i = 0; i < tam.Length; i++)
                if (tam[i].Trim().Length != 0)
                {
                    kq.Add(int.Parse(tam[i].Trim()));// 12 34 45 6 la so nguyen
                }
            return kq;
        }
        public void GhiMaTranVaoFile(string name)
        {
            FileStream fs = new FileStream(name, FileMode.OpenOrCreate);
            StreamWriter ghi = new StreamWriter(fs);
            ghi.WriteLine(SoDong.ToString() + " " + SoCot.ToString());
            for (int i = 0; i < SoDong; i++)
            {
                string s = "";
                for (int j = 0; j < SoCot; j++)
                {
                    s = s + A[i, j].ToString() + " "; //3 4 5 .

                }
                s = s.Trim();
                ghi.WriteLine(s);
            }
            ghi.Close();
        }
        public void TaoHead()
        {
            TextBox[] head;
            if (SoDong != 1)
                head = new TextBox[SoCot * SoDong];
            else
                head = new TextBox[2];
            int k = 0;
            for (int i = 1; i <= SoDong; i++)
            {
                head[k] = new TextBox();
                head[k].Size = new Size(20, 20);
                head[k].Location = new Point(0, i * head[k].Size.Height);// x=j*size.width
                head[k].Text = (i).ToString();
                head[k].Enabled = false;
                head[k].TextChanged += new EventHandler(ThayDoiGiaTriMaTran);
                this.Controls.Add(head[k]);
                k++;
            }
            for (int i = 1; i <= SoCot; i++)
            {
                head[k] = new TextBox();
                head[k].Enabled = false;
                head[k].Size = new Size(20, 20);
                head[k].Location = new Point(i * head[k].Size.Width, 0);// x=j*size.width
                head[k].Text = (i).ToString();
                head[k].TextChanged += new EventHandler(ThayDoiGiaTriMaTran);
                this.Controls.Add(head[k]);
                k++;
            }
        }
        public void ShowMaTran()
        {
            this.Controls.Clear();
            TaoHead();
            PhanTu = new TextBox[SoCot * SoDong];
            int k = 0;// the hien chi so phan tu cua text.
            for (int i = 0; i < SoDong; i++)
                for (int j = 0; j < SoCot; j++)
                {
                    PhanTu[k] = new TextBox();
                    PhanTu[k].Size = new Size(20, 20);
                    PhanTu[k].Location = new Point(j * PhanTu[k].Size.Width + 20, i * PhanTu[k].Size.Height + 20);// x=j*size.width
                    if (DaXoaDinh(i) || DaXoaDinh(j))
                    {
                        PhanTu[k].Text = null;
                        PhanTu[k].Enabled = false;
                    }
                    else
                        PhanTu[k].Text = A[i, j].ToString();
                    PhanTu[k].TextChanged += new EventHandler(ThayDoiGiaTriMaTran);
                    this.Controls.Add(PhanTu[k]);
                    k++;
                }
            this.Size = new Size(PhanTu[0].Width * (SoCot + 1), PhanTu[0].Height * (SoDong + 1));
        }

        private void ThayDoiGiaTriMaTran(object sender, EventArgs e)// trinh xu li sk khi gia tri ma tran thay doi;
        {
            int k = 0;
            for (int i = 0; i < SoDong; i++)
                for (int j = 0; j < SoCot; j++)
                {
                    int.TryParse(PhanTu[k].Text, out A[i, j]);
                    k++;
                }
            if (isDoiXung() == true)
                coHuong = false;
            else
                coHuong = true;
        }
        public void TaoMaTran(int soDong, int soCot)
        {
            this.SoDong = soDong;
            this.SoCot = soCot;
            A = new int[SoDong, SoCot];
            ChuaXet.Clear();
            for (int i = 0; i < SoCot; i++)
            {
                bool tmp = true;
                ChuaXet.Add(tmp);
            }
            CacDinhDaXoa.Clear();
        }
        public void ThemDinh(int id = -1, int ts = 1)
        {
            int[,] B = new int[SoDong, SoCot];
            for (int i = 0; i < SoDong; i++)
                for (int j = 0; j < SoCot; j++)
                    B[i, j] = A[i, j];
            SoDong++;
            SoCot++;
            A = new int[SoDong, SoCot];
            for (int i = 0; i < SoDong - 1; i++)
                for (int j = 0; j < SoCot - 1; j++)
                    A[i, j] = B[i, j];
            bool tmp = true;
            ChuaXet.Add(tmp);

            if (id != -1)
            {
                if (CoHuong == false)
                {
                    A[id, SoCot - 1] = ts;
                    A[SoCot - 1, id] = ts;
                }
                else
                    A[id, SoCot - 1] = ts;
            }

            if (isDoiXung() == true)
                coHuong = false;
            else
                coHuong = true;
        }
        public bool DaXoaDinh(int id)
        {
            for (int i = 0; i < CacDinhDaXoa.Count; i++)
                if (id == CacDinhDaXoa[i])
                    return true;
            return false;
        }
        public void XoaDinh(int id)
        {
            // duyet dong thu id.
            CacDinhDaXoa.Add(id);
            for (int i = 0; i < SoCot; i++)
            {
                A[id, i] = 0;
            }
            for (int i = 0; i < SoDong; i++)
            {
                A[i, id] = 0;
            }

            if (isDoiXung() == true)
                coHuong = false;
            else
                coHuong = true;
            ChuaXet[id] = false;
        }
        public void ThemCanh(int id1, int id2)
        {
            A[id1, id2] += 1;
            if (isDoiXung() == true)
                coHuong = false;
            else
                coHuong = true;
        }
        public void XoaCanh(int ci, int cj)
        {
            if (ci < SoDong && cj < SoCot)
                A[ci, cj] = 0;
            if (isDoiXung() == true)
                coHuong = false;
            else
                coHuong = true;
        }
        List<int> cacDinhDaXoa = new List<int>();

        public List<int> CacDinhDaXoa
        {
            get { return cacDinhDaXoa; }
            set { cacDinhDaXoa = value; }
        }

        List<int> _dfs = new List<int>();
        List<int> _bfs = new List<int>();

        public List<int> Bfs
        {
            get { return _bfs; }
            set { _bfs = value; }
        }
        public List<int> Dfs
        {
            get { return _dfs; }
            set { _dfs = value; }
        }

        Queue<int> hangDoi = new Queue<int>();

        public Queue<int> HangDoi
        {
            get { return hangDoi; }
            set { hangDoi = value; }
        }
        List<bool> chuaXet = new List<bool>();

        public List<bool> ChuaXet
        {
            get { return chuaXet; }
            set { chuaXet = value; }
        }

        public void DFS(int v)
        {
            Dfs.Add(v);
            ChuaXet[v] = false;
            for (int i = 0; i < SoCot; i++)
                if ((A[v, i] == 1) && (ChuaXet[i] == true))
                    DFS(i);
        }

        public void BFS(int v)
        {
            hangDoi.Enqueue(v);
            ChuaXet[v] = false;
            while (hangDoi.Count != 0)
            {
                int tmp = hangDoi.Dequeue();
                Bfs.Add(tmp);
                for (int i = 0; i < SoCot; i++)
                    if ((A[tmp, i] == 1) && (ChuaXet[i] == true))
                    {
                        ChuaXet[i] = false;
                        hangDoi.Enqueue(i);
                    }
            }
        }
        public void CapNhatChuaXet()
        {
            for (int i = 0; i < ChuaXet.Count; i++)
                ChuaXet[i] = true;
        }

        List<int> nhan;

        public List<int> Nhan
        {
            get { return nhan; }
            set { nhan = value; }
        }

        void GanNhan(int i, int giatrinhan)
        {
            Nhan[i] = giatrinhan;
            for (int j = 0; j < SoCot; j++)
            {
                if ((Nhan[j] == 0) && (C[i, j] != 0))
                {
                    GanNhan(j, giatrinhan);
                }
            }
        }
        int[,] C;
        public int DemSoThanhPhanLienThong()
        {
            Nhan = new List<int>();
            Nhan.Clear();
            // vi neu la co huong ta phai chuyen quama tran C và xet tren ma tran c vo hướng.
            C = new int[SoDong, SoCot];
            for (int i = 0; i < SoDong; i++)
            {
                for (int j = 0; j < SoCot; j++)
                {
                    if (A[i, j] != 0)
                    {
                        C[i, j] = A[i, j];
                        C[j, i] = A[i, j];
                    }
                    else
                    {
                        C[i, j] = A[j, i];
                        C[j, i] = A[j, i];
                    }
                }
            }

            for (int i = 0; i < soCot; i++)
            {
                int t = 0;
                Nhan.Add(t);
            }
            int giatrinhan = 0;
            for (int i = 0; i < SoCot; i++)
            {
                if (!DaXoaDinh(i))
                {
                    if (Nhan[i] == 0)
                    {
                        giatrinhan++;
                        GanNhan(i, giatrinhan);
                    }
                }
            }
            return giatrinhan;
        }


        public void TimThanhPhanLienThong()
        {
 
            List<int> DemNhan = new List<int>();
            List<int> gtriNhanDem = new List<int>();
            int dem = 0;
            List<int> tmp = new List<int>();// lay cac nhan


            for (int i = 0; i < Nhan.Count; i++)
                if ((tmp.Contains(Nhan[i]) == false) && (Nhan[i]) != 0)
                    tmp.Add(Nhan[i]);

            for (int i = 0; i < tmp.Count; i++)// dem so lan xuat hien cua cac nhan
            {
                for (int j = 0; j < Nhan.Count; j++)
                    if (tmp[i] == Nhan[j])
                        dem++;
                DemNhan.Add(dem);
                dem = 0;
            }


            if ((DemNhan.Contains(dem) != true) && (dem != 0))
            {
                DemNhan.Add(dem);
            }
        }
     
        // tim duoong
        int[] back;

        public int[] Back
        {
            get { return back; }
            set { back = value; }
        }
        List<int> duongDi = new List<int>();

        public List<int> DuongDi
        {
            get { return duongDi; }
            set { duongDi = value; }
        }
        public int TimDuong(int dd)// tim dg tu dd den dc.
        {
            back = new int[SoCot];
            ChuaXet.Clear();
            for (int i = 0; i < SoCot; i++)
            {
                ChuaXet.Add(true);
                back[i] = 0;
            }

            for (int i = dd; i < SoCot; i++)// socot = so dinh
                if (ChuaXet[i] == true)
                {
                    ThamDinh(i);
                }
            for (int i = 0; i <= dd; i++)
                if (ChuaXet[i] == true)
                    ThamDinh(i);
            return 1;
        }
        void ThamDinh(int v)
        {
            ChuaXet[v] = false;
            for (int u = 0; u < SoCot; u++)
                if ((A[v, u] != 0) && (ChuaXet[u] == true))
                {
                    back[u] = v;
                    ThamDinh(u);
                }
            // ChuaXet[v] = true;
        }
        public bool LayDuongDi(int dd, int dc)
        {
            TimDuong(dd);
            DuongDi.Clear();
            if (back[dc] == -1)
                return false;
            else
            {
                int j = dc;
                DuongDi.Add(dc);
                int flag = 0;
                while (back[j] != dd)
                {
                    DuongDi.Add(back[j]);
                    j = back[j];
                    flag++;
                    if (flag > SoCot)
                        return false;

                }
                DuongDi.Add(dd);
            }
            return true;
        }
    }
}
